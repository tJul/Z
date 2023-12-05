using Microsoft.AspNetCore.Mvc;
using SOPlabNEW.Data;
using SOPlabNEW.HALR;
using SOPlabNEW.Models;

namespace SOPlabNEW.Controllers {
    [Route("api/[controller]")]
    public class LibraryController : Controller {
        private readonly ILibraryContext _db;
        const int PAGE_SIZE = 5;

        public LibraryController(ILibraryContext db) {
            _db = db;
        }
        [HttpGet]
        [Produces("application/hal+json")]
        public IActionResult Get(int index = 0, int count = PAGE_SIZE) {
            var items = _db.GetLibraries(index, count).Select(v => v.ToResource());
            var total = _db.CountLibraries();
            var _links = HAL.Paginate("/api/user", index, count, total);
            var result = new {
                _links,
                count,
                total,
                index,
                items
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Produces("application/hal+json")]
        public IActionResult Get(int id) {
            var lib = _db.GetLibraryById(id);
            if (lib == default)
                return NotFound();
            var resource = lib.ToResource();
            resource._actions = new {
                delete = new {
                    href = $"api/library/{id}",
                    method = "DELETE",
                    name = $"delete library {id} from database"
                },
                update = new {
                    href = $"api/library/{id}",
                    method = "PUT",
                    name = $"update library {id}"
                }
            };
            return Ok(resource);
        }
        
        [HttpGet("GetBooks/{libId}")]
        public IActionResult GetBooks(int libId) {
            var books = _db.GetLibraryBooks(libId);
            return Ok(books);
        }

        [HttpGet("GetAvailableBooks/{libId}")]
        public IActionResult GetAvailableBooks(int libId) {
            var books = _db.GetAvailableLibraryBooks(libId);
            return Ok(books);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Library lib) {
            lib.Id = id;
            _db.UpdateLibrary(lib);
            return Ok(lib);
        }

        

        [HttpPost]
        public IActionResult Post(Library lib) {
            _db.CreateLibrary(lib);
            return Ok(lib);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var lib = _db.GetLibraryById(id);
            _db.DeleteLibrary(lib);
            return Ok(lib.ToDynamic());
        }
    }
}

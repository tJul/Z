using Microsoft.AspNetCore.Mvc;
using SOPlabNEW.Data;
using SOPlabNEW.HALR;
using SOPlabNEW.Models;

namespace SOPlabNEW.Controllers {
    [Route("api/[controller]")]
    public class UserController : Controller {

        private readonly ILibraryContext _db;
        const int PAGE_SIZE = 5;

        public UserController(ILibraryContext db) {
            _db = db;
        }

        [HttpGet]
        [Produces("application/hal+json")]
        public IActionResult Get(int index = 0, int count = PAGE_SIZE) {
            var items = _db.GetUsers(index, count).Select(v => v.ToResource());
            var total = _db.CountUsers();
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
            var user = _db.GetLibraryById(id);
            if (user == default)
                return NotFound();
            var resource = user.ToResource();
            resource._actions = new {
                delete = new {
                    href = $"api/user/{id}",
                    method = "DELETE",
                    name = $"delete user {id} from database"
                },
                update = new {
                    href = $"api/user/{id}",
                    method = "PUT",
                    name = $"update user {id}"
                }
            };
            return Ok(resource);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, User user) {
            user.Id = id;
            _db.UpdateUser(user);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user) {          
            _db.CreateUser(user);
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var user = _db.GetUserById(id);
            _db.DeleteUser(user);
            return Ok(user.ToDynamic());
        }
    }
}

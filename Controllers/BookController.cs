using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using SOPlabNEW.Data;
using SOPlabNEW.HALR;
using SOPlabNEW.Models;

namespace SOPlabNEW.Controllers {
    [Route("api/[controller]")]
    public class BookController : Controller {
        private readonly ILibraryContext _db;
        const int PAGE_SIZE = 5;
        const string SIGNALR_HUB_URL = "http://localhost:5200/hub";
        private static HubConnection hub;

        public BookController(ILibraryContext db) {
            _db = db;
            hub = new HubConnectionBuilder().WithUrl(SIGNALR_HUB_URL).Build();
            Task task = hub.StartAsync();
        }
        [HttpGet]
        [Produces("application/hal+json")]
        public IActionResult Get(int index = 0, int count = PAGE_SIZE) {
            var items = _db.GetBooks(index, count).Select(v => v.ToResource());
            var total = _db.CountBooks();
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
            var book = _db.GetBookById(id);
            if (book == default)
                return NotFound();
            var resource = book.ToResource();
            resource._actions = new {
                delete = new {
                    href = $"api/book/{id}",
                    method = "DELETE",
                    name = $"delete book {id} from database"
                },
                update = new {
                    href = $"api/book/{id}",
                    method = "PUT",
                    name = $"update book {id}"
                }
            };
            return Ok(resource);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book) {
            book.Id = id;
            _db.UpdateBook(book);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book) {
            _db.CreateBook(book);
            var message = $"New book has been added: {book.BookTitle}";
            await hub.SendAsync("NotifyWebUsers", "gg", message);
            return Ok(book);
        }

    }
}

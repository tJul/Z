using Microsoft.AspNetCore.Mvc;

namespace SOPlabNEW.Controllers {
        [Route("[controller]")]
        public class HomeController : Controller {
        [HttpGet]
        public IActionResult Index() {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sa_it2030_fa24_fp_team_3_it2030_fa24.Models;

namespace sa_it2030_fa24_fp_team_3_it2030_fa24.Controllers
{
    public class HomeController : Controller
    {
        public DataContext dContext { get; set; }
        public HomeController(DataContext dContext) { 
            this.dContext = dContext;
        }
        public IActionResult Home(){ 
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Message([FromForm] Message PostedMessage, [FromForm] string? Page)
        {
            PostedMessage.SentTime = DateTime.Now;
            dContext.Messages.AddRange(PostedMessage);
            dContext.SaveChanges();
            return RedirectToAction(Page);
        }


    }
}

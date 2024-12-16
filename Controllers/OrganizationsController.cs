using Microsoft.AspNetCore.Mvc;
using sa_it2030_fa24_fp_team_3_it2030_fa24.Models;
using Microsoft.EntityFrameworkCore;

namespace sa_it2030_fa24_fp_team_3_it2030_fa24.Controllers
{
    public class OrganizationsController : Controller
    {
        public DataContext dContext { get; set; }
        
        public OrganizationsController(DataContext dContext) 
        {
            this.dContext = dContext;
        }

        public IActionResult Black_Knights()
        {
            return View(dContext.Organizations.Include(o => o.Leader).OrderBy(o => o.Leader).FirstOrDefault(o => o.name == "Black Knights"));
        }

        public IActionResult all() {
            return View(dContext.Organizations.OrderBy(o => o.Id));
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

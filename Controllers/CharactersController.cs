using Microsoft.AspNetCore.Mvc;
using sa_it2030_fa24_fp_team_3_it2030_fa24.Models;

namespace sa_it2030_fa24_fp_team_3_it2030_fa24.Controllers
{
    public class CharactersController : Controller
    {
        public DataContext dContext { get; set; }
        public CharactersController(DataContext dContext) { 
            this.dContext = dContext;
        }
        public IActionResult Lelouch()
        {
            return View(dContext.Characters.OrderBy(c => c.Id).FirstOrDefault(c=>c.name == "Lelouch"));
        }

        public IActionResult All(){
            return View(dContext.Characters.OrderBy(c => c.Id));
        }

        [HttpPost]
        public IActionResult Message([FromForm] Message PostedMessage,[FromForm] string? Page)
        {
            PostedMessage.SentTime = DateTime.Now;
            dContext.Messages.AddRange(PostedMessage);
            dContext.SaveChanges();
            return RedirectToAction(Page);
        }

         [HttpGet]
 public IActionResult Create()
 {
     return View(new Character());  // Provide an empty character model to the view
 }

 // This is the POST action when the form is submitted
 [HttpPost]
 public IActionResult CreateNew(Character character)
 {
     if (ModelState.IsValid)
     {
         dContext.Characters.Add(character);
         dContext.SaveChanges();
         return RedirectToAction("All");  //send to All
     }

     // If model is invalid, stay on the form and show validation errors
     return View("Create", character);
 }
    }
}

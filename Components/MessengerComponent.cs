using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using sa_it2030_fa24_fp_team_3_it2030_fa24.Models;

namespace sa_it2030_fa24_fp_team_3_it2030_fa24.Components
{
    public class MessengerComponent : ViewComponent
    {
        public DataContext dContext { get; set; }

        public MessengerComponent(DataContext dContext) {
            this.dContext = dContext;
        }

        public IViewComponentResult Invoke(String[] arg) {
            String Page = arg[0];
            String RelevantController = arg[1];
            ViewBag.Page = Page;
            ViewBag.RelevantController = RelevantController;
            //return new HtmlContentViewComponentResult(new HtmlString("<p>test</p>"));
            return View("Messenger",dContext.Messages.OrderByDescending(c=>c.SentTime).Where(c=>c.Page == Page));
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace sa_it2030_fa24_fp_team_3_it2030_fa24.Components
{
    public class SideBar : ViewComponent
    {
        public IViewComponentResult Invoke(String[] arg)
        {
            return View("SideBarView");
        }
    }
}

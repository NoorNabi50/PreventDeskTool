using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace PreventDeskTool.ViewComponents
{
    public class DashboardStatisticsViewComponent : ViewComponent
    {
        private readonly PreventDeskToolDBContext _context;

        public DashboardStatisticsViewComponent(PreventDeskToolDBContext context)
        {
           this._context = context;
        }


        public IViewComponentResult Invoke()
        {
            int Totalvideos = _context.Videos.ToList().Count;
            int Totalusers = _context.Users.ToList().Count;
            int totaltaskscompleted = _context.GameProgress.ToList().Count;
            return View(Tuple.Create(Totalusers,Totalvideos, totaltaskscompleted));
        }
    }
}

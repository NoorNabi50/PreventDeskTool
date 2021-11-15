using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreventDeskTool.Controllers
{
    [Authorize(Policy = "AuthorizedUser")]
    public class Videos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

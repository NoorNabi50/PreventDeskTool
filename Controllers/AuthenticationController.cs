using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreventDeskTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PreventDeskTool.Controllers
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        private PreventDeskToolDBContext DBcontext;
        public AuthenticationController(PreventDeskToolDBContext context)
        {
            DBcontext = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(Users user)
        {
            user = DBcontext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (user != null)
            {
                List<Claim> Claimsprops = new()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.UserCode),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                ClaimsIdentity identity = new(Claimsprops, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new()
                {
                    IsPersistent = user.IsRemeber,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(7)

                };
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
                return RedirectToAction("Index", "Dashboard");
            }

            return View("Index");
        }

        [AllowAnonymous]
       public ActionResult AccessDenied()
        {
            return View();
        }
        


        [AllowAnonymous]

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return View("Index");
        }
        
        //Authorize user with its role


    }

}
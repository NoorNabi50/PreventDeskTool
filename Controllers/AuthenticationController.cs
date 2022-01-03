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
     public class AuthenticationController : Controller
    {
        private readonly PreventDeskToolDBContext DBcontext;
        public AuthenticationController(PreventDeskToolDBContext context)
        {
            DBcontext = context;
        }

         public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Users user)
        {
            try
            {
                var u = DBcontext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (u != null)
                {
                    List<Claim> Claimsprops = new()
                    {
                        new Claim(ClaimTypes.Name, u.UserName),
                        new Claim(ClaimTypes.NameIdentifier, u.UserCode),
                        new Claim(ClaimTypes.Role, u.Role)
                    };

                    ClaimsIdentity identity = new(Claimsprops, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new()
                    {
                        IsPersistent = user.IsRemember,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
                    return RedirectToAction("Index", "Dashboard");
                }

                return View("Index");
            }

            catch (Exception e)
            {
                return View("Index");
            }
        }

       public ActionResult AccessDenied()
        {
            return View();
        }
        
      public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return View("Index");
        }
        
    }
}

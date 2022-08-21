using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PreventDeskTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PreventDeskTool.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly PreventDeskToolDBContext DBcontext;
        private IWebHostEnvironment HostingEnvironment;
        public AuthenticationController(PreventDeskToolDBContext context, IWebHostEnvironment hostEnvironment)
        {
            DBcontext = context;
            HostingEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(Users users)
        {
            users.ProfilePath = UploadFile.SaveFile(users.file, HostingEnvironment.WebRootPath, "ProfileImages");
            users.RegisterDate = DateTime.Now;
            users.Role = "PlayerUser";
            DBcontext.Users.Add(users);
            DBcontext.SaveChanges();
            return View("Index");
        }



        [HttpGet]
        public IActionResult Register()
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
                    u.UserCode = u.UserCode == null ? "" : u.UserCode;
                    List<Claim> Claimsprops = new()
                    {
                        new Claim("UserId",u.UserId.ToString()),
                        new Claim("Name", u.UserName),
                        new Claim(ClaimTypes.NameIdentifier, u.UserCode),
                        new Claim(ClaimTypes.Role, u.Role)
                    };

                    ClaimsIdentity identity = new(Claimsprops, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new()
                    {
                        IsPersistent = user.IsRemember,

                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
                    return RedirectToAction("Index", "Dashboard");

                }
                ViewBag.Message = "Incorrect UserName or Password Please Try Again!";
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

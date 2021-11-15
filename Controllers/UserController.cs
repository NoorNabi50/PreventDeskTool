using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreventDeskTool.Models;
using System;
using System.Linq;

namespace PreventDeskTool.Controllers
{

    [Authorize(Policy = "AuthorizedAdmin")]
    public class UserController : Controller
    {
        private readonly PreventDeskToolDBContext DBContext;

        public UserController(PreventDeskToolDBContext context)
        {
            DBContext = context;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(DBContext.Users.ToList());
        }


        [HttpPost]

        public string SaveUser(Users u)
        {
            try
            {
                DBContext.Users.Add(u);
                DBContext.SaveChanges();
                return "Success";
            }

            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [HttpGet]

        public ActionResult GetUser(int id = 0)
        {
            return View(DBContext.Users.Find(id));

        }

        [HttpPost]
        public string UpdateUser(Users u)
        {
            try
            {
                if (u.UserId >0)
                {
                    DBContext.Update(u);
                    DBContext.SaveChanges();
                    return "Success";
                }

                return "Failed";
            }

            catch (Exception e)
            {
                return e.ToString();
            }

        }

        [HttpPost]

        public string DeleteUser(int id = 0)
        {
            try
            {
                DBContext.Remove(new Users() { UserId = id });
                DBContext.SaveChanges();
                return "Success";
            }

            catch (Exception e)
            {
                return e.ToString();
            }
        }

    }
}

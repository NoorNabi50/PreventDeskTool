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

        public string SaveUser(Users entity)
        {
            try
            {
                DBContext.Users.Add(entity);
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
            try
            {
                return View(DBContext.Users.Find(id));
            }

            catch(Exception e)
            {
                return View("Index");
            }
        }

        [HttpPost]
        public string UpdateUser(Users entity)
        {
            try
            {
                if (entity.UserId >0)
                {
                    DBContext.Update(entity);
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
                DBContext.Users.Remove(new Users() { UserId = id });
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

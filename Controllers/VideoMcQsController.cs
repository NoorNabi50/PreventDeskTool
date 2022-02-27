using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreventDeskTool.Models;
using System;
using System.Collections.Generic;

namespace PreventDeskTool.Controllers
{
    [Authorize(Policy = "AuthorizedAdmin")]

    public class VideoMcQsController : Controller
    {
        private readonly PreventDeskToolDBContext DBContext;

        public VideoMcQsController(PreventDeskToolDBContext context)
        {
            DBContext = context;
        }

        [HttpPost]

        public string SaveVideoMCqs(List<VideoMcQs> data)
        {
            try
            {
               data.ForEach(x =>
                {
                    DBContext.VideoMCQs.Add(x);
                });
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

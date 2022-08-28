using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreventDeskTool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PreventDeskTool.Controllers
{
    public class VideosController : Controller
    {
        private IWebHostEnvironment HostingEnvironment;

        private PreventDeskToolDBContext context;
        public VideosController(IWebHostEnvironment hostingEnvironment,PreventDeskToolDBContext dBContext)
        {
            HostingEnvironment = hostingEnvironment;
            context = dBContext;
        }

        [Authorize(Policy = "AuthorizedUser")]

        public IActionResult Index()
        {
         
            return View(context.Videos.Where(c => context.VideoMCQs.Select(b=>b.VideoId).Contains(c.VideoId)));
        }
        

        [Authorize(Policy = "AuthorizedAdmin")]

        public IActionResult UploadVideoIndex()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AuthorizedAdmin")]

        public Videos UploadVideo(Videos video)
        {
            string filePath = UploadFile.SaveFile(video.Videofile,HostingEnvironment.WebRootPath,"Videos");
            if (filePath.Contains(video.Videofile.FileName))
            {
                video.VideoName = video.Videofile.FileName;
                video.VideoPath = filePath;
                context.Videos.Add(video);
                context.SaveChanges();
                int id = video.VideoId;
                if (id > 0)
                {
                    video =  context.Videos.Where(x => x.VideoId == id).FirstOrDefault();
                    video.TotalVideos = context.Videos.ToList().Count;
                    return video;
                }
            }
            return null;
        }

        public string DeleteVideo(int id = 0)
        {
            try
            {
                context.Videos.Remove(new Videos() { VideoId = id });
                context.SaveChanges();
                return "Success";
            }

            catch (Exception e)
            {
                return e.ToString();
            }
        }



    }
}

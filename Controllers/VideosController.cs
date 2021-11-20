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
            return View(context.Videos.ToList());
        }
        

        [Authorize(Policy = "AuthorizedAdmin")]

        public IActionResult UploadVideoIndex()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AuthorizedAdmin")]

        public Videos UploadVideo(IFormFile video)
        {
            string filePath = SaveFile(video);
            if (filePath.Contains(video.FileName))
            {
                Videos vid = new() { VideoName = video.FileName, VideoPath = filePath, DifficultyCategory = 1 };
                context.Videos.Add(vid);
                context.SaveChanges();
                int id = vid.VideoId;
                int count = context.Videos.ToList().Count;
                if (id > 0)
                {
                    vid =  context.Videos.Where(x => x.VideoId == id).FirstOrDefault();
                    vid.TotalVideos = count;   
                    return vid;
                }
            }
            return null;
        }


        private string SaveFile(IFormFile file)
        {
            try
            {
                string Folderpath = Path.Combine(HostingEnvironment.WebRootPath, "Videos");
                string File = Guid.NewGuid().ToString() + '-' + file.FileName;
                string CompletePath = Path.Combine(Folderpath, File);
                FileStream fileStream = System.IO.File.Create(CompletePath);
                file.CopyTo(fileStream);
                fileStream.Dispose();
                return File;

            }

            catch(Exception e)
            {
                return e.ToString();
            }

        }





    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreventDeskTool.Models;
using System;
using System.Linq;

namespace PreventDeskTool.Controllers
{
    [Authorize(Policy = "AuthorizedUser")]
    public class PlayGroundController : Controller
    {


        private readonly PreventDeskToolDBContext dBContext;

        public PlayGroundController(PreventDeskToolDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public Videos GetVideo(int level = 0)
        {
            try
            {
                var videos = dBContext.Videos.Where(x => x.DifficultyCategory == level).ToList();
                return videos[new Random().Next(videos.Count)];
            }

            catch(Exception e)
            {
                return null;
            }
        }

        public JsonResult GetVideoMCqsDetailById(int VideoId)
        {
            string video = dBContext.Videos.Find(VideoId).VideoMcQsTitle;
            var VideoMcqsDetail = dBContext.VideoMCQs.Where(x => x.VideoId == VideoId).ToList().Select(x => new { x.VideoId, x.OptionId, x.OptionText });
            return Json(new { Video = video, VideoMcQsOptions = VideoMcqsDetail });
        }

        public string SaveProgress(GameProgress progress)
        {
            try
            {
                progress.UserId = int.Parse(User.FindFirst("UserId").Value);
                dBContext.GameProgress.Add(progress);
                progress.gameProgressVideo.ProgressId = dBContext.SaveChanges();
                dBContext.GameProgressVideo.Add(progress.gameProgressVideo);
                int progressVideoId = dBContext.SaveChanges();
                progress.gameProgressDetail.ForEach((x) =>
                {
                    x.GameProgressVideoId = progressVideoId;
                    dBContext.GameProgressDetail.Add(x);
                });
                dBContext.SaveChanges();
                return "OK";
            }
            catch(Exception E)
            {
                return "Failed";
            }
        }
    }
}

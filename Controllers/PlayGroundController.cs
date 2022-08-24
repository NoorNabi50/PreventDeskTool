using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreventDeskTool.Models;
using Rotativa.AspNetCore;
using System;
using System.Data;
using System.Linq;

namespace PreventDeskTool.Controllers
{
    [Authorize(Policy = "AuthorizedUser")]
    public class PlayGroundController : Controller
    {


        private readonly PreventDeskToolDBContext dBContext;
        private IDbConnection connection;
        private static int progressid { get; set; } = 0;
        public PlayGroundController(PreventDeskToolDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetVideo(int level = 0)
        {
            try
            {
                var videos = dBContext.Videos.Where(x => x.DifficultyCategory == level).ToList();
                var video = videos[new Random().Next(0,videos.Count)];
                return Json(new { video, status = true });

            }

            catch (Exception e)
            {
                connection = SQLConnect.ConnectDatabase();
                var progressrep = connection.Query<StoredProcedureProperties>("sp_EvaluatePerformance", new
                {
                    @param1 = int.Parse(User.FindFirst("UserId").Value)
                ,
                    @param2 = progressid
                }, commandType: CommandType.StoredProcedure);
                connection.Close();
                progressid = 0;
                return Json(progressrep);
            }


        }

        public JsonResult GetVideoMCqsDetailById(int VideoId)
        {
            string video = dBContext.Videos.Find(VideoId).VideoMcQsTitle;
            var VideoMcqsDetail = dBContext.VideoMCQs.Where(x => x.VideoId == VideoId).ToList().Select(x => new { x.VideoId, x.OptionId, x.OptionText });
            return Json(new { Video = video, VideoMcQsOptions = VideoMcqsDetail });
        }

        [HttpPost]
        public string SaveProgress(GameProgress progress)
        {
            try
            {
                if (progressid == 0)
                {
                    progress.UserId = int.Parse(User.FindFirst("UserId").Value);
                    dBContext.GameProgress.Add(progress);
                    dBContext.SaveChanges();
                    progressid = progress.ProgressId;
                }
                progress.gameProgressVideo.ProgressId = progressid;
                dBContext.GameProgressVideo.Add(progress.gameProgressVideo);
                dBContext.SaveChanges();
                progress.gameProgressDetail.ForEach((x) =>
                {
                    x.GameProgressVideoId = progressid;
                    dBContext.GameProgressDetail.Add(x);
                });
                dBContext.SaveChanges();

                return "OK";
            }
            catch (Exception E)
            {
                return "Failed";
            }
        }


        [HttpGet]

        public IActionResult GenerateCertificate()
        {
            return new ViewAsPdf();
        }
    }
}

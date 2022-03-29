using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PreventDeskTool.Models;
using System;
using System.Security.Claims;

namespace PreventDeskTool.Controllers
{
    public class ChatController : Controller
    {
        private readonly PreventDeskToolDBContext context;

        public IConfiguration _configuration { get; }

        public ChatController(PreventDeskToolDBContext _contxt,IConfiguration configuration)
        {
            context = _contxt;
            _configuration = configuration;

        }
        [HttpPost]
        public Chat SaveChat(Chat chat)
        {
            try
            {
                if (!User.IsInRole("AdminUser"))
                    chat.UserId = int.Parse(User.FindFirst("UserId").Value);
                else
                    chat.UserId = 2029;

                chat.MessageTime = DateTime.Now;
                chat.AdminId = int.Parse(_configuration["AdminId"]);
                chat.MessageBy = User.FindFirst(ClaimTypes.Role).Value;
                context.Chat.Add(chat);
                if (context.SaveChanges() > 0)
                    return new Chat() { MessageText =  chat.MessageText,MessageTime= chat.MessageTime ,MessageDate = string.Concat(chat.MessageTime.ToString("MMMM dd"), " " + chat.MessageTime.ToString("h:mm tt")) };
                return null;
            }

            catch(Exception  e)
            {
                return null;
            }
        } 
     
    }
}
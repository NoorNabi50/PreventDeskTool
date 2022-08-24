using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PreventDeskTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    chat.UserId = chat.UserId;

                chat.MessageTime = DateTime.Now;
                chat.AdminId = int.Parse(_configuration["AdminId"]);
                chat.MessageBy = User.FindFirst(ClaimTypes.Role).Value;
                context.Chat.Add(chat);
                if (context.SaveChanges() > 0)
                    return new Chat() { MessageText = chat.MessageText, MessageTime = chat.MessageTime, MessageDate = chat.MessageTime.ToString("MM/dd/yyyy h:mm tt") };
                return null;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]

        public List<Chat> GetChatsByUserId(int UserId)
        {
            try
            {
                var chats =  context.Chat.Where(x => x.UserId == UserId).ToList();

                chats.ForEach((x) =>
                {
                    x.MessageDate = x.MessageTime.ToString("MM/dd/yyyy h:mm tt");
                });
                return chats;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
using Microsoft.AspNetCore.Mvc;
using PreventDeskTool.Models;
using System;
using System.Security.Claims;

namespace PreventDeskTool.Controllers
{
    public class ChatController : Controller
    {
        private readonly PreventDeskToolDBContext context;

        public ChatController(PreventDeskToolDBContext _contxt)
        {
            context = _contxt;

        }

        public string SaveChat(Chat chat)
        {
            try
            {
                chat.UserId = int.Parse(User.FindFirst("UserId").Value);
                chat.MessageTime = DateTime.Now;
                context.Chat.Add(chat);
                context.SaveChanges();
                return "Success";
            }

            catch(Exception  e)
            {
                return "Failed";
            }
        }
     
    }
}

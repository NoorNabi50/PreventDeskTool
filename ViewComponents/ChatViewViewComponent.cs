using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreventDeskTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PreventDeskTool.ViewComponents
{
    public class ChatViewViewComponent : ViewComponent
    {
        private readonly PreventDeskToolDBContext _context;

        public ChatViewViewComponent(PreventDeskToolDBContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirst("UserId").Value);
            string role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            List<Chat> chats = _context.Chat.FromSqlInterpolated($"Exec GetChatByUser @param1 = {currentUserId},@param2 = {role}").ToList();
            chats.ForEach((x) =>
            {

                x.MessageDate = string.Concat(x.MessageTime.ToString("MMMM dd"), " " + x.MessageTime.ToString("h:mm tt"));
            });
            return View(chats);
        }
    }
}


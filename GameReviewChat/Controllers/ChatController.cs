using GameReviewChat.Hubs;
using GameReviewChat_Data.Dtos;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewChat.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("send")]     //path looks like this: https://localhost:44332/api/chat/send
        [HttpPost]
        public IActionResult SendRequest(MessageDto msg)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", msg.username, msg.messageText);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewChat.Hubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string username, string message)
        {
            return Clients.All.SendAsync("ReceiveOne", username, message);
        }
    }
}

using ChatRooms.Models.ChatRoom;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;

namespace ChatRooms.Hubs
{
    [Authorize]
    public class ChatRoomHub : Hub
    {
        ChatRoomsViewModel chatrooms = new ChatRoomsViewModel();

        public void JoinChatRoom(string currentChatroom, string previousChatRoom)
        {
            string connectionId = Context.ConnectionId;                                 // Get current connection identifier
            if (!string.IsNullOrEmpty(previousChatRoom))
            {
                Groups.Remove(connectionId, previousChatRoom);                          // Remove user from current room
            }
            Groups.Add(connectionId, currentChatroom);                                  // Connect to new group
            var user = Context.User.Identity;                                           // Get current User
            var msg = String.IsNullOrEmpty(previousChatRoom) ? $" has joined '{currentChatroom}'" : $" has left {previousChatRoom} and joined '{currentChatroom}'";
            var message = new MessageModel()                                            // Create Message To Send
            {
                Time = DateTime.Now,
                Content = $"{user.Name} {msg}",
                MessageType = 0,
                User = user.Name
            };
            Clients.All.registerNewUser(JsonConvert.SerializeObject(message));          // Notify everyone
        }

        public void SendMessageToChatRoom(string content, string currentChatroom)
        {
            var user = Context.User.Identity;
            var message = new MessageModel()                                            // Create Message To Send
            {
                Time = DateTime.Now,
                Content = content,
                MessageType = 1,
                User = user.Name
            };
            Clients.Group(currentChatroom).registerMessage(JsonConvert.SerializeObject(message));
        }

        /// <summary>
        /// Removes user from all groups
        /// </summary>
        /// <param name="connectionId"></param>
        private void RemoveFromGroups(string connectionId)
        {
            foreach (var room in chatrooms.Rooms)
            {
                Groups.Remove(connectionId, room);
            }
        }
    }
}
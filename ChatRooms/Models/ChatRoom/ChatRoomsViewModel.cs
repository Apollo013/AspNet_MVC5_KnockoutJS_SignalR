using System.Collections.Generic;

namespace ChatRooms.Models.ChatRoom
{
    public class ChatRoomsViewModel
    {
        public List<string> Rooms { get; set; }

        public ChatRoomsViewModel()
        {
            Rooms = new List<string>()
            {
                "Young Socialists",
                "Bananna Republic",
                "The Templars"
            };
        }
    }
}
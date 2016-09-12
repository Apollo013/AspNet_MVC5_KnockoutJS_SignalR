using System;

namespace ChatRooms.Models.ChatRoom
{
    public class MessageModel
    {
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public byte MessageType { get; set; }
        public string User { get; set; }
    }
}
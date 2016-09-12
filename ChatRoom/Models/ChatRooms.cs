using System.Collections.Generic;

namespace ChatRoom.Models
{
    public class ChatRooms
    {
        public List<ChatRoom> Rooms = new List<ChatRoom>();

        public ChatRooms()
        {
            Rooms.Add(new ChatRoom("Banannas Room"));
            Rooms.Add(new ChatRoom("Templars Room"));
            Rooms.Add(new ChatRoom("Young Socialist Room"));
        }
    }

    public class ChatRoom
    {
        public ChatRoom(string name)
        {
            RoomName = name;
        }
        public string RoomName { get; set; }
    }
}
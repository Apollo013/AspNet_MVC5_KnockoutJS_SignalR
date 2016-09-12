using ChatRooms.Models.ChatRoom;
using System.Web.Mvc;

namespace ChatRooms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetChatRooms()
        {
            // Create a list of chat rooms to be used by view
            var chatrooms = new ChatRoomsViewModel();
            return this.Json(new SelectList(chatrooms.Rooms), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
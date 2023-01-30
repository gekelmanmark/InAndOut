using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            /*string todaysDate = DateTime.Now.ToShortDateString();
            return Ok(todaysDate);*/
        }
    }
}

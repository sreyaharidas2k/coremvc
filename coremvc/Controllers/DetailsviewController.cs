using coremvc.Models;
using Microsoft.AspNetCore.Mvc;
using coremvc.Models;
namespace coremvc.Controllers
{
    public class DetailsviewController : Controller
    {

        DBEmployee dbobj = new DBEmployee();
        public IActionResult Details_Pageload()
        {
            return View();
        }
        
    }
}

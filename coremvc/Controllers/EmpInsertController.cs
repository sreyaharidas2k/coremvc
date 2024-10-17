using Microsoft.AspNetCore.Mvc;
using coremvc.Models;
namespace coremvc.Controllers
{
    public class EmpInsertController : Controller
    {
        DBEmployee dbobj = new DBEmployee();
        public IActionResult Index_pageload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index_click(Employee empclsobj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string resp = dbobj.InsertDB(empclsobj);
                    TempData["msg"] = resp;
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("Index_pageload");
        }
    }
}

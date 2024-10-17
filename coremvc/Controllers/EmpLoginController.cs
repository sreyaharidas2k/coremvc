using Microsoft.AspNetCore.Mvc;
using coremvc.Models;

using coremvc.Models;
namespace coremvc.Controllers
{
    public class EmpLoginController : Controller
    {
        DBEmployee dbobj = new DBEmployee();
        public IActionResult Log_Pageload()
        {
            return View();
        }

        public IActionResult Log_click(Employee empclsobj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    int cid = dbobj.LoginDB(empclsobj);
                    if(cid==1)
                    {
                        // TempData["msg"] = "Success";
                        return RedirectToAction("UserProfile_Pageload", "EmpProfile", new { id = empclsobj.eid });
                    }
                    else
                    {
                        TempData["msg"] = "Invalid Login";
                    }
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("Log_Pageload");
        }
    }
}

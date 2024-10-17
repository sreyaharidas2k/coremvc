using Microsoft.AspNetCore.Mvc;
using coremvc.Models;
namespace coremvc.Controllers
{
    public class EmpProfileController : Controller
    {
        DBEmployee dbobj = new DBEmployee();
        public IActionResult UserProfile_Pageload(int id)
        {
            Employee getlist = dbobj.Profileview(id);

            return View(getlist);
        }
        public IActionResult Profile_Update_Click(Employee empobjcls)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string s = dbobj.UpdateDB(empobjcls);
                    TempData["msg1"] = s;
                }
            }
            catch (Exception ex)
            {
                TempData["msg1"] = ex.Message.ToString();
               
            }
            return View("UserProfile_Pageload");
        }
    }

    
}

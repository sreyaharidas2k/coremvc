using coremvc.Models;
using Microsoft.AspNetCore.Mvc;
using coremvc.Models;
namespace coremvc.Controllers
{
    public class DisplayAllDetailsController : Controller
    {
        DBEmployee dbobj = new DBEmployee();
        public IActionResult AllProfile_Page()
        {
            List<Employee> getlist = dbobj.SelectDB();
            return View(getlist);
        }
        [HttpPost]
        public IActionResult DeleteTab(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.DeleteDB(id);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            List<Employee> getlist = dbobj.SelectDB();//return to pageload after deleting perticular row.
            return View("AllProfile_Page", getlist);
        }
        [HttpPost]
        public IActionResult DetailsTab(int id)
        {
            Employee resp = new Employee();
            try
            {
                if (ModelState.IsValid)
                {
                    resp = dbobj.Profileview(id);

                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return View(resp);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Techneuron_BharathProject.Models;

namespace Techneuron_BharathProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly EmployeeDb _ctx;
        public TaskController(EmployeeDb ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Display()
        {
            var tas = _ctx.Employees.ToList();
            return View(tas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Employees.Add(employee);
                _ctx.SaveChanges();
                TempData["msg"] = "Added succesfully";
                return RedirectToAction("Display");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "added succesfully";
                return View(ex);
            }
        }
        public IActionResult Edit(int Id)
        {
            var employee = _ctx.Employees.Find(Id);
            return View(employee);
            
        }
        [HttpPost]
        public IActionResult Edit(Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Employees.Update(employee);
                _ctx.SaveChanges();
                return RedirectToAction("Display");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "could not update !";
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            try
            {
                var employee = _ctx.Employees.Find(Id);
                if(employee != null)
                {
                    _ctx.Employees.Remove(employee);
                    _ctx.SaveChanges();
                }

            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Display");
        }
    }
}

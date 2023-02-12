using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    
    public class EmployeeController : Controller
    {
        EmployeeCRUD crud;
        DeptCRUD deptCRUD;
        private readonly IConfiguration configuration;

        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new EmployeeCRUD(this.configuration);
            deptCRUD = new DeptCRUD(this.configuration);
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
        
            var deptlist = deptCRUD.DeptList();     
           
           
            var list = crud.GetAllEmployess();
            foreach (Employee item in list)
            {
                foreach (Dept item2 in deptlist)
                {
                    if (item2.Deptid == item.Deptid)
                    {
                        item.DeptName=item2.DeptName;

                    }

                }

            }
            return View(list);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int Id)
        {
            var emplist = crud.GetAllEmployess();
            var deptlist = deptCRUD.DeptList();
            foreach (Employee item in emplist)
            {
                if(item.Id==Id)
                {
                    foreach (Dept item2 in deptlist)
                    {
                        if(item2.Deptid==item.Deptid)
                        {
                            ViewData["bname"] = item2.DeptName;
                        }
                    }
                }
            }

            var emp = crud.GetEmployeeById(Id);

            return View(emp);
           
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            var deptlist = deptCRUD.DeptList();
            ViewBag.DeptList = deptlist;
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = crud.AddEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int Id)
        {
            var deptlist = deptCRUD.DeptList();
            ViewBag.DeptList = deptlist;
            var emp = crud.GetEmployeeById(Id);

            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = crud.UpdateEmployee(emp);
                if (result == 1)
                {
                    ViewBag.Error = "";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int Id)
        {
            var emp = crud.GetEmployeeById(Id);

            return View(emp);
           
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int Id)
        {
            try
            {

                int result = crud.DeleteEmployee(Id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}

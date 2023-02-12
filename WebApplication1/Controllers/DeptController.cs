using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DeptController : Controller
    {
        
        private readonly IConfiguration configuration;
        DeptCRUD crud;
        public DeptController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new DeptCRUD(this.configuration);
        }
        // GET: DeptController
        public ActionResult Index()
        {
            var list = crud.DeptList();
            return View(list);

        }

        // GET: DeptController/Details/5
        public ActionResult Details(int id)
        {
            var dept = crud.GetDeptById(id);
            return View(dept);

        }

        // GET: DeptController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeptController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dept dept)
        {
            try
            {
                int result = crud.AddDept(dept);
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

        // GET: DeptController/Edit/5
        public ActionResult Edit(int id)
        {
            var dept = crud.GetDeptById(id);
            return View(dept);

         
        }

        // POST: DeptController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dept dept)
        {
            try
            {
                int result = crud.UpdateDept(dept);
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

        // GET: DeptController/Delete/5
        public ActionResult Delete(int id)
        {
            var dept = crud.GetDeptById(id);
            return View(dept);

           
        }

        // POST: DeptController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteDept(id);
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

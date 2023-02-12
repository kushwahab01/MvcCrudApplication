using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        StudentCRUD crud;
        private readonly IConfiguration configuration;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new StudentCRUD(this.configuration);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var list = crud.GetAllStudent();
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int Id)
        {
            var s = crud.GetStudentById(Id);
            return View(s);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s)
        {
            try
            {
                int result = crud.AddStudent(s);
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int Id)
        {
            var s = crud.GetStudentById(Id);

            return View(s);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student s)
        {

            try
            {
                int result = crud.UpdateStudent(s);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int Id)
        {
            var s = crud.GetStudentById(Id);

            return View(s);
           
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int Id)
        {
            try
            {
                int result = crud.DeleteStudent(Id);
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

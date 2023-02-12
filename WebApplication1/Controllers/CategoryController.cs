using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        CategoryCRUD crud;
        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new CategoryCRUD(this.configuration);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var list = crud.CategoryList();

            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var c=crud.GetCategoryById(id);

            return View(c);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                int result = crud.AddCategory(category);
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var c = crud.GetCategoryById(id);
            return View(c);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int result = crud.UpdateCategory(category);
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

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {   var c=crud.GetCategoryById(id);
            return View(c);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteCategory(id);
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

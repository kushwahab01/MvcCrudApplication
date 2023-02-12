using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        ProductCRUD crud;
        CategoryCRUD categoryCRUD;
        private readonly IConfiguration configuration;

        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new ProductCRUD(this.configuration);
            categoryCRUD = new CategoryCRUD(this.configuration);
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var clist = categoryCRUD.CategoryList();
            var list = crud.GetAllProduct();
            foreach (Product item in list)
            {
                foreach (Category item2 in clist)
                {
                    if (item2.Cid == item.Cid)
                    {
                        item.Cname = item2.Cname;

                    }

                }

            }
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var plist = crud.GetAllProduct();
            var clist = categoryCRUD.CategoryList();
            foreach (Product item in plist)
            {
                if (item.Pid == id)
                {
                    foreach (Category item2 in clist)
                    {
                        if (item2.Cid == item.Cid)
                        {
                            ViewData["sname"] = item2.Cname;
                        }
                    }
                }

            }
            var p = crud.GetProductById(id);

            return View(p);
        }
            // GET: ProductController/Create
            public ActionResult Create()
        {
            var clist = categoryCRUD.CategoryList();
            ViewBag.CategoryList = clist;
            return View();
          
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            try
            {
                int result = crud.AddProduct(p);
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int Id)
        {
            var clist = categoryCRUD.CategoryList();
            ViewBag.CategoryList = clist;
            var p = crud.GetProductById(Id);

            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p)
        {
            try
            {
                int result = crud.UpdateProduct(p);
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var p = crud.GetProductById(id);
            return View(p);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {

                int result = crud.DeleteEmployee(id);
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

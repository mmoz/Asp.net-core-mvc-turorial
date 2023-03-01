using ASP1st.Data;
using ASP1st.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ASP1st.Controllers
{
    public class personalController : Controller
    {
        private readonly ApplicationDBContext _db;

        public personalController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {


            IEnumerable <Product> Allproduct = _db.Product;
            return View(Allproduct);
        }
        public  IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Product.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id ==0)
            {
                return NotFound();
            }
            var obj = _db.Product.Find(Id);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Product.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Product.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Product.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }








        }
}

using Day3_VuKimThien.Data;
using Day3_VuKimThien.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day3_VuKimThien.Controllers
{
    public class ProductController : Controller
    {
        private void LoadCategories()
        {
            ViewBag.CategoryId = new SelectList(
                SeedData.categories,
                "Id",
                "Name"
            );
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var products = SeedData.Products;

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = SeedData.Products.Count + 1;
                SeedData.Products.Add(product);

                return RedirectToAction(nameof(Index));
            }

            LoadCategories();
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            var existingProduct = SeedData.Products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;

                return RedirectToAction(nameof(Index));
            }

            LoadCategories();
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Product product)
        {
            var existingProduct = SeedData.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            SeedData.Products.Remove(existingProduct);
            return RedirectToAction(nameof(Index));
        }


    }
}
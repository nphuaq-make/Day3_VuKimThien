using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_VuKimThien.Data;
using Day3_VuKimThien.Models;

namespace Day3_VuKimThien.Controllers
{
    public class CategoryController : Controller
    {
         //GET: CategoryController1
        public ActionResult Index()
        {
            var _categories = SeedData.categories;
            return View(_categories);
        }

        // GET: CategoyController1/Details/5
        public ActionResult Details(int id)
        {
            //lay ra category co id truyen vao tu SeedData
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            //New category == null thi tra ve trang loi
            if(category == null)
            {
                return NotFound();
            }

            //neu categoy khac null thi tra ve view va truyen category vao view
            return View(category);
        }

        // GET: CategoyController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoyController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //lay max id trong danh sach seedData.categories
                int maxId = SeedData.categories.Max(c => c.Id);

                //set id cho category
                category.Id = maxId+1;
                //Them category vao danh sach SeedData.categories
                SeedData.categories.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: CategoyController1/Edit/5
        public ActionResult Edit(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoyController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Category category)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View(category);
            }
        }

        // GET: CategoyController1/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoyController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == category.Id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                SeedData.categories.Remove(existingCategory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

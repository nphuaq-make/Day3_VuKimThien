using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_VuKimThien.Data;
using Day3_VuKimThien.Models;

namespace Day3_VuKimThien.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        //public CategoryController(ILogger<CategoryController> logger)
        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }
        //GET: CategoryController1
        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            // Tổng số Category
            int totalCategories = SeedData.categories.Count;

            // Tổng số trang
            int totalPages = (int)Math.Ceiling((double)totalCategories / pageSize);

            // Đảm bảo page hợp lệ
            page = Math.Max(1, Math.Min(page, Math.Max(1, totalPages)));

            // Lấy danh sách Category theo trang
            var categories = SeedData.categories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Truyền thông tin phân trang sang View
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(categories);
        }

        // GET: CategoyController1/Details/5
        public ActionResult Details(int id)
        {
            _logger.LogInformation("loi : {Id}", id);
            _logger.LogError("loi tiep : {Id}", id);
            //lay ra category co id truyen vao tu SeedData
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            //New category == null thi tra ve trang loi
            if (category == null)
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
                category.Id = maxId + 1;
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

        // GET: Category/Products/5
        public ActionResult Products(int id)
        {
            // Tìm Category theo id
            var category = SeedData.categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            // Lấy tất cả Product thuộc Category này
            var products = SeedData.Products
                .Where(p => p.CategoryId == id)
                .ToList();

            ViewBag.CategoryName = category.Name;

            return View(products);
        }
    }
}
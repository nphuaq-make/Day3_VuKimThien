using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3_VuKimThien.Controllers
{
    public class CategoyController1 : Controller
    {
        // GET: CategoyController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoyController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoyController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoyController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoyController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoyController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoyController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoyController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

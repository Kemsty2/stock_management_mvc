using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    public class ActivitesController : Controller
    {
        // GET: ActivitesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ActivitesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActivitesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivitesController/Create
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

        // GET: ActivitesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActivitesController/Edit/5
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

        // GET: ActivitesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActivitesController/Delete/5
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
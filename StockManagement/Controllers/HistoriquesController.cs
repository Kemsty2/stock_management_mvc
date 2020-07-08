using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    public class HistoriquesController : Controller
    {
        // GET: HistoriqueController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistoriqueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistoriqueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoriqueController/Create
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

        // GET: HistoriqueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistoriqueController/Edit/5
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

        // GET: HistoriqueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistoriqueController/Delete/5
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
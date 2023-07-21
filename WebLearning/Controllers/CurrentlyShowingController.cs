using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieManagementMVC.Controllers
{
    public class CurrentlyShowingController : Controller
    {
        // GET: CurrentlyShowingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CurrentlyShowingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CurrentlyShowingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrentlyShowingController/Create
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

        // GET: CurrentlyShowingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CurrentlyShowingController/Edit/5
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

        // GET: CurrentlyShowingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CurrentlyShowingController/Delete/5
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

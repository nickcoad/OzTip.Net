using System.Net;
using System.Web.Mvc;
using OzTip.Core.Interfaces;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.Web.Areas.Admin.Controllers
{
    public class SeasonsController : Controller
    {
        private readonly IRepository<Season> _seasonRepository;

        public SeasonsController()
        {
            _seasonRepository = new RepositoryBase<Season>();
        }

        public SeasonsController(
            IRepository<Season> seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        // GET: Dev/Seasons
        public ActionResult Index()
        {
            return View(_seasonRepository.Get());
        }

        // GET: Dev/Seasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var season = _seasonRepository.GetById(id.Value);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // GET: Dev/Seasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dev/Seasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Start,End,Name,TelstraCode,Created,Updated")] Season season)
        {
            if (ModelState.IsValid)
            {
                _seasonRepository.Create(season);
                return RedirectToAction("Index");
            }

            return View(season);
        }

        // GET: Dev/Seasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var season = _seasonRepository.GetById(id.Value);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: Dev/Seasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Start,End,Name,TelstraCode,Created,Updated")] Season season)
        {
            if (ModelState.IsValid)
            {
                _seasonRepository.Update(season);
                return RedirectToAction("Index");
            }
            return View(season);
        }

        // GET: Dev/Seasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var season = _seasonRepository.GetById(id.Value);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: Dev/Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _seasonRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _seasonRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System.Net;
using System.Web.Mvc;
using OzTip.Interfaces;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompetitionsController : Controller
    {
        private readonly IRepository<Competition> _competitionRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Season> _seasonRepository;
        
        public CompetitionsController(
            IRepository<Competition> competitionRepository,
            IRepository<User> userRepository,
            IRepository<Season> seasonRepository)
        {
            _competitionRepository = competitionRepository;
            _userRepository = userRepository;
            _seasonRepository = seasonRepository;
        }

        // GET: admin/competitions
        public ActionResult Index()
        {
            var competitions = _competitionRepository.Include(c => c.Season).Include(c => c.Owner).Get();
            return View(competitions);
        }

        // GET: admin/competitions/details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var competition = _competitionRepository.GetById(id.Value);
            if (competition == null)
            {
                return HttpNotFound();
            }

            return View(competition);
        }

        // GET: admin/competitions/create
        public ActionResult Create()
        {
            ViewBag.SeasonId = new SelectList(_seasonRepository.Get(), "Id", "Name");
            ViewBag.UserId = new SelectList(_userRepository.Get(), "Id", "Username");
            return View();
        }

        // POST: admin/competitions/create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,SeasonId,Name,IsPublic,Created,Updated")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                _competitionRepository.Create(competition);

                return RedirectToAction("Index");
            }

            ViewBag.SeasonId = new SelectList(_seasonRepository.Get(), "Id", "Name", competition.SeasonId);
            ViewBag.UserId = new SelectList(_userRepository.Get(), "Id", "Username", competition.UserId);
            return View(competition);
        }

        // GET: admin/competitions/edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var competition = _competitionRepository.GetById(id.Value);
            if (competition == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonId = new SelectList(_seasonRepository.Get(), "Id", "Name", competition.SeasonId);
            ViewBag.UserId = new SelectList(_userRepository.Get(), "Id", "Username", competition.UserId);
            return View(competition);
        }

        // POST: admin/competitions/edit/{id}
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,SeasonId,Name,IsPublic,Created,Updated")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                _competitionRepository.Update(competition);
                
                return RedirectToAction("Index");
            }
            ViewBag.SeasonId = new SelectList(_seasonRepository.Get(), "Id", "Name", competition.SeasonId);
            ViewBag.UserId = new SelectList(_userRepository.Get(), "Id", "Username", competition.UserId);
            return View(competition);
        }

        // GET: admin/competitions/delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var competition = _competitionRepository.GetById(id.Value);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: admin/competitions/delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _competitionRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

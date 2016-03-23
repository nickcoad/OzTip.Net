using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OzTip.Core.Interfaces;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.Web.Areas.Dev.Controllers
{
    public class CompetitionsController : Controller
    {
        private readonly IRepository<Competition> _competitionRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Season> _seasonRepository;

        public CompetitionsController()
        {
            _competitionRepository = new RepositoryBase<Competition>();
            _userRepository = new RepositoryBase<User>();
            _seasonRepository = new RepositoryBase<Season>();
        }

        public CompetitionsController(
            IRepository<Competition> competitionRepository,
            IRepository<User> userRepository,
            IRepository<Season> seasonRepository)
        {
            _competitionRepository = competitionRepository;
            _userRepository = userRepository;
            _seasonRepository = seasonRepository;
        }

        // GET: Dev/Competitions
        public ActionResult Index()
        {
            var competitions = _competitionRepository.Include(c => c.Season).Include(c => c.Owner).Get();
            return View(competitions);
        }

        // GET: Dev/Competitions/Details/5
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

        // GET: Dev/Competitions/Create
        public ActionResult Create()
        {
            ViewBag.SeasonId = new SelectList(_seasonRepository.Get(), "Id", "Name");
            ViewBag.UserId = new SelectList(_userRepository.Get(), "Id", "Username");
            return View();
        }

        // POST: Dev/Competitions/Create
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

        // GET: Dev/Competitions/Edit/5
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

        // POST: Dev/Competitions/Edit/5
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

        // GET: Dev/Competitions/Delete/5
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

        // POST: Dev/Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _competitionRepository.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _competitionRepository.Dispose();
                _seasonRepository.Dispose();
                _userRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}

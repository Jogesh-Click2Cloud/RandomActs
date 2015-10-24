using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RandomActs.Models;

namespace RandomActs.Controllers
{
    public class ActorController : Controller
    {
		private readonly IRandomActorRepository actorRepository;

        public ActorController() : this(new RandomActorRepository())
        {
        }

        public ActorController(IRandomActorRepository ActorRepository)
        {
            this.actorRepository = ActorRepository;
        }

        // GET: /Actor/
        public ActionResult Index()
        {
            return View(actorRepository.All);
        }

        // GET: /Actor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomActor randomactor = actorRepository.Find(id.Value);
            if (randomactor == null)
            {
                return HttpNotFound();
            }
            return View(randomactor);
        }

        // GET: /Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Actor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RandomActorId,FirstName,LastName,Email,TwitterHandle")] RandomActor randomactor)
        {
            if (ModelState.IsValid)
            {
                actorRepository.InsertOrUpdate(randomactor);
                actorRepository.Save();
                return RedirectToAction("Index");
            }

            return View(randomactor);
        }

        // GET: /Actor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomActor randomactor = actorRepository.Find(id.Value);
            if (randomactor == null)
            {
                return HttpNotFound();
            }
            return View(randomactor);
        }

        // POST: /Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RandomActorId,FirstName,LastName,Email,TwitterHandle")] RandomActor randomactor)
        {
            if (ModelState.IsValid)
            {
                actorRepository.InsertOrUpdate(randomactor);
                actorRepository.Save();
                return RedirectToAction("Index");
            }
            return View(randomactor);
        }

        // GET: /Actor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomActor randomactor = actorRepository.Find(id.Value);
            if (randomactor == null)
            {
                return HttpNotFound();
            }
            return View(randomactor);
        }

        // POST: /Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            actorRepository.Delete(id);
            actorRepository.Save();
            return RedirectToAction("Index");
        }
    }
}

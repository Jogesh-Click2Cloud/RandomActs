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
    public class ActController : Controller
    {
		private readonly IRandomActRepository actRepository;

        public ActController() : this(new RandomActRepository())
        {
        }

        public ActController(IRandomActRepository RandomActRepository)
        {
            this.actRepository = RandomActRepository;
        }

        // GET: /Home/
        public ActionResult Index()
        {
            return View(actRepository.All);
        }

        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RandomActId,Title,Description,Location,Address,City,State,StartTime,EndTime,MaxActors")] RandomAct randomact)
        {
            if (ModelState.IsValid)
            {
                actRepository.InsertOrUpdate(randomact);
                actRepository.Save();
                return RedirectToAction("Index");
            }

            return View(randomact);
        }

        // GET: /Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomAct randomact = actRepository.Find(id.Value);
            if (randomact == null)
            {
                return HttpNotFound();
            }
            return View(randomact);
        }

        // POST: /Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RandomActId,Title,Description,Location,Address,City,State,StartTime,EndTime,MaxActors")] RandomAct randomact)
        {
            if (ModelState.IsValid)
            {
                actRepository.InsertOrUpdate(randomact);
                actRepository.Save();
                return RedirectToAction("Index");
            }
            return View(randomact);
        }

        // GET: /Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomAct randomact = actRepository.Find(id.Value);
            if (randomact == null)
            {
                return HttpNotFound();
            }
            return View(randomact);
        }

        // POST: /Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            actRepository.Delete(id);
            actRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }


    }
}

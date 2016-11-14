using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebResurection.Domain.Model;
using WebResurection.Repositories.EF;
using PagedList;
using System.Data.Entity.Infrastructure;
using WebResurection.Domain.Model.Characters;

namespace WebResurection.Controllers
{
    public class PlayerController : Controller
    {
        private WebResurection_Context db = new WebResurection_Context();

        // GET: Player
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var players = from p in db.Characters
                          .Include(x => x.ImplementedStats)
                          .Include(x => x.ImplementedStats) where p.isPlayer == true select p;

            //If searchstring changes then go to the first page 
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;


            if (!String.IsNullOrEmpty(searchString))
                players = players.Where(p => p.FirstName.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    players = players.OrderByDescending(p => p.FirstName);
                    break;
                case "Date":
                    players = players.OrderBy(p => p.CreateDate);
                    break;
                case "date_desc":
                    players = players.OrderByDescending(p => p.CreateDate);
                    break;
                default:
                    players = players.OrderBy(p => p.FirstName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(players.ToPagedList(pageNumber, pageSize));
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = db.Players.Find(id);
           
            //if (player == null)
            //{
            //    return HttpNotFound();
            //}
            Character character = db.Characters.Find(id);
            

            if (!character.isPlayer)
            {
                return HttpNotFound();
            }

            return View(character);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Character")] Player player, string command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string difficulty = Request.Params["difficulty"];

                    player.CreateDate = DateTime.Now;
                    player.Character.CreateDate = DateTime.Now;
                    player.Character.isPlayer = true;
                    player.Difficulty = difficulty;

                    db.Players.Add(player);
                    db.SaveChanges();

                    if(difficulty.ToUpper() == "EASY")
                        return RedirectToAction("Easy", player);
                    else if(difficulty.ToUpper() == "MEDIUM")
                        return RedirectToAction("Medium", player);
                    else if(difficulty.ToUpper() == "HARD")
                        return RedirectToAction("Hard", player);

                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                //Log the error
                //ModelState.AddModelError("", "Unable to save changes. Try agian, and if the problem persists call I.T");
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(player);
        }

        ////// GET: Player/Edit/5
        ////public ActionResult Edit(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    Player player = db.Players.Find(id);
        ////    if (player == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(player);
        ////}

        //// POST: Player/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Edit([Bind(Include = "ID,Name,HealthPoints,Damage")] Player player)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        db.Entry(player).State = EntityState.Modified;
        ////        db.SaveChanges();
        ////        return RedirectToAction("Index");
        ////    }
        ////    return View(player);
        ////}
        ////[HttpPost, ActionName("Edit")]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult EditPost(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    var studentToUpdate = db.Players.Find(id);
        ////    if (TryUpdateModel(studentToUpdate, "",
        ////       new string[] { "Name", "HealthPoints", "Damage" }))
        ////    {
        ////        try
        ////        {
        ////            db.SaveChanges();

        ////            return RedirectToAction("Index");
        ////        }
        ////        catch (RetryLimitExceededException /* dex */)
        ////        {
        ////            //Log the error (uncomment dex variable name and add a line here to write a log.
        ////            //ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        ////            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        ////        }
        ////    }
        ////    return View(studentToUpdate);
        ////}

        // GET: Player/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persist call I.T";
            }
            Character character = db.Characters.Find(id);
            //Player player = db.Players.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Character character = db.Characters.Find(id);
                //Player player = db.Players.Find(id);
                db.Characters.Remove(character);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /*dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                //return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        List<string> threeDSix = new List<string>(new string[] { "STRENGTH", "CONSTITUTION", "POWER", "DEXTERITY", "APPEARANCE" });
        List<string> twoDSixPlusSix = new List<string> (new string[]{"SIZE", "INTELLIGENCE"});
        List<string> threeDSixPlusThree = new List<string>(new string[] { "EDUCATION" });

        public ActionResult Easy(Player player)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Medium(Player player)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Hard(Player player)
        {
            Random rnd = new Random();
            foreach (var stat in db.Stats)
            {
                var impStat =  new ImplementedStat { Stat = stat, Modifier = 0, Value = 10, CreateDate = DateTime.Now, CharacterId = player.CharacterId };
                if (threeDSix.Contains(stat.Name.ToUpper()))
                    impStat.Value = Roll3D6(rnd);
                else if (twoDSixPlusSix.Contains(stat.Name.ToUpper()))
                    impStat.Value = Roll2D6Plus6(rnd);
                else if (threeDSixPlusThree.Contains(stat.Name.ToUpper()))
                    impStat.Value = Roll3d6Plus3(rnd);
                db.ImplementedStats.Add(impStat);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private double Roll3d6Plus3(Random rnd)
        {
            int result;

            result = rnd.Next(1, 7);
            result += rnd.Next(1, 7);
            result += rnd.Next(1, 7);
            result += 3;
            return result;
        }

        private double Roll2D6Plus6(Random rnd)
        {
            int result;

            result = rnd.Next(1, 7);
            result += rnd.Next(1, 7);
            result += 6;
            return result;
        }

        private double Roll3D6(Random rnd)
        {
            int result;

            result = rnd.Next(1, 7);
            result += rnd.Next(1, 7);
            result += rnd.Next(1, 7);
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using miVacationSurfer;

namespace miVacationSurfer.Controllers
{
    public class LocationReviewController : Controller
    {
        private miVacationSurferEntities db = new miVacationSurferEntities();

        // GET: LocationReview
        public ActionResult Index(string sortOrder)
        {
            ViewBag.RatingSortParm = String.IsNullOrEmpty(sortOrder) ? "rating_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.LocationSortParm = String.IsNullOrEmpty(sortOrder) ? "location_desc" : "";

            var locationReviews = from s in db.LocationReviews
                                  select s;

            switch(sortOrder)
            {
                case "rating_desc":
                    locationReviews = locationReviews.OrderByDescending(s => s.LocationRating);
                    break;

                case "Date":
                    locationReviews = locationReviews.OrderBy(s => s.LocationDate);
                    break;

                case "date_desc":
                    locationReviews = locationReviews.OrderByDescending(s => s.LocationDate);
                    break;

                case "location_desc":
                    locationReviews = locationReviews.OrderByDescending(s => s.Location.LocationName);
                    break;

                default:
                    locationReviews = locationReviews.OrderBy(s => s.LocationRating);
                    break;
            }

            return View(locationReviews.ToList());
        }

        // GET: LocationReview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationReview locationReview = db.LocationReviews.Find(id);
            if (locationReview == null)
            {
                return HttpNotFound();
            }
            return View(locationReview);
        }

        // GET: LocationReview/Create
        public ActionResult Create(int Id)
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName");
            return View();
        }

        // POST: LocationReview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocationRating,LocationDate,LocationPro,LocationCon,LocationReviewDetails,LocationId")] LocationReview locationReview)
        {
            if (ModelState.IsValid)
            {
                db.LocationReviews.Add(locationReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationReview.LocationId);
            return View(locationReview);
        }

        // GET: LocationReview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationReview locationReview = db.LocationReviews.Find(id);
            if (locationReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationReview.LocationId);
            return View(locationReview);
        }

        // POST: LocationReview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocationRating,LocationDate,LocationPro,LocationCon,LocationReviewDetails,LocationId")] LocationReview locationReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", locationReview.LocationId);
            return View(locationReview);
        }

        // GET: LocationReview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationReview locationReview = db.LocationReviews.Find(id);
            if (locationReview == null)
            {
                return HttpNotFound();
            }
            return View(locationReview);
        }

        // POST: LocationReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationReview locationReview = db.LocationReviews.Find(id);
            db.LocationReviews.Remove(locationReview);
            db.SaveChanges();
            return RedirectToAction("Index");
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
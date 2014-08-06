using miVacationSurfer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace miVacationSurfer.Controllers
{
    public class ReviewViewModelController : Controller

    {
        private miVacationSurferEntities db = new miVacationSurferEntities();
        // GET: ReviewViewModel
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: ReviewViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReviewViewModel/Create
        public ActionResult CreateReview()
        {
            ViewBag.Region = new SelectList(db.Regions, "Id", "RegionName");
            ViewBag.Location = new SelectList(db.Locations, "Id", "LocationName");
            ViewBag.ActivityType = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName");
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName");
            ViewBag.Activity = new SelectList(db.Activities, "Id", "ActivityName");
            return View();
        }

        // POST: ReviewViewModel/Create
        [HttpPost]
        public ActionResult CreateReview(miVacationSurfer.LocationReview model)
        {
           return View();
        }

        public PartialViewResult AddLocationReview(int id)
        {
            
            TempData["LocationId"] = id;
            TempData.Keep();
            return PartialView("_LocationReview");
        }

        

        // GET: ReviewViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReviewViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReviewViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

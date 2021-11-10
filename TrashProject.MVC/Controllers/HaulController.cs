using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashProject.Data;
using TrashProject.Models.HaulModels;
using TrashProject.Services;

namespace TrashProject.MVC.Controllers
{
    public class HaulController : Controller
    {
        // GET: Haul
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HaulService(userId);
            var model = service.GetHaul();
            return View(model);
        }

        public ActionResult CreateView()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HaulService(userId);
            var model = service.CreateHaulView();
            return View(model);
        }

        //Add method here VVVV
        //Get
        public ActionResult Create()
        {
            
            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HaulCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateHaulService();

            if (service.CreateHaul(model))
            {
                TempData["SaveResult"] = "Your Haul was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Haul could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateHaulService();
            var model = svc.GetHaulById(id);

            return View(model);
        }

        private HaulService CreateHaulService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HaulService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateHaulService();
            var detail = service.GetHaulById(id);
            var model =
                new HaulEdit
                {
                    HaulId = detail.HaulId,
                    CompactorId = detail.CompactorId,
                    PropertyContactId = detail.PropertyContactId,
                    PropertyId = detail.PropertyId,
                    HaulerInfoId = detail.HaulerInfoId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HaulEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HaulId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHaulService();

            if (service.UpdateHaul(model))
            {
                TempData["SaveResult"] = "Your Haul was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Haul could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateHaulService();
            var model = svc.GetHaulById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHaulService();

            service.DeleteHaul(id);

            TempData["SaveResult"] = "Your Haul was deleted";

            return RedirectToAction("Index");
        }
    }
}
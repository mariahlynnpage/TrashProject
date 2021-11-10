using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashProject.Models.HaulerInfoModels;
using TrashProject.Services;

namespace TrashProject.MVC.Controllers
{
    public class HaulerInfoController : Controller
    {
        // GET: HaulerInfo
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HaulerInfoService(userId);
            var model = service.GetHaulerInfo();
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
        public ActionResult Create(HaulerInfoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateHaulerInfoService();

            if (service.CreateHaulerInfo(model))
            {
                TempData["SaveResult"] = "Your HaulerInfo was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "HaulerInfo could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateHaulerInfoService();
            var model = svc.GetHaulerInfoById(id);

            return View(model);
        }

        private HaulerInfoService CreateHaulerInfoService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HaulerInfoService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateHaulerInfoService();
            var detail = service.GetHaulerInfoById(id);
            var model =
                new HaulerInfoEdit
                {
                    HaulerId = detail.HaulerId,
                    HaulerName = detail.HaulerName,
                    HaulerEmail = detail.HaulerEmail,
                    HaulerPhoneNumber = detail.HaulerPhoneNumber
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HaulerInfoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HaulerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHaulerInfoService();

            if (service.UpdateHaulerInfo(model))
            {
                TempData["SaveResult"] = "Your HaulerInfo was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your HaulerInfo could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateHaulerInfoService();
            var model = svc.GetHaulerInfoById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHaulerInfoService();

            service.DeleteHaulerInfo(id);

            TempData["SaveResult"] = "Your HaulerInfo was deleted";

            return RedirectToAction("Index");
        }
    }
}
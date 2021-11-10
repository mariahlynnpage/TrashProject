using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashProject.Data;
using TrashProject.Models.CompactorModels;
using TrashProject.Services;

namespace TrashProject.MVC.Controllers
{
    [Authorize]
    public class CompactorController : Controller
    {
        // GET: Compactor
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CompactorService(userId);
            var model = service.GetCompactors();
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
        public ActionResult Create(CompactorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCompactorService();

            if (service.CreateCompactor(model))
            {
                TempData["SaveResult"] = "Your Compactor was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Compactor could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCompactorService();
            var model = svc.GetCompactorById(id);

            return View(model);
        }

        private CompactorService CreateCompactorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CompactorService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCompactorService();
            var detail = service.GetCompactorById(id);
            var model =
                new CompactorEdit
                {
                    CompactorId = detail.CompactorId,
                    CompactorName = detail.CompactorName,
                    IsContaminated = detail.IsContaminated,
                    IsTrash = detail.IsTrash,
                    IsDryWaste = detail.IsDryWaste
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompactorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CompactorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCompactorService();

            if (service.UpdateCompactor(model))
            {
                TempData["SaveResult"] = "Your Compactor was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Compactor could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCompactorService();
            var model = svc.GetCompactorById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCompactorService();

            service.DeleteCompactor(id);

            TempData["SaveResult"] = "Your Compactor was deleted";

            return RedirectToAction("Index");
        }
    }
}
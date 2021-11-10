using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashProject.Models.PropertyModels;
using TrashProject.Services;

namespace TrashProject.MVC.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            var model = service.GetProperties();
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
        public ActionResult Create(PropertyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePropertyService();

            if (service.CreateProperty(model))
            {
                TempData["SaveResult"] = "Your Property was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Property could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        private PropertyService CreatePropertyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePropertyService();
            var detail = service.GetPropertyById(id);
            var model =
                new PropertyEdit
                {
                    PropertyId = detail.PropertyId,
                    PropertyName = detail.PropertyName,
                    Address = detail.Address
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PropertyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PropertyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePropertyService();

            if (service.UpdateProperty(model))
            {
                TempData["SaveResult"] = "Your Property was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Property could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePropertyService();

            service.DeleteProperty(id);

            TempData["SaveResult"] = "Your Property was deleted";

            return RedirectToAction("Index");
        }
    }
}
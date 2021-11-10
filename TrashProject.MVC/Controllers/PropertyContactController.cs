using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashProject.Models.PropertyContactModels;
using TrashProject.Services;

namespace TrashProject.MVC.Controllers
{
    public class PropertyContactController : Controller
    {
        // GET: PropertyContact
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyContactService(userId);
            var model = service.GetPropertyContacts();
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
        public ActionResult Create(PropertyContactCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePropertyContactService();

            if (service.CreatePropertyContact(model))
            {
                TempData["SaveResult"] = "Your PropertyContact was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "PropertyContact could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePropertyContactService();
            var model = svc.GetPropertyContactById(id);

            return View(model);
        }

        private PropertyContactService CreatePropertyContactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyContactService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePropertyContactService();
            var detail = service.GetPropertyContactById(id);
            var model =
                new PropertyContactEdit
                {
                    PropertyContactId = detail.PropertyContactId,
                    PropContactEmail = detail.PropContactEmail,
                    PropContactPosition = detail.PropContactPosition,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    PropContactPhoneNumber = detail.PropContactPhoneNumber
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PropertyContactEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PropertyContactId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePropertyContactService();

            if (service.UpdatePropertyContact(model))
            {
                TempData["SaveResult"] = "Your PropertyContact was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your PropertyContact could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePropertyContactService();
            var model = svc.GetPropertyContactById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePropertyContactService();

            service.DeletePropertyContact(id);

            TempData["SaveResult"] = "Your PropertyContact was deleted";

            return RedirectToAction("Index");
        }
    }
}
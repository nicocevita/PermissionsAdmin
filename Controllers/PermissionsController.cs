using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mapster;
using PermissionsAdmin.Data;
using PermissionsAdmin.Models;
using PermissionsAdmin.Repository;

namespace PermissionsAdmin.Controllers
{
    public class PermissionsController : Controller
    {
        private PermissionsRepository _permissionsRepository = new PermissionsRepository();
        private PermissionTypeRepository _permissionTypeRepository = new PermissionTypeRepository();



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<Permissions> permissions = _permissionsRepository.GetList();
            return View(permissions.Adapt <List<PermissionViewModel>>());
        }

  
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissions permissions = _permissionsRepository.GetPermissionsById(id.Value);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            return View(permissions.Adapt<PermissionViewModel>());
        }

   
        public ActionResult Create()
        {
            ViewBag.PermissionType = new SelectList(_permissionTypeRepository.GetList(), "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeFirstname,EmployeeLastname,PermissionType,PermissionDate")] Permissions permissions)
        {
            if (ModelState.IsValid)
            {
                _permissionsRepository.Create(permissions);

                return RedirectToAction("List");
            }

            ViewBag.PermissionType = new SelectList(_permissionTypeRepository.GetList(), "Id", "Description", permissions.PermissionTypes);
            return View(permissions.Adapt<PermissionViewModel>());
        }

   
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);                
            }
            Permissions permissions = _permissionsRepository.GetPermissionsById(id.Value);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionType = new SelectList(_permissionTypeRepository.GetList(), "Id", "Description", permissions.PermissionTypes);

            return View(permissions.Adapt<PermissionViewModel>());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Permissions permissions)
        {
            if (ModelState.IsValid)
            {
                _permissionsRepository.Edit(permissions);
            }
            ViewBag.PermissionType = new SelectList(_permissionTypeRepository.GetList(), "Id", "Description", permissions.PermissionTypes);
            return View(permissions.Adapt<PermissionViewModel>());
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissions permissions = _permissionsRepository.GetPermissionsById(id.Value);
            if (permissions == null)
            {
                return HttpNotFound();
            }
            return View(permissions.Adapt<PermissionViewModel>());
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _permissionsRepository.Remove(id);
            return RedirectToAction("List");
        }

    }
}

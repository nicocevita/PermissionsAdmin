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


        /// <summary>
        /// Index view
        /// </summary>
        /// <returns>view</returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// List the permissions
        /// </summary>
        /// <returns>view list</returns>
        public ActionResult List()
        {
            List<Permissions> permissions = _permissionsRepository.GetList();
            return View(permissions.Adapt<List<PermissionViewModel>>());
        }

        /// <summary>
        ///// Show a permission Detail
        /// </summary>
        /// <param name="id">Permission id</param>
        /// <returns>view</returns>
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

        /// <summary>
        /// Create view
        /// </summary>
        /// <returns>view<returns>
        public ActionResult Create()
        {
            ViewBag.PermissionType = new SelectList(_permissionTypeRepository.GetList(), "Id", "Description");
            return View();
        }
        /// <summary>
        /// Create a new permission
        /// </summary>
        /// <param name="permissions">new permissions</param>
        /// <returns>view</returns>
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

        /// <summary>
        /// Edit view
        /// </summary>
        /// <param name="id">permission id</param>
        /// <returns>view</returns>
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

        /// <summary>
        /// Edit a permission
        /// </summary>
        /// <param name="permissions">permission</param>
        /// <returns>view</returns>
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

        /// <summary>
        /// Delete view
        /// </summary>
        /// <param name="id">permission id</param>
        /// <returns>view</returns>
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

        /// <summary>
        /// Delete a permission
        /// </summary>
        /// <param name="id">permissions id</param>
        /// <returns>list view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _permissionsRepository.Remove(id);
            return RedirectToAction("List");
        }

    }
}

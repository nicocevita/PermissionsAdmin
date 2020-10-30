using PermissionsAdmin.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PermissionsAdmin.Repository
{
    public class PermissionsRepository
    {
        private AdminPermissionsEntities _db = new AdminPermissionsEntities();
        /// <summary>
        /// Get permission by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee permission</returns>
        public Permissions GetPermissionsById(int id)
        {
            Permissions result = _db.Permissions.Include("PermissionTypes").Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public List<Permissions> GetList()
        {
            List<Permissions> result = _db.Permissions.Include("PermissionTypes").ToList();
            return result;
        }

        public void Create(Permissions item)
        {
            Permissions result = _db.Permissions.Add(item);
            _db.SaveChanges();
        }

        public void Edit(Permissions item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(int id)
        {
            Permissions permissions = GetPermissionsById(id);
            _db.Permissions.Remove(permissions);
            _db.SaveChanges();
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
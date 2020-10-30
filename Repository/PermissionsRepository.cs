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
        /// <summary>
        /// database connection 
        /// </summary>
        private AdminPermissionsEntities _db = new AdminPermissionsEntities();
        /// <summary>
        /// Get permission by Id
        /// </summary>
        /// <param name="id">permissions id</param>
        /// <returns>Employee permission</returns>
        public Permissions GetPermissionsById(int id)
        {
            Permissions result = _db.Permissions.Include("PermissionTypes").Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// get a permissions list from databese
        /// </summary>
        /// <returns>permissions list</returns>
        public List<Permissions> GetList()
        {
            List<Permissions> result = _db.Permissions.Include("PermissionTypes").ToList();
            return result;
        }
        /// <summary>
        /// Create a permission into database
        /// </summary>
        /// <param name="item">permission item</param>
        public void Create(Permissions item)
        {
            Permissions result = _db.Permissions.Add(item);
            _db.SaveChanges();
        }
        /// <summary>
        /// Edit a permission in the database
        /// </summary>
        /// <param name="item">permission item</param>
        public void Edit(Permissions item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
        /// <summary>
        /// Remove a permission in the database
        /// </summary>
        /// <param name="id">permission id</param>
        public void Remove(int id)
        {
            Permissions permissions = GetPermissionsById(id);
            _db.Permissions.Remove(permissions);
            _db.SaveChanges();
        }
    }
}
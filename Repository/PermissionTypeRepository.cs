using PermissionsAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermissionsAdmin.Repository
{
    public class PermissionTypeRepository
    {
        private AdminPermissionsEntities _db = new AdminPermissionsEntities();

        /// <summary>
        /// Get Permission Types list
        /// </summary>
        /// <returns></returns>
        public List<PermissionTypes> GetList()
        {
            List<PermissionTypes> result = _db.PermissionTypes.ToList();
            return result;
        }
    }
}
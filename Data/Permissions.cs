//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PermissionsAdmin.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Permissions
    {
        public int Id { get; set; }
        public string EmployeeFirstname { get; set; }
        public string EmployeeLastname { get; set; }
        public int PermissionType { get; set; }
        public System.DateTime PermissionDate { get; set; }
    
        public virtual PermissionTypes PermissionTypes { get; set; }
    }
}

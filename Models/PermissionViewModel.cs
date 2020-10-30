using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermissionsAdmin.Models
{
    public class PermissionViewModel
    {
        public PermissionViewModel() { }
        public int Id { get; set; }
        [Required(ErrorMessage ="First name required")]
        [Display(Name = "First Name")]
        public string EmployeeFirstname { get; set; }
        [Required(ErrorMessage = "Last name required")]
        [Display(Name = "Last Name")]
        public string EmployeeLastname { get; set; }
        [Required]
        [Display(Name = "Permission Type")]
        public int PermissionType { get; set; }
        [Required(ErrorMessage = "Date format should be dd/MM/yyyy")]
        [Display(Name = "Permission Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PermissionDate { get; set; }
        public virtual PermissionTypeViewModel PermissionTypes { get; set; }
    }
}
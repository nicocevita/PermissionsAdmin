using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermissionsAdmin.Models
{
    public class PermissionTypeViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
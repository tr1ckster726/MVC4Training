using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Models
{
    public class CreateEmployeeViewModel
    {
        // This will hide the value and the display from the user on the View
        [Key]
        [HiddenInput(DisplayValue=false)]
        public int DepartmentId { get; set; }

        // Make sure that this is populated
        [Required]
        public string Name { get; set; }        

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Department
{
    public class DepartmentModel : IDepartmentModel
    {
        public int DepartmentID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Department name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Department name must be between 5 and 20 characters")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "URL is required")]
        public string URL { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string CityLocation { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string StateLocation { get; set; }
    }
}

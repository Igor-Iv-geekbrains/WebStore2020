using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webstore.Models
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Age is a required field. ")]
        [Display(Name = "Age")] //Display this
        public int Age { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is a required field. ")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "SurName is a required field. ")]
        [StringLength(maximumLength:100, MinimumLength =2,ErrorMessage ="***")]
        public string SurName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Patronymic is a required field. ")]
        public string Patronymic { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Position is a required field. ")]
        public string Position { get; set; }

    }
}


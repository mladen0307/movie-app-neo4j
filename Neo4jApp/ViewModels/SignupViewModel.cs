using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.ViewModels
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(16, ErrorMessage = "Username must be between 3 and 16 characters", MinimumLength = 3)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password must have at least 7 characters", MinimumLength = 7)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Full name")]
        [StringLength(26, ErrorMessage = "Full name must be between 3 and 26 characters", MinimumLength = 3)]
        public string FullName { get; set; }
    }
}

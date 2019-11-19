﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]        
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UserMVC.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Username is Missing")]
        [Display(Name = "Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is Missing")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}

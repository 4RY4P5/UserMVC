using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UserMVC.Models.Entities
{
    public class UserDetail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is empty")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is empty")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Department is empty")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Address is empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Address is empty")]
        public bool Admin { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
    }
}

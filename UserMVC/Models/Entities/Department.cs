using System;
using System.Collections.Generic;

#nullable disable

namespace UserMVC.Models.Entities
{
    public partial class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is empty")
        public string Name { get; set; }
    }
}

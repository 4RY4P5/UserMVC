using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMVC.Models.Entities;

namespace UserMVC.ViewModel
{
    public class UserDepartment
    {
        public IEnumerable<Department> Departments { get; set; }

        public UserDetail userdetail { get; set; }
    }
}

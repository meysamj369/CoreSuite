using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreSuite.Models
{
    [Table("Tbl_Department")]
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }

    }
}
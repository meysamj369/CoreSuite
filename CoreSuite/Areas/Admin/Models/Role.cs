using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CoreSuite.Models
{
    [Table("Tbl_Role")]
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleTitle { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CoreSuite.Models
{
    [Table("Tbl_UserAccessModual")]
    public class UserAccessModual
    {
        public int UserAccessModuleId { get; set; }
        public int UserId { get; set; }
        public int ModualId { get; set; }
        public bool CanEnter { get; set; }
    }
}
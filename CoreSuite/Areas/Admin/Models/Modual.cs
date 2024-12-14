using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CoreSuite.Models
{
    [Table("Tbl_Moduals")]
    public class Modual
    {
        public int ModualId { get; set; }
        public string ModualName { get; set; }
    }
}
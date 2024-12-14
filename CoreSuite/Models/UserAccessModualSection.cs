using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CoreSuite.Models
{
    [Table("Tbl_UserAccessModualSection")]
    public class UserAccessModualSection
    {
        public int UserAccessModulaSectionId { get; set; }
        public int UserId { get; set; }
        public int ModualId { get; set; }
        public string SectionCode { get; set; }
        public bool CanEnter { get; set; }
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }


    }



}


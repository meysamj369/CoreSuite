using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CoreSuite.Models
{
    [Table("Tbl_ModualSection")]
    public class ModualSection
    {
        public int ModualSectionId { get; set; }
        public int ModualId { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }

    }
}
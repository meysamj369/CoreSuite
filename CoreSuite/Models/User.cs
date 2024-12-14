﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoreSuite.Models
{

    [Table("Tbl_User")]
    public class User
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Family  { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool Active { get; set; }
        public DateTime RegDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
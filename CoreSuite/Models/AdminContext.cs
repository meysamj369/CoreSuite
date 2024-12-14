using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoreSuite.Models
{
    public class AdminContext:DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet <UserRole> UserRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Modual> Moduals { get; set; }
        public DbSet<ModualSection> ModualSections { get; set; }
        public DbSet<UserAccessModual> UserAccessModuals { get; set; }
        public DbSet<UserAccessModualSection> UserAccessModualSections { get; set; }



    }
}
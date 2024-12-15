using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoreSuite.Models
{
    public class AdminContext : DbContext
    {


        public AdminContext() : base("CoreSuiteDBContext")
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Modual> Moduals { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<UserAccessModual> UserAccessModuals { get; set; }
        public DbSet<UserAccessModualSection> UserAccessModualSections { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // تنظیمات Fluent API اینجا انجام می‌شود
            #region User Table

            modelBuilder.Entity<User>()
            .HasKey(u => u.UserId)
            .Property(u => u.Name);
            //.HasMaxLength(100);
            // طول ستون
            modelBuilder.Entity<User>()
           .Property(u => u.Family)
           .IsRequired()
            .HasMaxLength(100);

            modelBuilder.Entity<User>()
           .Property(u => u.UserName)
           .IsRequired()
           .HasMaxLength(50);

            modelBuilder.Entity<User>()
           .Property(u => u.Password)
           .IsRequired()
           .HasMaxLength(50);


            modelBuilder.Entity<User>()
                .Property(u => u.RePassword)
                .IsRequired()   // مقدار اجباری
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
.Property(u => u.Active)
.IsRequired();
            //.HasColumnAnnotation("Default", true);
            modelBuilder.Entity<User>()
                .Property(u => u.RegDate)
                .IsRequired();   // مقدار اجباری


            modelBuilder.Entity<User>()
           .Property(u => u.RoleId)
           .IsRequired();   // مقدار اجباری


            // تعریف کلید های خارجی و روابط بین آنها

            modelBuilder.Entity<User>()
                .Property(u => u.DepartmentId)
                .IsRequired();   // مقدار اجباری

            // تعریف رابطه بین User و Department
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Department) // هر کاربر باید به یک واحد تعلق داشته باشد
                .WithMany(d => d.Users)         // هر واحد می‌تواند چندین کاربر داشته باشد
                .HasForeignKey(u => u.DepartmentId); // کلید خارجی در جدول User



            // تعریف رابطه بین User و Role
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Role) // هر کاربر یک رول داشته باشد
                .WithMany(d => d.Users)         // هر رول می‌تواند چندین کاربر داشته باشد
                .HasForeignKey(u => u.RoleId); // کلید خارجی در جدول User

            // تعریف رابطه بین UserAccessModual و User
            modelBuilder.Entity<UserAccessModual>()
                .HasRequired(uam => uam.User) // هر دسترسی باید به یک کاربر تعلق داشته باشد
                .WithMany(u => u.UserAccessModuals) // هر کاربر می‌تواند چندین دسترسی داشته باشد
                .HasForeignKey(uam => uam.UserId) // کلید خارجی UserId
                .WillCascadeOnDelete(false); // حذف Cascade غیرفعال

            // تعریف رابطه بین UserAccessModual و Modual
            modelBuilder.Entity<UserAccessModual>()
                .HasRequired(uam => uam.Modual) // هر دسترسی باید به یک ماژول تعلق داشته باشد
                .WithMany(m => m.UserAccessModuals) // هر ماژول می‌تواند چندین دسترسی داشته باشد
                .HasForeignKey(uam => uam.ModualId) // کلید خارجی ModualId
                .WillCascadeOnDelete(false); // حذف Cascade غیرفعال


            // رابطه بین UserAccessModulaSection و User
            modelBuilder.Entity<UserAccessModualSection>()
                .HasRequired(uams => uams.User)
                .WithMany(u => u.UserAccessModualSections)
                .HasForeignKey(uams => uams.UserId)
                .WillCascadeOnDelete(false);

            // رابطه بین UserAccessModulaSection و Modual
            modelBuilder.Entity<UserAccessModualSection>()
                .HasRequired(uams => uams.Modual)
                .WithMany(m => m.UserAccessModualSections)
                .HasForeignKey(uams => uams.ModualId)
                .WillCascadeOnDelete(false);

            // رابطه بین UserAccessModulaSection و Section
            modelBuilder.Entity<UserAccessModualSection>()
                .HasRequired(uams => uams.Section)
                .WithMany(s => s.UserAccessModualSections)
                .HasForeignKey(uams => uams.SectionCode)
                .WillCascadeOnDelete(false);

            // رابطه بین Section و Modual
            modelBuilder.Entity<Section>()
                .HasRequired(s => s.Modual)
                .WithMany(m => m.Sections)
                .HasForeignKey(s => s.ModualId)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<User>()
            .ToTable("Tbl_Users");



            #endregion

            #region Role Table

            modelBuilder.Entity<Role>()
            .HasKey(u => u.RoleId)
            .Property(u => u.RoleTitle)
            .HasMaxLength(50);

            modelBuilder.Entity<User>()
            .ToTable("Tbl_Role");


            #endregion

            #region Department Table

            modelBuilder.Entity<Department>()
            .HasKey(u => u.DepartmentId)
            .Property(u => u.DepartmentTitle)
            .HasMaxLength(50);

            modelBuilder.Entity<User>()
            .ToTable("Tbl_Department");

            #endregion


            #region Modual Table

            modelBuilder.Entity<Modual>()
            .HasKey(u => u.ModualId)
            .Property(u => u.ModualName)
            .HasMaxLength(50);

            modelBuilder.Entity<User>()
            .ToTable("Tbl_Modual");

            #endregion

            #region Section Table

            modelBuilder.Entity<Section>()
                .Property(s => s.SectionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //.HasKey(u => u.SectionId);

            modelBuilder.Entity<Section>()
            .Property(u => u.ModualId)
             .IsRequired();   // مقدار اجباری

            // تعریف SectionCode به عنوان کلید اصلی
            modelBuilder.Entity<Section>()
                .HasKey(s => s.SectionCode); // کلید اصلی

            // تنظیم ویژگی‌های SectionCode
            modelBuilder.Entity<Section>()
                .Property(s => s.SectionCode)
                .HasMaxLength(50) // طول رشته
                .IsRequired();    // اجباری بودن

            modelBuilder.Entity<Section>()
            .Property(u => u.SectionName)
            .HasMaxLength(50)
            .IsRequired();   // مقدار اجباری

            modelBuilder.Entity<User>()
            .ToTable("Tbl_Sction");

            #endregion

            #region UserAccessModual Table


            modelBuilder.Entity<UserAccessModual>()
            .HasKey(u => u.UserAccessModuleId);

            modelBuilder.Entity<UserAccessModual>()
            .Property(u => u.UserId)
             .IsRequired();   // مقدار اجباری

            modelBuilder.Entity<UserAccessModual>()
            .Property(u => u.ModualId)
             .IsRequired();   // مقدار اجباری

            modelBuilder.Entity<UserAccessModual>()
            .Property(u => u.CanEnter);
            //.IsRequired();   // مقدار اجباری

            modelBuilder.Entity<User>()
            .ToTable("Tbl_UserAccessModual");


            #endregion

            #region UserAccessModualSection Table

            modelBuilder.Entity<UserAccessModualSection>()
            .HasKey(u => u.UserAccessModulaSectionId);

            modelBuilder.Entity<UserAccessModualSection>()
            .Property(u => u.UserId)
             .IsRequired();   // مقدار اجباری

            modelBuilder.Entity<UserAccessModualSection>()
            .Property(u => u.ModualId)
             .IsRequired();   // مقدار اجباری

            modelBuilder.Entity<UserAccessModualSection>()
            .Property(u => u.SectionCode)
            .IsRequired();

            modelBuilder.Entity<UserAccessModualSection>()
            .Property(u => u.CanEnter);

            modelBuilder.Entity<UserAccessModualSection>()
            .Property(u => u.CanRead);

            modelBuilder.Entity<UserAccessModualSection>()
            .Property(u => u.CanEdit);

            modelBuilder.Entity<UserAccessModualSection>()
            .Property(u => u.CanDelete);

            modelBuilder.Entity<UserAccessModualSection>()
            .Property(u => u.CanCreate);

            modelBuilder.Entity<User>()
            .ToTable("Tbl_UserAccessModualSection");

            #endregion



            base.OnModelCreating(modelBuilder);




        }





    }

}
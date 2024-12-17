namespace CoreSuite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDesignOfSectionandUserAccessModualTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tbl_UserAccessModualSection");
            AlterColumn("dbo.Tbl_Users", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tbl_Users", "Family", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tbl_UserAccessModual", "CanEnter", c => c.Boolean());
            AlterColumn("dbo.Tbl_Section", "SectionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanEnter", c => c.Boolean());
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanRead", c => c.Boolean());
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanCreate", c => c.Boolean());
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanEdit", c => c.Boolean());
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanDelete", c => c.Boolean());
            AddPrimaryKey("dbo.Tbl_UserAccessModualSection", new[] { "UserId", "ModualId", "SectionCode" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tbl_UserAccessModualSection");
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanEdit", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanCreate", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanRead", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_UserAccessModualSection", "CanEnter", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Section", "SectionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tbl_UserAccessModual", "CanEnter", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Users", "Family", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tbl_Users", "Name", c => c.String());
            AddPrimaryKey("dbo.Tbl_UserAccessModualSection", "UserAccessModulaSectionId");
        }
    }
}

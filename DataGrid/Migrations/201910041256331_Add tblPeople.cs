namespace DataGrid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtblPeople : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPeople",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Photo = c.String(maxLength: 255),
                        Sex = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblPeople");
        }
    }
}

namespace personal_inforamtion_system_new.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personlandaddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressType = c.String(nullable: false),
                        Province = c.String(nullable: false),
                        city = c.String(nullable: false),
                        Ward = c.String(nullable: false),
                        Tole = c.String(nullable: false),
                        personalinfo_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.personalinfoes", t => t.personalinfo_PersonId)
                .Index(t => t.personalinfo_PersonId);
            
            CreateTable(
                "dbo.personalinfoes",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Salutation = c.String(nullable: false),
                        FirstName = c.String(),
                        Email = c.String(nullable: false),
                        Age = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Education = c.String(nullable: false),
                    Nationality= c.String(nullable: false),

                    AddressId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "personalinfo_PersonId", "dbo.personalinfoes");
            DropIndex("dbo.Addresses", new[] { "personalinfo_PersonId" });
            DropTable("dbo.personalinfoes");
            DropTable("dbo.Addresses");
        }
    }
}

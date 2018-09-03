namespace MovieRentalMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubScribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubsribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubsribedToNewsLetter");
        }
    }
}

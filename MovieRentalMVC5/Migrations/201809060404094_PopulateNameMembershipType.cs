namespace MovieRentalMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name ='Pay as you go' where id =1");
            Sql("Update MembershipTypes set Name ='Monthly' where id =2");
            Sql("Update MembershipTypes set Name ='Quaterly' where id =3");
            Sql("Update MembershipTypes set Name ='Yearly' where id =4");
        }
        
        public override void Down()
        {
        }
    }
}

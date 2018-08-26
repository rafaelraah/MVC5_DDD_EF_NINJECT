namespace MVC5_DDD_EF_NINJECT.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeDaMigracao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "SenhaKey", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "SenhaKey");
        }
    }
}

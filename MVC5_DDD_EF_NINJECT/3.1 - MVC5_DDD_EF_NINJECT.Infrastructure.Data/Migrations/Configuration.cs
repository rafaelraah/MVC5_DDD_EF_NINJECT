namespace MVC5_DDD_EF_NINJECT.Infrastructure.Data.Migrations
{
    using MVC5_DDD_EF_NINJECT.Infrastructure.Data.Initializer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC5_DDD_EF_NINJECT.Infrastructure.Data.Context.ContextoBanco>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC5_DDD_EF_NINJECT.Infrastructure.Data.Context.ContextoBanco context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.PerfisUsuarios.Where(x => x.NomePerfil == "Administrador Master").Count() == 0)
            {
                UserDatabaseInitializer.GetPerfisUsuarios().ForEach(c => context.PerfisUsuarios.Add(c));
            }

            //Delete all stored procs, views
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", ""), "Sql\\Seed"), "*.sql"))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
            }

            //Add Stored Procedures
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", ""), "Sql\\StoredProcs"), "*.sql"))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
            }
        }
    }
}


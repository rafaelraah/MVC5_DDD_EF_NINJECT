using MVC5_DDD_EF_NINJECT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_DDD_EF_NINJECT.Infrastructure.Data.Context
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco() : base("BancoProjetoDDD")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PerfilUsuario> PerfisUsuarios { get; set; }
        public DbSet<ModulosAcesso> ModulosAcessos { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remover a pluralização, ou seja, não converter o nome 'Usuario' em 'Usuarios'
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //não remover as informações referenciadas na relação de 1 para N
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //não remover as informações referenciadas na relação de N para N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Quando o nome da propriedade + Id na frente for encontrado, significa que é a chave primária
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            //Mapear as propriedades string como Varchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Remover que mapeie como Varchar(MAX), e colocar maxlength 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Colocar mais de 100 caracteres nas propriedades que contenham 'Descricao'
            modelBuilder.Properties<string>().Where(p => p.Name.Contains("Descricao")).Configure(p => p.HasMaxLength(400));
            
            //Colocar apenas 2 caracteres nas propriedades que contenham 'UF'
            modelBuilder.Properties<string>().Where(p => p.Name.Contains("UF")).Configure(p => p.HasMaxLength(2));

            base.OnModelCreating(modelBuilder);
        }
    }
}

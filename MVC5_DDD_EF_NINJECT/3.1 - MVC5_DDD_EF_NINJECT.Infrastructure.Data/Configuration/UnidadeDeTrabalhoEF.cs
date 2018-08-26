using CommonServiceLocator;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Instrastructure;
using MVC5_DDD_EF_NINJECT.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_DDD_EF_NINJECT.Infrastructure.Data.Configuration
{
    public class UnidadeDeTrabalhoEF : IUnidadeDeTrabalho
    {
        private ContextoBanco _contexto;

        public void Iniciar()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>() as GerenciadorDeRepositorio;
            _contexto = gerenciador.Contexto;
        }

        public void Persistir()
        {
            _contexto.SaveChanges();
        }
    }
}

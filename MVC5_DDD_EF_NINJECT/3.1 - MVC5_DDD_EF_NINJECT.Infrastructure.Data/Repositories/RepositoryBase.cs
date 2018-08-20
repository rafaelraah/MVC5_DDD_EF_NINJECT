using CommonServiceLocator;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Instrastructure;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Repositories;
using MVC5_DDD_EF_NINJECT.Infrastructure.Data.Configuration;
using MVC5_DDD_EF_NINJECT.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_DDD_EF_NINJECT.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
    {

        protected readonly ContextoBanco _contexto;

        public RepositoryBase()
        {
            var gerenciador = (GerenciadorDeRepositorio)ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>();
            _contexto = gerenciador.Contexto; //Gerenciar o contexto com Singleton
        }

        public void Alterar(TEntidade obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public void Inserir(TEntidade obj)
        {
            _contexto.Set<TEntidade>().Add(obj);
        }

        public TEntidade RecuperarPorID(int id)
        {
            return _contexto.Set<TEntidade>().Find(id);
        }

        public IList<TEntidade> RecuperarTodos()
        {
            return _contexto.Set<TEntidade>().ToList();
        }

        public void Remover(TEntidade obj)
        {
            _contexto.Set<TEntidade>().Remove(obj);
        }

        public void Remover(int id)
        {
            TEntidade obj = RecuperarPorID(id);
            Remover(obj);
        }
    }
}

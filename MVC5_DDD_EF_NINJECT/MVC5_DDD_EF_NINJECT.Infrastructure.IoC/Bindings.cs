using CommonServiceLocator.SimpleInjectorAdapter;
using Microsoft.Practices.ServiceLocation;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Domain;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Instrastructure;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Repositories;
using MVC5_DDD_EF_NINJECT.Domain.Services;
using MVC5_DDD_EF_NINJECT.Infrastructure.Data.Configuration;
using MVC5_DDD_EF_NINJECT.Infrastructure.Data.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_DDD_EF_NINJECT.Infrastructure.IoC
{
    public class Bindings
    {
        public static void Start(Container container)
        {
            //Infraestrutura
            container.Register<IGerenciadorDeRepositorio, GerenciadorDeRepositorio>();
            container.Register<IUnidadeDeTrabalho, UnidadeDeTrabalhoEF>();
            container.Register(typeof(IRepositorioBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeUsuarios), typeof(RepositorioDeUsuario), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDePerfilDoUsuario), typeof(RepositorioDePerfilDeUsuario), Lifestyle.Scoped);

            //Dominio
            container.Register(typeof(IServicoDeUsuarioDomain), typeof(ServicoDeUsuarioDomain));

            //Aplicação
            //Todo

            //Service Locator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}

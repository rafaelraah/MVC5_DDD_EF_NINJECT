using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Instrastructure;
using MVC5_DDD_EF_NINJECT.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVC5_DDD_EF_NINJECT.Infrastructure.Data.Configuration
{
    public class GerenciadorDeRepositorio : IGerenciadorDeRepositorio
    {
        public const string ContextoHttp = "ContextoHttp";
        public ContextoBanco Contexto
        {
            get
            {
                if(HttpContext.Current.Items[ContextoHttp] == null)
                {
                    HttpContext.Current.Items[ContextoHttp] = new ContextoBanco();
                }
                return HttpContext.Current.Items[ContextoHttp] as ContextoBanco;
            }
        }

        public void Finalizar()
        {
            if(HttpContext.Current.Items[ContextoHttp] != null)
            {
                (HttpContext.Current.Items[ContextoHttp] as ContextoBanco).Dispose();
            }
        }

    }
}

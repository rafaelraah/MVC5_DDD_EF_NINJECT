using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_DDD_EF_NINJECT.Domain.Interfaces.Instrastructure
{
    public interface IUnidadeDeTrabalho
    {
        void Iniciar();
        void Persistir();
    }
}

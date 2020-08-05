using Financeiro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.Repository
{
    interface ITituloRepository
    {
        int Add(Titulo titulo);
        List<Titulo> GetTitulo();
        Titulo Get(int id);
        int Edit(Titulo produto);
    }
}

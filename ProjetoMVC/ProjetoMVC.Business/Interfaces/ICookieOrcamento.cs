using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Interfaces
{
    public interface ICookieOrcamento
    {
        void CadastrarCliente(Cliente item);
        void CadastrarBancada(Bancada item);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models
{
    public class ModeloBancada : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Metodo { get; set; }
        
        //OOP
        public Guid? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int QuantidadePecas { get; set; }
    }
}

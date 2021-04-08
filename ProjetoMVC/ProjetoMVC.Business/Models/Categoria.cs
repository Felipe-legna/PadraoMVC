using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }

        public string Slug { get; set; }

        public Guid? CategoriaPaiId { get; set; }

        public virtual Categoria CategoriaPai { get; set; }
    }
}

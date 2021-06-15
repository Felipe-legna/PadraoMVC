using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models
{
    public class Material : Entity
    {
        public string Nome { get; set; }        
        public decimal Valor { get; set; }      
        public string Imagem { get; set; }
        public bool AtreladoDolar { get; set; }
        //banco de dados
        public Guid? CategoriaId { get; set; }
        //OOP
        public Categoria Categoria { get; set; }


    }
}

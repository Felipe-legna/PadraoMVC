using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        public string Imagem { get; set; }
        //banco de dados
        public Guid? CategoriaId { get; set; }

        //OOP
        public Categoria Categoria { get; set; }


    }
}

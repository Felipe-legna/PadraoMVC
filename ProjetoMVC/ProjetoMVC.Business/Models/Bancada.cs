using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models
{
    public class Bancada : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }        

        public decimal Frontao { get; set; }
        public decimal Saia { get; set; }
        public string Imagem { get; set; }
        //banco de dados
        public Guid? CategoriaId { get; set; }

        public int QuantidadePecas { get; set; }

        public List<Peca> Pecas { get; set; }

        //OOP
        public Categoria Categoria { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models
{
    public class Bancada : Entity
    {        
        public decimal Frontao { get; set; }
        public decimal Saia { get; set; }
        public string Imagem { get; set; }
        public List<Peca> Pecas { get; set; }
        public decimal MetroQuadrado { get; set; }

        public decimal Valor { get; set; }
        public Guid? MaterialId { get; set; }
        public Material Material { get; set; }
        public Guid? ModeloBancadaId { get; set; }
        public ModeloBancada ModeloBancada { get; set; }
    }
}

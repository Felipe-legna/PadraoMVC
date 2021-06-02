using ProjetoMVC.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models
{
    public class Peca : Entity
    {
        public decimal LarguraPeca { get; set; }
        public TipoSustentacao ApoioLargura { get; set; }
        public decimal TotalLarguraPeca { get; set; }
        public decimal ComprimentoPeca { get; set; }        
        public TipoSustentacao ApoioComprimento { get; set; }
        public decimal ComprimentoFogaoEmbutido { get; set; }
        public TipoBase Base { get; set; }
        public decimal MetroQuadradoPeca { get; set; }
        public decimal AlturaDaBase { get; set; }
        public decimal TotalComprimentoPeca { get; set; }

    }
}

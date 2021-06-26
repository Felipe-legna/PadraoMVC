using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.App.Areas.Admin.ViewModels
{
    public class BancadaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Frontão")]
        public decimal Frontao { get; set; }
        public decimal Saia { get; set; }

        public List<Peca2ViewModel> Pecas { get; set; }

        [DisplayName("M² Quadrado")]
        public decimal MetroQuadrado { get; set; }

        public decimal Valor { get; set; }
        public Guid? MaterialId { get; set; }
        public MaterialViewModel MaterialViewModel { get; set; }

        public Guid? ModeloBancadaId { get; set; }
        public ModeloBancadaViewModel ModeloBancada { get; set; }


    }
}

﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.App.Areas.Admin.ViewModels
{
    public class PecaViewModel
    {
        [Key]
        public Guid Id { get; set; }
                

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Largura Peça")]
        public decimal LarguraPeca { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Sustentação Largura")]
        public decimal ApoioLargura { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Comprimento da Peça")]
        public decimal ComprimentoPeca { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Sustentação Comprimento")]
        public decimal ApoioComprimento { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Metro Quadrado da Peça")]
        public decimal MetroQuadradoPeca { get; set; }

        
    }
}

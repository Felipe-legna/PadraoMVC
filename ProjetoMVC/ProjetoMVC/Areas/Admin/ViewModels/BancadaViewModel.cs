﻿using Microsoft.AspNetCore.Http;
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

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Metodo { get; set; }


        [DisplayName("Imagem do Material")]
        public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public CategoriaViewModel Categoria { get; set; }


        public decimal Frontao { get; set; }
        public decimal Saia { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadePecas { get; set; }

        public List<PecaViewModel> Pecas { get; set; }

        public decimal MetroQuadrado { get; set; }

        
    }
}

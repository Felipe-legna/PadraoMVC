using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.ViewModels
{
    public class PecaViewModel
    {       
        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]       
        public decimal Largura { get; set; }


        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]        
        public decimal Comprimento { get; set; }
        
    }
}

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjetoMVC.App.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.App.Areas.Admin.ViewModels
{
    public class MaterialViewModel
    {     
        public Guid Id { get; set; }
        [JsonIgnore]
        public string Nome { get; set; }
        
        [JsonIgnore]
        public decimal Valor { get; set; }
        
 

        [DisplayName("Imagem do Material")]
        [JsonIgnore]
        public IFormFile ImagemUpload { get; set; }
        
        [JsonIgnore]
        public string Imagem { get; set; }


        [DisplayName("Atrelado ao Dólar?")]
        public bool AtreladoDolar { get; set; }

        //banco de dados
        [DisplayName("Categoria Selecionada")]
        public Guid? CategoriaId { get; set; }

        //OOP
        [JsonIgnore] 
        public CategoriaViewModel Categoria { get; set; }
       
    }
}

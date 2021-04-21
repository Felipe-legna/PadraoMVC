using Microsoft.AspNetCore.Http;
using ProjetoMVC.App.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.App.Areas.Admin.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        [DisplayName("Imagem do Material")]
        public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }
       
        //banco de dados
        [DisplayName("Categoria Selecionada")]
        public Guid? CategoriaId { get; set; }

        //OOP
        public CategoriaViewModel Categoria { get; set; }
       
    }
}

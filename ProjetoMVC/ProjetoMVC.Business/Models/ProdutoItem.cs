using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models
{
    public class ProdutoItem : Produto
    {
       
            /*
             * Armazena a quantidade de produtos que o usuário pretende comprar deste item.
             */
            public int QuantidadeProdutoCarrinho { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Models.Enums
{
    public enum TipoSustentacao
    {
        SemApoio = 1, // se não vai na parede deverá ter saia dos dois lados, pode ser em cima de uma parede ou solta para essa lateral
        UmaParede,    // Se a instalação for em uma parede, adicionamos o frontao e saia
        DuasParedes,  //  pedra de apoio ou que vai sobre o bloco
        OutraPeca,     // Se for outra peça devolve o valor da saia
        NaoSeAplica
    }
}


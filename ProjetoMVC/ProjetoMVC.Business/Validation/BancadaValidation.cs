using FluentValidation;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Validation
{
    class BancadaValidation : AbstractValidator<Bancada>
    {
        public BancadaValidation()
        {

            //RuleFor(c => c.Nome)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            //RuleFor(c => c.Nome)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            //RuleFor(c => c.Descricao)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            //RuleFor(c => c.QuantidadePecas)
            //  .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //  .GreaterThan(0);




        }
    }
}

using FluentValidation;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Validation
{
    class MaterialValidation : AbstractValidator<Material>
    {
        public MaterialValidation()
        {

            //RuleFor(c => c.Nome)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(p => p.AtreladoDolar)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(m => m.Valor)
                .GreaterThan(0);

        }

    }
}

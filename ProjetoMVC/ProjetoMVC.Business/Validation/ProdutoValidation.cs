using FluentValidation;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Validation
{
    class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {

            //RuleFor(c => c.Nome)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Valor)
                .GreaterThan(0);

            RuleFor(m => m.Quantidade)
                .GreaterThanOrEqualTo(0);
        }

        }
    }

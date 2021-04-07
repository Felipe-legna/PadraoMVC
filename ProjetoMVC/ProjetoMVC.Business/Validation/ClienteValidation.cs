using FluentValidation;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Business.Validation.Documentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Validation
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            //When(c => c.TipoCliente == TipoCliente.PessoaFisica, () =>
            //{
            //    RuleFor(c => c.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
            //    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            //    RuleFor(c => CpfValidacao.Validar(c.Documento)).Equal(true)
            //    .WithMessage("O Documento fornecido é inválido.");

            //});

            //When(c => c.TipoCliente == TipoCliente.PessoaJuridica, () =>
            //{
            //    RuleFor(c => c.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
            //   .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            //    RuleFor(c => CnpjValidacao.Validar(c.Documento)).Equal(true)
            //    .WithMessage("O Documento fornecido é inválido.");
            //});


            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(8, 12).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


        }
    }
}

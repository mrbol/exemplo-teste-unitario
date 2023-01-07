using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TesteApp.Domain.Models.Validations.Documento;

namespace TesteApp.Domain.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {Nome} precisa ser fornecido")
                .Length(3, 100)
                .WithMessage("O campo {Nome} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(f => CpfValidacao.Validar(f.CPF)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
        }
    }
}

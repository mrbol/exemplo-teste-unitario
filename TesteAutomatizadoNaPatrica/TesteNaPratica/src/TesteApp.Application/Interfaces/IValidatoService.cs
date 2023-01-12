using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Domain.Common;
using TesteApp.Domain.Entities;

namespace TesteApp.Application.Interfaces
{
    public interface IValidatoService
    {
        Notifier RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity;
    }
}

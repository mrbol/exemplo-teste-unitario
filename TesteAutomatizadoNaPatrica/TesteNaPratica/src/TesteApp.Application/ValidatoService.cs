using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Application.Interfaces;
using TesteApp.Domain.Common;
using TesteApp.Domain.Entities;

namespace TesteApp.Application
{
    public class ValidatoService : IValidatoService
    {
        private Notifier _notifications;
        public ValidatoService()
        {
            _notifications = new Notifier();
        }

        private Notifier Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notifications.Add(error.ErrorMessage);
            }
            return _notifications;
        }

        public Notifier RunValidation<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE>
            where TE : BaseEntity
        {
            var validator = validacao.Validate(entidade);
            if (!validator.IsValid)
            {
                Notify(validator);
            }
            return _notifications;
        }
    }
}

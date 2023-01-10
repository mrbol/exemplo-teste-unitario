using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Application.Interfaces;
using TesteApp.Domain.Common;

namespace TesteApp.Application
{
    public class ValidatoService : IValidatoService
    {
        private List<String> _notifications;
        public ValidatoService()
        {
            _notifications = new List<string>();
        }

        public bool ExistsError()
        {
            return _notifications.Any();
        }

        private List<string> Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notifications.Add(error.ErrorMessage);
            }

            return _notifications;
        }

        public async Task<List<string>>  RunValidation<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE>
            where TE : BaseEntity
        {
            await Task.Run(() =>
            {
                var validator = validacao.Validate(entidade);

                if (!validator.IsValid)
                {
                    Notify(validator);
                }
            });

            return _notifications;
        }
    }
}

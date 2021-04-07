using FluentValidation;
using FluentValidation.Results;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Business.Notifications;

namespace ProjetoMVC.Business.Services
{
    public abstract class BaseService
    {
        public readonly INotificador _notificador;
        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE: Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }

        protected void Notificar(ValidationResult validation)
        {
            foreach (var error in validation.Errors)
                Notificar(error.ErrorMessage);

        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}

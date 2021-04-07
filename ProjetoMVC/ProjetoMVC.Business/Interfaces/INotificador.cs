using ProjetoMVC.Business.Notifications;
using System.Collections.Generic;

namespace ProjetoMVC.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}

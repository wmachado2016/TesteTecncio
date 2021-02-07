using BackEnd.Servicos.Notificacoes;
using System.Collections.Generic;

namespace BackEnd.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
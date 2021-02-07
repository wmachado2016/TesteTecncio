using BackEnd.Interfaces;
using BackEnd.Models;
using BackEnd.Models.Validacoes;
using System;
using System.Threading.Tasks;

namespace BackEnd.Servicos
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IRepositorioUsuario usuarioRepositorio;

        public UsuarioService(
            IRepositorioUsuario usuarioRepositorio,
            INotificador notificador) : base(notificador)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<bool> Adicionar(Usuarios usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            await usuarioRepositorio.Adicionar(usuario);
            return true;
        }

        public async Task<bool> Atualizar(Usuarios usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            await usuarioRepositorio.Atualizar(usuario);
            return true;
        }
        public async Task<bool> InativarUsuario(Guid id)
        {
            var user = await usuarioRepositorio.ObterPorId(id);

            if(user == null)
            {
                Notificar("Usuario não existe!");
                return false;
            }
            user.Ativo = false;
            await usuarioRepositorio.Atualizar(user);
            return true;
        }

        public void Dispose()
        {
            usuarioRepositorio?.Dispose();
        }

    }
}

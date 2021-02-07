using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Servicos
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Adicionar(Usuarios fornecedor);
        Task<bool> Atualizar(Usuarios fornecedor);
        Task<bool> InativarUsuario(Guid id);
    }
}

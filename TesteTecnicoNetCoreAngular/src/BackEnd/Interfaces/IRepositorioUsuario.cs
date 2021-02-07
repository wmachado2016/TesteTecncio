using BackEnd.Models;
using System;
using System.Threading.Tasks;

namespace BackEnd.Interfaces
{
    public interface IRepositorioUsuario : IRepositorio<Usuarios>
    {
        Task<Usuarios> ObterTodosPorIdAtivos(Guid id);
    }
}

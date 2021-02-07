using BackEnd.Data.Context;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositorio
{
    public class RepositorioUsuario : Repositorio<Usuarios>, IRepositorioUsuario
    {
        public RepositorioUsuario(DbContextAplicacao context) : base(context)
        {
        }
        public async Task<Usuarios> ObterTodosPorIdAtivos(Guid id)
        {
            return await Db.Usuarios.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id && c.Ativo == true);
        }
    }
}

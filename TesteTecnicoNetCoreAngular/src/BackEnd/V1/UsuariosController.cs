using AutoMapper;
using BackEnd.Controllers;
using BackEnd.Interfaces;
using BackEnd.Models;
using BackEnd.Servicos;
using BackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : MainController
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IUsuarioService usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(
            IRepositorioUsuario repositorioUsuario, 
            IMapper mapper, 
            IUsuarioService usuarioService,
            INotificador notificador) : base(notificador)
        {
            this.repositorioUsuario = repositorioUsuario;
            this._mapper = mapper;
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> ObterTodos()
        {
            var usuario = _mapper.Map<IEnumerable<UsuarioViewModel>>(await repositorioUsuario.ObterTodos());
            return Ok(usuario);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> ObterPorId(Guid id)
        {
            var usuario = await ObterUsuarioId(id);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> Adicionar(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await usuarioService.Adicionar(_mapper.Map<Usuarios>(usuarioViewModel));
            return CustomResponse(usuarioViewModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> AtualziarUsuario(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(usuarioViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await usuarioService.Atualizar(_mapper.Map<Usuarios>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> Remover(Guid id)
        {
            await usuarioService.InativarUsuario(id);

            return CustomResponse(repositorioUsuario);
        }

        private async Task<UsuarioViewModel> ObterUsuarioId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await repositorioUsuario.ObterTodosPorIdAtivos(id));
        }
    }
}

using BackEnd.Interfaces;
using FluentValidation;
using System;

namespace BackEnd.Models.Validacoes
{
    public class UsuarioValidation : AbstractValidator<Usuarios>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public UsuarioValidation(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;

            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.DataNascimento)
                .Must(ValidarDataNascimento)
                .WithMessage("A data de nascimento não pode ser maior que hoje");

            RuleFor(u => u.Id)
               .Must(ValidarUsuario)
               .WithMessage("Usuario já está cadastrado");
        }

        public UsuarioValidation()
        {
        }

        private bool ValidarUsuario(Guid id)
        {
            var usr = repositorioUsuario.ObterPorId(id);
            return usr == null;
        }
        private bool ValidarDataNascimento(DateTime data)
        {
            return data < DateTime.Now;
        }
    }
}
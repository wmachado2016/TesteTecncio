using AutoMapper;
using BackEnd.Models;
using BackEnd.ViewModels;

namespace BackEnd.Data.AutoMapper
{
    public class AutoMapperConfig  : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuarios, UsuarioViewModel>().ReverseMap();
        }

    }
}

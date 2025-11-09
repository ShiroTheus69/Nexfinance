using AutoMapper;
using NexFinance.Domain.Entities;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.DTOs.Auth;

namespace NexFinance.src.Application.Mapping {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<CreateUsuarioDto, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore());

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CreateCategoriaDto, Categoria>();

            CreateMap<Conta, ContaDto>();
            CreateMap<CreateContaDto, Conta>();

            CreateMap<Lancamento, LancamentoDto>();
            CreateMap<CreateLancamentoDto, Lancamento>()
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore());

            CreateMap<Transferencia, TransferenciaDto>();
            CreateMap<CreateTransferenciaDto, Transferencia>();

            CreateMap<LoginDto, Usuario>().ReverseMap();
            CreateMap<LoginResponseDto, Usuario>().ReverseMap();
        }
    }
}

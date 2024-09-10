using AutoMapper;
using Estoque;
using Estoque._03_Entidades;
using Estoque._03_Entidades.DTOs.Fornecedor;
using Estoque._03_Entidades.DTOs.FuncionarioLog;
using Estoque._03_Entidades.DTOs.Pedido;
using Estoque._03_Entidades.DTOs.Produto;

namespace EstoqueAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFornecedorDTO, Fornecedor>().ReverseMap();
            CreateMap<CreateProdutoDTO, Produto>().ReverseMap();
            CreateMap<CreatePedidoDTO, Pedido>().ReverseMap();
            CreateMap<CreateFuncionarioLogDTO, FuncionarioLog>().ReverseMap();
        }
    }
}

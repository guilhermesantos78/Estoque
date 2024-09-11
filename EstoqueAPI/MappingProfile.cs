using AutoMapper;
using Estoque.Entidades.DTOs.Pedido;
using Estoque.Entidades.DTOs.Produto;
using Estoque.Entidades;
using Estoque.Entidades.DTOs.FuncionarioLog;
using Estoque.Services;

namespace EstoqueAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFornecedorDTO, Fornecedor>().ReverseMap();
            CreateMap<ReadFornecedorDTO, Fornecedor>().ReverseMap();
            CreateMap<CreateProdutoDTO, Produto>().ReverseMap();
            CreateMap<ReadPedidoProdutoDTO, Pedido>().ReverseMap();
            CreateMap<CreatePedidoDTO, Pedido>().ReverseMap();
            CreateMap<CreateFuncionarioLogDTO, FuncionarioLog>().ReverseMap();
        }
    }
}

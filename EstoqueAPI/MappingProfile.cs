using AutoMapper;
using Estoque.Entidades.DTOs.Pedido;
using Estoque.Entidades;
using Estoque.Services;

namespace EstoqueAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFornecedorDTO, Fornecedor>().ReverseMap();
            CreateMap<CreateClienteDTO, Cliente>().ReverseMap();
            CreateMap<ReadFornecedorDTO, Fornecedor>().ReverseMap();
            CreateMap<ReadProdutoComFornecedorDTO, Produto>().ReverseMap();
            CreateMap<CreateProdutoDTO, Produto>().ReverseMap();
            CreateMap<ReadPedidoComProdutoDTO, Pedido>().ReverseMap();
            CreateMap<CreatePedidoDTO, Pedido>().ReverseMap();
        }
    }
}

using AutoMapper;
using Estoque;
using Estoque.Entidades;
using Estoque.Entidades.DTOs.Fornecedor;
using Estoque.Entidades.DTOs.FuncionarioLog;
using Estoque.Entidades.DTOs.Pedido;
using Estoque.Entidades.DTOs.Produto;

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

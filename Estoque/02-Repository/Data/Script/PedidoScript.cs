using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Repository.Data.Script
{
    public class PedidoScript
    {
        public static string InsertPedido()
        {
            string commandINSERTPedido = @"
                INSERT INTO Pedidos (DataPedido, DataEntrega, QuantidadeSolicitada, TipoAlteracao ,NomeProduto, ProdutoId, EmpresaId)
                VALUES (@DataPedido, @DataEntrega, @QuantidadeSolicitada, @TipoAlteracao, @NomeProduto, @ProdutoId, @EmpresaId);

                INSERT INTO HistoricoPedidos (DataPedido, DataEntrega, QuantidadeSolicitada, TipoAlteracao, NomeProduto, ProdutoId, EmpresaId)
                VALUES (@DataPedido, @DataEntrega, @QuantidadeSolicitada, @TipoAlteracao, @NomeProduto, @ProdutoId, @EmpresaId)";

            return commandINSERTPedido;
        }
    }
}

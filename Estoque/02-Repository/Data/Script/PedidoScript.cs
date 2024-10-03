namespace Estoque.Repository
{
    public class PedidoScript
    {
        public static string InsertPedido()
        {
            string commandINSERTPedido = @"
                INSERT INTO Pedidos (DataPedido, DataEntrega, QuantidadeSolicitada, TipoAlteracao ,NomeProduto, ProdutoId)
                VALUES (@DataPedido, @DataEntrega, @QuantidadeSolicitada, @TipoAlteracao, @NomeProduto, @ProdutoId);

                INSERT INTO HistoricoPedidos (DataPedido, DataEntrega, QuantidadeSolicitada, TipoAlteracao, NomeProduto, ProdutoId)
                VALUES (@DataPedido, @DataEntrega, @QuantidadeSolicitada, @TipoAlteracao, @NomeProduto, @ProdutoId)";

            return commandINSERTPedido;
        }
    }
}

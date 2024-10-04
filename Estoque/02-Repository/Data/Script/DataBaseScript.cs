namespace Estoque.Repository
{
    public static class DataBaseScript
    {
        public static string CreateTables()
        {
            string commandCREATE = @"
                CREATE TABLE IF NOT EXISTS Produtos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Preco REAL NOT NULL,
                    Descricao TEXT NOT NULL,
                    QuantidadeEmEstoque INTEGER NOT NULL,
                    FornecedorId INTEGER,
                    UsuarioId INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Fornecedores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Contato TEXT NOT NULL,
                    Endereco TEXT NOT NULL,
                    CNPJ TEXT NOT NULL,
                    UsuarioId INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Usuarios(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Username TEXT NOT NULL,
                    Senha TEXT NOT NULL,
                    Email TEXT NOT NULL
                );
                
                CREATE TABLE IF NOT EXISTS Pedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataPedido DATE NOT NULL,
                    DataEntrega DATE NOT NULL,
                    QuantidadeSolicitada INTEGER NOT NULL,
                    TipoAlteracao TEXT NOT NULL,
                    NomeProduto TEXT NOT NULL,
                    ProdutoId INTEGER NOT NULL,
                    UsuarioId INTEGER NOT NULL,
                    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
                );

                CREATE TABLE IF NOT EXISTS HistoricoPedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataPedido DATE NOT NULL,
                    DataEntrega DATE NOT NULL,
                    QuantidadeSolicitada INTEGER NOT NULL,
                    TipoAlteracao TEXT NOT NULL,
                    NomeProduto TEXT NOT NULL,
                    ProdutoId INTEGER,
                    UsuarioId INTEGER NOT NULL,
                    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
                );";

            return commandCREATE;
        }
    }
}

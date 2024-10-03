Controle de Estoque
  
  Bem-vindo ao repositório Estoque! Este projeto é uma aplicação de gerenciamento de inventário desenvolvida em C# . O objetivo é fornecer uma solução eficiente e de fácil uso para o gerenciamento de produtos em estoque.

Índice

  Visão Geral
  Funcionalidades
  
Visão Geral

  O Estoque é um sistema para gerenciamento de inventário, permitindo operações básicas de CRUD (criação, leitura, atualização e exclusão) dos produtos em estoque. O projeto utiliza Dapper para a execução de consultas SQL e Dapper.Contrib para operações simplificadas de CRUD.

Funcionalidades

  Adicionar Produtos: Inclua novos produtos no estoque.
  Editar Produtos: Atualize as informações dos produtos existentes.

Regra de Negócio: Gerenciamento Integrado de Estoque

  Descrição: O sistema deve permitir que todas as operações de estoque — registro de produtos, atualização de quantidades, reabastecimento e controle de fornecedores — sejam realizadas     de maneira integrada, garantindo a consistência e a rastreabilidade das informações.

1. Cadastro de Produto e Associação
  Ao cadastrar um novo produto, deve-se verificar se a categoria e o fornecedor já existem no sistema. Se não existirem, eles devem ser cadastrados automaticamente.

2. Atualização de Estoque
   Sempre que um produto for vendido ou reabastecido, o sistema deve automaticamente atualizar a quantidade disponível em estoque e verificar se é necessário gerar um pedido de              reabastecimento, com base no nível mínimo definido.

3. Notificações de Ação
  Notificações devem ser enviadas aos responsáveis quando:
  Um produto atinge o nível mínimo de estoque.
  Um novo fornecedor é cadastrado ou um produto é vinculado a uma nova categoria.

4. Interface de Usuário Intuitiva
  Remover Produtos: Exclua produtos que não são mais necessários.
  Visualizar Produtos: Consulte uma lista de todos os produtos e suas quantidades.
  Tecnologias Utilizadas


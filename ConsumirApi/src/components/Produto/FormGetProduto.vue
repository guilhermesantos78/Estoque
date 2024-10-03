<template>
    <div>
      <h1>Lista de Produto</h1>
      <button @click="listarProdutos">Carregar Produto</button>
      <ul>
        <li v-for="produto in Produtos" :key="produto.id">
            Id: {{ produto.id }} - Nome: {{ produto.nome }} - Preço: {{ produto.Preco }} - descrição: {{ produto.descricao }} - fornecedorId: {{ produto.fornecedorId }}
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    name: 'FormGetProduto',
    data() {
      return {
        Produtos: [],
      };
    },
    methods: {
      async listarProdutos() {
        const apiUrl = 'https://localhost:7248/Produto/VisualizarProduto';
        try {
          const response = await fetch(apiUrl, {
            method: 'GET',
            headers: {
              'Accept': 'application/json',
            },
          });
  
          if (!response.ok) {
            throw new Error('Erro ao buscar os Produtos');
          }
  
          const data = await response.json(); // Aguarda os dados
          console.log(data);
          this.Produtos = data; // Atribui os dados ao array 'Produtos'
        } catch (error) {
          console.error('Erro:', error);
        }
      },
    },
  };
  </script>
  
  <style>
  /* Adicione estilos aqui, se necessário */
  </style>
  
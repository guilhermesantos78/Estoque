<template>
  <NavBar />
  <NavBarProdutos />
  <div>
    <h1>Lista de Produto</h1>
    <button @click="listarProdutos">Carregar Produto</button>
    <ul>
      <li v-for="produto in Produtos" :key="produto.id">
        Id: {{ produto.id }} - Nome: {{ produto.nome }} - Preço: {{ produto.preco }} - Descrição: {{ produto.descricao }} - FornecedorId: {{ produto.fornecedorId }}
      </li>
    </ul>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';
import NavBarProdutos from '@/components/Produto/NavBarProdutos.vue';

export default {
  name: 'FormGetProduto',
  components: {
    NavBar,
    NavBarProdutos
  },
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

        const data = await response.json();
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

<template>
  <NavBar />
  <NavBarFornecedores />
  <div>
    <h1>Lista de Fornecedores</h1>
    <button @click="listarFornecedor">Carregar Fornecedores</button>
    <ul>
      <li v-for="fornecedor in Fornecedores" :key="fornecedor.id">
        Id: {{ fornecedor.id }} - Nome: {{ fornecedor.nome }} - Contato: {{ fornecedor.contato }} - Endereço: {{
          fornecedor.endereco }} - CNPJ: {{ fornecedor.cnpj }} - Produto ID: {{ fornecedor.produtoId }} - Nome do Produto:
        {{ fornecedor.nomeProduto }}
      </li>
    </ul>
  </div>
</template>

<script>
import NavBarFornecedores from './NavBarFornecedores.vue';
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormGetFornecedor',
  components: {
    NavBarFornecedores,
    NavBar
  },
  data() {
    return {
      Fornecedores: [],
    };
  },
  methods: {
    async listarFornecedor() {
      const apiUrl = 'https://localhost:7248/Fornecedor/VisualizarFornecedor';
      try {
        const response = await fetch(apiUrl, {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
          },
        });

        if (!response.ok) {
          throw new Error('Erro ao buscar os Fornecedores');
        }

        const data = await response.json();
        console.log(data);
        this.Fornecedores = data; // Atribui os dados ao array 'Fornecedores'
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

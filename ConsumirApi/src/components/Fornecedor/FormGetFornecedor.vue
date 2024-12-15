<template>
<<<<<<< Updated upstream
  <div class="main-container">
    <NavBar />
    <NavBarFornecedores />
    <div class="content">
      <h1 class="page-title">Lista de Fornecedores</h1>
      <div class="button-container">
        <button @click="listarFornecedor" class="btn-load">Carregar Fornecedores</button>
      </div>
      <ul class="forn-list">
        <li v-for="fornecedor in Fornecedores" :key="fornecedor.id" class="forn-item">
          <strong>Id:</strong> {{ fornecedor.id }} - <strong>Nome:</strong> {{ fornecedor.nome }} - <strong>Contato:</strong> {{ fornecedor.contato }} - <strong>Endereço:</strong> {{ fornecedor.endereco }} - <strong>CNPJ:</strong> {{ fornecedor.cnpj }} - <strong>Produto ID:</strong> {{ fornecedor.produtoId }} - <strong>Nome do Produto:</strong> {{ fornecedor.nomeProduto }}
        </li>
      </ul>
    </div>
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
    async listarFornecedores() {
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

        this.Fornecedores = await response.json();
      } catch (error) {
        console.error('Erro:', error);
      }
    },
  }
};
</script>

<style scoped>
.page-title {
  font-size: 28px;
  color: #333;
  text-align: center;
  margin-top: 20px;
  margin-bottom: 20px;
  font-family: 'Arial', sans-serif;
}

.button-container {
  text-align: center;
  margin-bottom: 20px;
}

.btn-load {
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.btn-load:hover {
  background-color: #000;
}

.forn-list {
  list-style-type: none;
  padding: 0;
  margin: 0 auto;
  max-width: 600px;
}

.forn-item {
  background-color: #f9f9f9;
  margin-bottom: 10px;
  padding: 15px;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  font-family: 'Arial', sans-serif;
}

.forn-item strong {
  color: #555;
}

.message {
  margin-top: 15px;
  font-size: 16px;
}

.success {
  color: green;
}

.error {
  color: red;
}

/* Responsividade */
@media (max-width: 600px) {
  .page-title {
    font-size: 24px;
    margin: 15px;
  }
  
  .btn-load {
    width: 100%;
    padding: 12px 0;
  }

  .user-item {
    padding: 12px;
    font-size: 14px;
  }
}
</style>

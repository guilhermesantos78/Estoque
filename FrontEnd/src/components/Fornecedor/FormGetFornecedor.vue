<template>
  <NavBar />
  <div class="Main__container">
    <div class="content">
      <h1 class="page__title">Lista de Fornecedores</h1>
      <div class="button__container">
        <button @click="listarFornecedor" class="btn__load">Carregar Fornecedores</button>
      </div>
      <ul class="forn__list">
        <li v-for="fornecedor in Fornecedores" :key="fornecedor.id" class="forn__item">
          <strong>Id:</strong> {{ fornecedor.id }} - <strong>Nome:</strong> {{ fornecedor.nome }} -
          <strong>Contato:</strong> {{ fornecedor.contato }} - <strong>Endereço:</strong> {{ fornecedor.endereco }} -
          <strong>CNPJ:</strong> {{ fornecedor.cnpj }} - <strong>Produto ID:</strong> {{ fornecedor.produtoId }} -
          <strong>Nome do Produto:</strong> {{ fornecedor.nomeProduto }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormGetFornecedor',
  components: {
    NavBar
  },
  data() {
    return {
      Fornecedores: [],
    };
  },
  methods: {
    async listarFornecedor() {
      const apiUrl = 'https://localhost:7248/Fornecedor/visualizar-fornecedor';
      try {
        const response = await fetch(apiUrl, {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
          },
        });

        if (response.status === 200) {
          this.Fornecedores = await response.json();
          alert('Sucesso ao listar os fornecedores!')
        }
        else {
          alert('Erro ao listar os fornecedores!')
        }
      } catch (error) {
        console.error(error);
      }
    },
  },
};
</script>

<style scoped>
.Main__container {
  font-family: "Funnel Display", sans-serif;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: auto;
  width: 100%;
}

.page__title {
  font-size: 28px;
  color: #333;
  text-align: center;
  margin-top: 20px;
  margin-bottom: 20px;
  font-family: "Funnel Display", sans-serif;
}

.button__container {
  text-align: center;
  margin-bottom: 20px;
}

.btn__load {
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.btn__load:hover {
  background-color: #000;
}

.forn__list {
  list-style-type: none;
  padding: 0;
  margin: 0 auto;
  max-width: 600px;
}

.forn__item {
  background-color: #f9f9f9;
  margin-bottom: 10px;
  padding: 15px;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  font-family: "Funnel Display", sans-serif;
}

.forn__item strong {
  color: #555;
}

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

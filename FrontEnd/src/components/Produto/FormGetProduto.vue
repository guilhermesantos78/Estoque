<template>
  <NavBar />
  <div class="Main__container">
    <div class="content">
      <h1 class="page__title">Lista de Produto</h1>

      <!-- Não precisamos de campo de input para empresaId aqui -->
      <div class="button__container">
        <button @click="listarProdutos" class="btn__load">Carregar Produto</button>
      </div>

      <ul class="product__list">
        <li v-for="produto in Produtos" :key="produto.id" class="product__item">
          Id: {{ produto.id }} - Nome: {{ produto.nome }} - Preço: {{ produto.preco }} - Descrição: {{ produto.descricao }}
          - FornecedorId: {{ produto.fornecedorId }} - EmpresaId: {{ produto.empresaId }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormGetProduto',
  components: {
    NavBar,
  },
  data() {
    return {
      Produtos: [],
      empresaId: ''
    };
  },
  mounted() {
    this.empresaId = this.usuario.empresaId; // Acessar o usuario via this.usuario
    console.log(this.usuario);
  },
  computed: {
    // Acessando o usuario via Vuex
    usuario() {
      return this.$store.getters.getUsuario; // Supondo que o getter 'getUsuario' retorna os dados do usuário
    }
  },
  methods: {
    async listarProdutos() {
      const apiUrl = `https://localhost:7248/Produto/cliente/${this.empresaId}`;

      try {
        const response = await fetch(apiUrl, {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
          },
        });

        console.log(response.status)
        const data = await response.json();
        console.log(data);
        this.Produtos = data;
      } catch (error) {
        console.error('Erro:', error);
        this.errorMessage = error.message;  // Mostra o erro na tela
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
  height: 80vh;
  width: 100%;
}

.content {
  padding: 20px;
  flex: 1;
}

.page__title {
  font-size: 28px;
  color: #333;
  text-align: center;
  margin-top: 20px;
  margin-bottom: 20px;
}

.button__container {
  text-align: center;
  margin-bottom: 20px;
}

.btn__load {
  padding: 10px 20px;
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.btn__load:hover {
  background-color: #1A5276;
}

.product__list {
  list-style-type: none;
  padding: 0;
  margin: 0 auto;
  max-width: 600px;
}

.product__item {
  background-color: #f9f9f9;
  margin-bottom: 10px;
  padding: 15px;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.product__item strong {
  color: #555;
}

.error-message {
  color: red;
  font-weight: bold;
  text-align: center;
  margin-top: 20px;
}

@media (max-width: 600px) {
  .page__title {
    font-size: 24px;
    margin: 15px;
  }

  .btn__load {
    width: 100%;
    padding: 12px 0;
  }

  .product__item {
    padding: 12px;
    font-size: 14px;
  }
}
</style>

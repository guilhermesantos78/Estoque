<template>
  <div class="navBar">
    <div class="menu__icon" @click="toggleMenu">
      ☰
    </div>

    <nav :class="{ 'sidebar': true, 'sidebar__open': isMenuOpen }">
      <RouterLink to="/InitialPageClientes" class="nav__link">Home</RouterLink>

      <div v-if="!usuario">
        <RouterLink to="FormLoginUsuario" class="nav__link">Log in</RouterLink>
      </div>
      <div v-else>
        <RouterLink to="UserPage" class="nav__link">{{ usuario.username }}</RouterLink>
      </div>

      <RouterLink to="/" class="nav__link">Logout</RouterLink>
    </nav>
  </div>

  <div class="page-container">
    <h2>Finalização da Compra</h2>
    <h1 v-if="usuario && usuario.username">Bem-vindo, {{ usuario.username }}!</h1>
    <h1 v-else>Bem-vindo, visitante!</h1>

    <div class="product-section">
      <h3>Seus Produtos</h3>
      <p v-if="produtos.length === 0">Você não adicionou nenhum produto ao carrinho</p>
      <ul class="product-list" v-else>
        <li v-for="produto in produtos" :key="produto.id" class="product-item">
          <strong>{{ produto.nome }}</strong>
          <p>A partir de: <span class="price">{{ formatPreco(produto.preco) }}</span></p>
          <p>{{ produto.descricao }}</p>
        </li>
      </ul>
    </div>


    <div class="address-section">
      <h3>Endereço de Entrega</h3>
      <form @submit.prevent="finalizarCompra">
        <div class="form-group">
          <label for="nome">Nome Completo:</label>
          <input type="text" v-model="cliente.nome" id="nome" placeholder="Seu nome completo" required>
        </div>
        <div class="form-group">
          <label for="endereco">Endereço:</label>
          <input type="text" v-model="cliente.endereco" id="endereco" placeholder="Rua, Número, Bairro" required>
        </div>
        <div class="form-group">
          <label for="cep">CEP:</label>
          <input type="text" v-model="cliente.cep" id="cep" placeholder="CEP" required>
        </div>
        <div class="form-group">
          <label for="cidade">Cidade:</label>
          <input type="text" v-model="cliente.cidade" id="cidade" placeholder="Cidade" required>
        </div>
        <div class="form-group">
          <label for="estado">Estado:</label>
          <input type="text" v-model="cliente.estado" id="estado" placeholder="Estado" required>
        </div>
        <div class="form-group">
          <label for="telefone">Telefone:</label>
          <input type="text" v-model="cliente.telefone" id="telefone" placeholder="Seu telefone" required>
        </div>

        <button type="submit" class="submit-button">Finalizar Compra</button>
      </form>
    </div>

    <div v-if="compraFinalizada" class="confirmation-modal">
      <h3>Compra Concluída!</h3>
      <p>Obrigado, {{ cliente.nome }}! Seu pedido foi realizado com sucesso.</p>
      <p>Detalhes do pedido:</p>
      <ul>
        <li v-for="produto in produtos" :key="produto.id">{{ produto.nome }} - {{ formatPreco(produto.preco) }}</li>
      </ul>
      <p><strong>Total: {{ totalCompra }}$</strong></p>
      <button @click="voltarParaHome" class="back-button">Voltar para a Página Inicial</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'GestaoCompraClientes',
  data() {
    return {
      produtos: [],
      cliente: {
        nome: '',
        endereco: '',
        cep: '',
        cidade: '',
        estado: '',
        telefone: ''
      },
      compraFinalizada: false,
      isMenuOpen: false, // Inicialização do isMenuOpen
    };
  },
  mounted() {
    const produtos = JSON.parse(this.$route.query.produtos || '[]');
    this.produtos = produtos;
  },
  methods: {
    finalizarCompra() {
      this.compraFinalizada = true;
    },
    voltarParaHome() {
      this.$router.push('/InitialPageClientes'); // Certifique-se de que a rota está correta
    },
    formatPreco(valor) {
      return valor.toFixed(2).replace('.', ',') + ' $'; // Formatação do preço
    },
    toggleMenu() {
      this.isMenuOpen = !this.isMenuOpen;
    },
    async PostPedido() {

    }
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario;
    },
    totalCompra() {
      return this.produtos.reduce((acc, produto) => acc + parseFloat(produto.preco), 0).toFixed(2);
    }
  }
};
</script>

<style scoped>
/* Estilos de navegação e estrutura do template */
.navBar {
  display: flex;
  justify-content: flex-end;
  background-color: #ededed;
  padding: 10px;
}

.menu__icon {
  font-size: 30px;
  cursor: pointer;
  color: #333;
  margin-right: 20px;
}

.sidebar {
  position: fixed;
  top: 0;
  left: 0;
  width: 250px;
  height: 100%;
  background-color: #FFF;
  box-shadow: 2px 0 5px rgba(0, 0, 0, 0.2);
  padding-top: 60px;
  transition: transform 0.3s ease;
  transform: translateX(-250px);
}

.sidebar__open {
  transform: translateX(0);
}

.sidebar__item {
  padding: 10px 20px;
  cursor: pointer;
}

.nav__link {
  display: block;
  padding: 10px 20px;
  text-decoration: none;
  color: #333;
  background-color: rgba(255, 255, 255, 0.2);
  border-radius: 5px;
  transition: background-color 0.3s ease, color 0.3s;
}

.nav__link:hover {
  background-color: rgba(0, 0, 0, 0.1);
  color: #007bff;
}

.page-container {
  font-family: "Funnel Display", sans-serif;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  background-color: #f9f9f9;
  min-height: 100vh;
}

.product-section,
.address-section {
  width: 100%;
  max-width: 900px;
  margin: 20px 0;
}

.product-list {
  list-style-type: none;
  padding: 0;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 20px;
}

.product-item {
  background-color: #fff;
  margin: 10px;
  padding: 20px;
  width: 250px;
  border-radius: 8px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  text-align: center;
}

.price {
  font-weight: bold;
  color: #333;
}

.address-section form {
  display: flex;
  flex-direction: column;
  gap: 15px;
}

.form-group {
  display: flex;
  flex-direction: column;
}

.form-group label {
  font-size: 14px;
  margin-bottom: 5px;
}

.form-group input {
  padding: 10px;
  font-size: 16px;
  border-radius: 5px;
  border: 1px solid #ccc;
}

.submit-button {
  background-color: rgb(0, 43, 82);
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
  transition: .3s;
}

.submit-button:hover {
  background-color: #1A5276;
  transform: scale(1.06);
}

.confirmation-modal {
  background-color: white;
  padding: 30px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  border-radius: 10px;
  text-align: center;
  width: 80%;
  max-width: 600px;
  margin-top: 30px;
}

.confirmation-modal h3 {
  color: #28a745;
}

.back-button {
  background-color: #007BFF;
  color: white;
  padding: 10px 20px;
  border-radius: 5px;
  cursor: pointer;
  margin-top: 20px;
  border: none;
  transition: .3s;
}

.back-button:hover {
  background-color: #0056b3;
  transform: scale(1.1);
}
</style>

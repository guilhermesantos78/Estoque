<template>
  <div class="page-container">
    <h2>Finalização da Compra</h2>
    <h1>Bem-vindo, {{ usuario.username }}!</h1>
    <div class="product-section">
      <h3>Seus Produtos</h3>
      <ul class="product-list">
        <li v-for="produto in produtos" :key="produto.id" class="product-item">
          <strong>{{ produto.nome }}</strong>
          <p>A partir de: <span class="price">{{ produto.preco }}$</span></p>
          <p>{{ produto.descricao }}</p>
        </li>
      </ul>
    </div>

    <div class="address-section">
      <h3>Endereço de Entrega</h3>
      <form @submit.prevent="finalizarCompra">
        <div class="form-group">
          <label for="nome">Nome Completo:</label>
          <input type="text" v-model="cliente.nome" id="nome" placeholder="Seu nome completo" required
            default="{{ usuario.nome }}">
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
        <li v-for="produto in produtos" :key="produto.id">{{ produto.nome }} - {{ produto.preco }}$</li>
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
      compraFinalizada: false
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
      this.$router.push('InitialPageClientes');
    }
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario;
    },
    totalCompra() {
      return this.produtos.reduce((acc, produto) => acc + produto.preco, 0);
    }
  }

};
</script>

<style scoped>
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
  background-color: #28a745;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.submit-button:hover {
  background-color: #218838;
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
}

.back-button:hover {
  background-color: #0056b3;
}
</style>
<template>
  <div class="page-container">
    <NavBar />
    <button @click="mostrarCarrinho" class="cart-button">Carrinho ({{ Carrinho.length }})</button>
    <div class="container">
      <div class="Tittle">
        <div v-if="mensagem" class="message">{{ mensagem }}</div>
      </div>
      <h2>Lista de Produtos</h2>
      <div class="products">
        <ul class="product-list">
          <li v-for="produto in Produtos" :key="produto.id" class="product-item">
            <div class="product-image">
              <img :src="produto.imagemUrl || 'https://via.placeholder.com/250x250'" alt="Produto">
            </div>
            <div class="product-details">
              <strong>{{ produto.nome }}</strong>
              <p>A partir de: <span class="price">{{ produto.preco }}$</span></p>
              <p>{{ produto.descricao }}</p>
              <button @click="adicionarAoCarrinho(produto)" class="add-to-cart">Adicionar ao Carrinho</button>
            </div>
          </li>
        </ul>
        <button class="productsaddbutton" @click="handleClick">Finalizar Compra</button>
      </div>
    </div>

    <div v-if="mostrarCarrinhoModal" class="cart-modal">
      <h2>Carrinho</h2>
      <ul>
        <li v-for="item in Carrinho" :key="item.id" class="cart-item">
          <span class="cart-item-name">{{ item.nome }} - {{ item.preco }}$</span>
          <div class="item-actions">
            <button @click="adicionarMais(item)">+</button>
            <button @click="removerDoCarrinho(item)">Remover</button>
          </div>
        </li>
      </ul>
      <div class="cart-total">
        Total: {{ Carrinho.reduce((acc, item) => acc + (item.preco * item.quantidade), 0) }}$
      </div>
      <button @click="fecharCarrinho" class="close-button">Fechar</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'InitalPageClientes',
  data() {
    return {
      Produtos: [],
      Carrinho: [],
      mensagem: '',
      mostrarCarrinhoModal: false
    };
  },
  methods: {
    async carregarProdutos() {
      const apiUrl = 'https://localhost:7248/Produto/visualizar-produto';
      try {
        const response = await fetch(apiUrl);
        if (!response.ok) throw new Error('Erro ao buscar os produtos');
        const data = await response.json();
        this.Produtos = data;
      } catch (error) {
        console.error('Erro:', error);
      }
    },
    adicionarAoCarrinho(produto) {
      const produtoExistente = this.Carrinho.find(item => item.id === produto.id);
      if (produtoExistente) produtoExistente.quantidade += 1;
      else this.Carrinho.push({ ...produto, quantidade: 1 });
      this.mensagem = `${produto.nome} adicionado ao carrinho!`;
      setTimeout(() => { this.mensagem = ''; }, 3000);
    },
    adicionarMais(produto) {
      produto.quantidade += 1;
      this.mensagem = `Mais uma unidade de ${produto.nome} adicionada!`;
      setTimeout(() => { this.mensagem = ''; }, 3000);
    },
    removerDoCarrinho(produto) {
      this.Carrinho = this.Carrinho.filter(item => item.id !== produto.id);
      this.mensagem = `${produto.nome} removido do carrinho.`;
      setTimeout(() => { this.mensagem = ''; }, 3000);
    },
    mostrarCarrinho() {
      this.mostrarCarrinhoModal = true;
    },
    fecharCarrinho() {
      this.mostrarCarrinhoModal = false;
    },
    handleClick() {
      this.$router.push({ name: 'GestaoCompraClientes', query: { produtos: JSON.stringify(this.Carrinho) } });
    }
  },
  mounted() {
    this.carregarProdutos();
  }
};
</script>

<style scoped>
.page-container {
  font-family: 'Arial', sans-serif;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  background-color: #f2f2f2;
  min-height: 100vh;
}

.container {
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
}

.Tittle {
  text-align: center;
  margin-bottom: 20px;
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
  border-radius: 10px;
  width: 250px;
  padding: 15px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  text-align: center;
  transition: transform 0.3s ease;
  position: relative;
}

.product-item:hover {
  transform: translateY(-10px);
}

.product-image img {
  width: 100%;
  border-radius: 10px;
  height: auto;
  max-height: 200px;
}

.product-details {
  margin-top: 10px;
}

.price {
  font-weight: bold;
  color: #333;
}

.add-to-cart {
  background-color: #007BFF;
  color: white;
  border: none;
  padding: 10px;
  margin-top: 10px;
  cursor: pointer;
  border-radius: 5px;
  transition: background-color 0.3s;
}

.add-to-cart:hover {
  background-color: #0056b3;
}

.productsaddbutton {
  background-color: #28a745;
  color: white;
  padding: 10px 20px;
  border: none;
  margin-top: 30px;
  cursor: pointer;
  border-radius: 5px;
  transition: background-color 0.3s;
}

.productsaddbutton:hover {
  background-color: #218838;
}

.cart-button {
  position: fixed;
  top: 20px;
  right: 20px;
  background-color: #333;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  z-index: 999;
  transition: background-color 0.3s;
}

.cart-button:hover {
  background-color: #555;
}

.cart-modal {
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: #fff;
  padding: 30px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  border-radius: 10px;
  z-index: 1000;
  width: 300px;
}

.cart-item {
  display: flex;
  justify-content: space-between;
  margin-bottom: 10px;
  padding: 5px;
}

.item-actions button {
  background-color: #007BFF;
  color: white;
  border: none;
  padding: 5px;
  margin: 0 5px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.item-actions button:hover {
  background-color: #0056b3;
}

.cart-total {
  font-weight: bold;
  margin-top: 20px;
  text-align: center;
}

.close-button {
  position: absolute;
  bottom: 20px;
  right: 20px;
  background-color: #dc3545;
  color: white;
  padding: 10px 20px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.close-button:hover {
  background-color: #c82333;
}

.message {
  color: green;
  text-align: center;
  margin-top: 10px;
}

/* Media Queries */
@media (max-width: 768px) {
  .product-item {
    width: 100%;
    margin: 10px 0;
  }
  .cart-button {
    top: 10px;
    right: 10px;
  }
}
</style>

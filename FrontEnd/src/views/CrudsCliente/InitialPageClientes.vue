<template>
  <div class="navBar">
    <div class="menu__icon" @click="toggleMenu">
      ☰
    </div>

    <nav :class="{ 'sidebar': true, 'sidebar__open': isMenuOpen }">
      <RouterLink to="/InitialPageClientes" class="nav__link">Home</RouterLink>

      <div class="sidebar__item" @click="mostrarCarrinho">
        <button>Carrinho ({{ Carrinho.length }})</button>
      </div>

      <div v-if="!usuario">
        <RouterLink to="FormLoginUsuario" class="nav__link">Log in</RouterLink>
      </div>
      <div v-else>
        <RouterLink to="UserPageClientes" class="nav__link">{{ usuario.username }}</RouterLink>
      </div>

      <RouterLink to="/" class="nav__link" @click="logout">Logout</RouterLink>
    </nav>
  </div>

  <div class="page-container">
    <div class="container">
      <div class="Tittle">
        <div v-if="mensagem" class="message">{{ mensagem }}</div>
      </div>
      <h2>Lista de Produtos</h2>
      <div class="products">
        <ul class="product__list">
          <li v-for="produto in Produtos" :key="produto.id" class="product__item">
            <div class="product__details">
              <strong class="product__name">{{ produto.nome }}</strong>
              <p class="product__price">A partir de: <span class="price">{{ produto.preco }}$</span></p>
              <p class="product__description">{{ produto.descricao }}</p>
              <button @click="adicionarAoCarrinho(produto)" class="add__to__cart">Adicionar ao Carrinho</button>
            </div>
          </li>
        </ul>
      </div>
      <button class="productsaddbutton" @click="handleClick">Finalizar Compra</button>
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
      mostrarCarrinhoModal: false,
      isMenuOpen: false
    };
  },
  methods: {
    toggleMenu() {
      this.isMenuOpen = !this.isMenuOpen;
    },
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
      this.$router.push({
        name: 'GestaoCompraClientes',
        query: { produtos: JSON.stringify(this.Carrinho) }
      });
    },
    logout() {
      this.$store.commit('setUsuario', null);
    }
  },
  mounted() {
    this.carregarProdutos();
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario;
    }
  }
};
</script>

<style scoped>
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

.sidebar__item button {
  padding: 10px 20px;
  cursor: pointer;
  border:3px solid #ededed;
  border-radius: 8px;
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

.container {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 20px;
}

.page-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  background-color: #f2f2f2;
  min-height: 100vh;
}

.product__list {
  display: flex;
  gap: 20px;
  list-style-type: none;
  padding: 0;
  margin: 0;
}

.product__item {
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  overflow: hidden;
  transition: transform 0.3s ease-in-out;
  padding: 20px;
  text-align: center;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.product__name {
  font-size: 1.2em;
  font-weight: bold;
  color: #333;
}

.product__price {
  font-size: 1.1em;
  color: #4CAF50;
  margin: 10px 0;
}

.product__description {
  font-size: 0.95em;
  color: #555;
  margin-bottom: 15px;
}

.add__to__cart {
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  padding: 10px 20px;
  font-size: 1em;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.add__to__cart:hover {
  background-color: #1A5276;
}

.productsaddbutton {
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  padding: 15px 30px;
  font-size: 1.1em;
  border-radius: 8px;
  margin-top: 30px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.productsaddbutton:hover {
  background-color: #1A5276;
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
  height: auto;
}

.cart-item {
  display: flex;
  justify-content: space-between;
  margin-bottom: 10px;
  padding: 5px;
}

.item-actions button {
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  padding: 5px;
  margin: 0 5px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.item-actions button:hover {
  background-color: #1A5276;
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
  transition: background-color 0.3s ease;
}

.close-button:hover {
  background-color: #c82333;
}

@media (max-width: 768px) {
  .product__item {
    width: 100%;
    margin: 10px 0;
  }

  .cart-button {
    top: 10px;
    right: 10px;
  }
}
</style>

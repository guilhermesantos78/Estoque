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
            {{ produto.nome }} <br><br> A partir de : {{ produto.preco }}$ <br><br>
            Descrição: {{ produto.descricao }}
            <button @click="adicionarAoCarrinho(produto)">Adicionar ao Carrinho</button>
          </li>
        </ul>
        <button class="productsaddbutton" @click="handleClick">Clique aqui</button>
      </div>
    </div>
    <div v-if="mostrarCarrinhoModal" class="cart-modal">
      <h2>Carrinho</h2>
      <ul>
        <li v-for="item in Carrinho" :key="item.id" class="cart-item">
          {{ item.nome }} - {{ item.preco }}$
          <div class="item-actions">
            <button @click="adicionarMais(item)">+</button>
            <button @click="removerDoCarrinho(item)">Remover</button>
          </div>
        </li>
      </ul>
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
        const response = await fetch(apiUrl, {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
          },
        });
        if (!response.ok) {
          throw new Error('Erro ao buscar os produtos');
        }
        const data = await response.json();
        this.Produtos = data;
      } catch (error) {
        console.error('Erro:', error);
      }
    },
    adicionarAoCarrinho(produto) {
      this.Carrinho.push({ ...produto, quantidade: 1 });
      this.mensagem = `Produto ${produto.nome} adicionado ao carrinho!`;
      setTimeout(() => {
        this.mensagem = '';
      }, 3000);
    },
    adicionarMais(produto) {
      produto.quantidade += 1;
      this.mensagem = `Adicionada mais uma unidade de ${produto.nome} ao carrinho!`;
      setTimeout(() => {
        this.mensagem = '';
      }, 3000);
    },
    removerDoCarrinho(produto) {
      this.Carrinho = this.Carrinho.filter(item => item.id !== produto.id);
      this.mensagem = `Produto ${produto.nome} removido do carrinho.`;
      setTimeout(() => {
        this.mensagem = '';
      }, 3000);
    },
    mostrarCarrinho() {
      this.mostrarCarrinhoModal = true;
    },
    fecharCarrinho() {
      this.mostrarCarrinhoModal = false;
    },
    handleClick() {
      console.log('Botão clicado!');
    }
  },
  mounted() {
    this.carregarProdutos();
  }
};
</script>

<style scoped>
.products {
  padding-top: 50px;
}

.productsaddbutton{
  position: absolute;
  right: 50%;
  margin-top: 50px;
  transform: translate(50%, -50%);
}

.page-container {
  font-family: 'Arial', sans-serif;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  background-color: #f9f9f9;
  min-height: 100vh;
}

.container {
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  width: 100%;
  padding: 20px;
}

.Tittle {
  text-align: center;
  margin-bottom: 20px;
}

.Tittle h2 {
  margin-bottom: 20px;
  color: #333;
}

.product-list {
  list-style-type: none;
  padding: 0;
  width: 100%;
  max-width: 2000px;
  display: flex;
}

.product-item {
  background-color: #ffffff;
  margin-bottom: 10px;
  padding: 15px;
  height: 350px;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
}

.product-item button {
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.product-item button:hover {
  background-color: #000;
}

.cart-button {
  position: fixed;
  top: 20px;
  right: 20px;
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.cart-button:hover {
  background-color: #000;
}

.message {
  margin-top: 20px;
  color: green;
  font-size: 16px;
  text-align: center;
}

.cart-modal {
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: white;
  padding: 30px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  border-radius: 10px;
  width: 90%;
  min-height: 500px;
  max-width: 1000px;
  z-index: 1000;
}

.cart-modal button {
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.cart-item {
  display: flex;
  justify-content: space-between;
  margin-bottom: 10px;
  margin-top: 20px;
}

.item-actions {
  display: flex;
  gap: 10px;
}

.close-button {
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
  margin-top: 20px;
  position: absolute;
  bottom: 0;
  right: 0;
  margin: 50px;
}

.close-button:hover {
  background-color: #000;
}

/* Media Queries */
@media (max-width: 768px) {
  .product-item {
    flex-direction: column;
    text-align: center;
  }

  .cart-button {
    top: 10px;
    right: 10px;
    padding: 8px 16px;
  }

  .container__center {
    padding: 10px;
  }

  .Tittle h1 {
    font-size: 1.5rem;
  }

  h2 {
    font-size: 1.2rem;
  }
}

@media (max-width: 480px) {
  button {
    padding: 8px 16px;
  }

  .cart-button {
    top: 5px;
    right: 5px;
    padding: 6px 12px;
  }

  .Tittle h1 {
    font-size: 1.2rem;
  }

  h2 {
    font-size: 1rem;
  }
}
</style>

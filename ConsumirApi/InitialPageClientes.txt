<template>
  <div class="page-container">
    <NavBar />
    <button @click="mostrarCarrinho" class="cart-button">Carrinho ({{ Carrinho.length }})</button>
    <div class="container__center">
      <div class="Tittle">
        <h1>Bem Vindo a nossa loja</h1>
        <h3>Escolha um produto para seguir para o pagamento</h3>
        <div v-if="mensagem" class="message">{{ mensagem }}</div>
      </div>
      <h2>Lista de Produtos</h2>
      <ul class="product-list">
        <li v-for="produto in Produtos" :key="produto.id" class="product-item">
          Id: {{ produto.id }} - Nome: {{ produto.nome }} - Preço: {{ produto.preco }} - Descrição: {{ produto.descricao }}
          <button @click="adicionarAoCarrinho(produto)">Adicionar ao Carrinho</button>
        </li>
      </ul>
      <button @click="handleClick">Clique aqui</button>
    </div>
    <div v-if="mostrarCarrinhoModal" class="cart-modal">
      <h2>Carrinho</h2>
      <ul>
        <li v-for="item in Carrinho" :key="item.id" class="cart-item">
          {{ item.nome }} - {{ item.preco }}
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
.page-container {
  font-family: 'Arial', sans-serif;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  background-color: #f9f9f9;
  min-height: 100vh;
}

.container__center {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100%;
  padding: 20px;
}

.Tittle {
  text-align: center;
  margin-bottom: 20px;
}

h2 {
  margin-bottom: 20px;
  color: #333;
}

.product-list {
  list-style-type: none;
  padding: 0;
  width: 100%;
  max-width: 600px;
}

.product-item {
  background-color: #ffffff;
  margin-bottom: 10px;
  padding: 15px;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
}

button {
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

button:hover {
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
  padding: 20px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  border-radius: 10px;
  width: 90%;
  max-width: 600px;
  z-index: 1000;
}

.cart-item {
  display: flex;
  justify-content: space-between;
  margin-bottom: 10px;
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

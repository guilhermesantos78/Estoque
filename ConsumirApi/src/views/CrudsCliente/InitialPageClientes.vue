<template>
<<<<<<< Updated upstream
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
=======
  <div class="container__center">
    <div class="header">
      <h1>Bem Vindo ao gerenciamento da sua empresa</h1>
      <h3>Use este site para gerenciar os parâmetros da sua empresa</h3>
    </div>
    <div class="content">
      <h2>Gerencie seus produtos aqui</h2>
      <p>Este é o lugar onde você pode adicionar, editar e remover produtos da sua loja. Utilize as opções abaixo para navegar e gerenciar seu inventário.</p>
      <router-link to="/CrudProdutosCliente" class="nav-link button">Produtos</router-link>
      <button @click="handleClick" class="primary-button">Clique aqui</button>
    </div>
    <div class="additional-section">
      <h2>Atualizações Recentes</h2>
      <p>Mantenha-se informado sobre as últimas atualizações e melhorias que fizemos em nossa plataforma para ajudá-lo a gerenciar sua empresa de maneira mais eficiente.</p>
      <ul>
        <li>Nova funcionalidade de relatórios</li>
        <li>Integração com redes sociais</li>
        <li>Melhoria na performance do sistema</li>
      </ul>
      <h2>Suporte ao Cliente</h2>
      <p>Se precisar de assistência, nossa equipe de suporte está disponível 24/7. Entre em contato pelo nosso <a href="#" class="support-link">canal de suporte</a>.</p>
>>>>>>> Stashed changes
    </div>
  </div>
</template>

<script>
export default {
<<<<<<< Updated upstream
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
=======
  name: 'InitialPageClientes',
  methods: {
    handleClick() {
      console.log('Botão clicado!');
>>>>>>> Stashed changes
    }
  },
  mounted() {
    this.carregarProdutos();
  }
<<<<<<< Updated upstream
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
=======
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap');

.container__center {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background: linear-gradient(to right, #a1c4fd, #c2e9fb);
  color: #333;
  font-family: 'Montserrat', sans-serif;
  padding: 20px;
}

.header {
  text-align: center;
  margin-bottom: 40px;
}

.header h1 {
  font-size: 2.5em;
  font-weight: 600;
}

.header h3 {
  font-size: 1.2em;
  font-weight: 400;
}

.content {
>>>>>>> Stashed changes
  text-align: center;
  margin-bottom: 20px;
}

<<<<<<< Updated upstream
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
=======
.content h2 {
  margin-bottom: 10px;
}

.content p {
  font-size: 1em;
  color: #666;
  margin-bottom: 20px;
}

.nav-link {
  text-decoration: none;
  color: #fff;
}

.button, .primary-button {
  padding: 12px 25px;
  background-color: #5c6bc0;
  border: none;
  border-radius: 25px;
  cursor: pointer;
  transition: background-color 0.3s ease, transform 0.3s ease;
  font-size: 1em;
  margin: 10px 0;
  box-shadow: 0px 5px 10px rgba(0, 0, 0, 0.2);
}

.button:hover, .primary-button:hover {
  background-color: #3949ab;
  transform: translateY(-3px);
}

.primary-button {
  background-color: #4caf50;
}

.primary-button:hover {
  background-color: #388e3c;
}

.additional-section {
  text-align: center;
  margin-top: 40px;
}

.additional-section h2 {
  margin-bottom: 10px;
}

.additional-section p {
  font-size: 1em;
  color: #666;
  margin-bottom: 20px;
}

.additional-section ul {
  list-style: none;
  padding: 0;
  margin: 0 0 20px;
}

.additional-section li {
  font-size: 1em;
  color: #333;
  margin-bottom: 5px;
}

.support-link {
  color: #5c6bc0;
  text-decoration: none;
}

.support-link:hover {
  text-decoration: underline;
>>>>>>> Stashed changes
}
</style>

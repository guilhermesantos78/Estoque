<template>
    <div class="page-container">
      <NavBar />
      <NavBarProdutos />
      <div class="content">
        <h1 class="page-title">Lista de Produto</h1>
        <!-- Campo de entrada para o ID do cliente -->
        <div class="form-group">
          <label for="clienteId">empresaId:</label>
          <input v-model="empresaId" type="number" id="empresaId" placeholder="Digite o ID da Empresa" class="input-field" />
        </div>
        <!-- Botão para carregar os produtos -->
        <div class="button-container">
          <button @click="listarProdutos" class="btn-load">Carregar Produto</button>
        </div>
        <!-- Listagem dos produtos -->
        <ul class="product-list">
          <li v-for="produto in Produtos" :key="produto.id" class="product-item">
            Id: {{ produto.id }} - Nome: {{ produto.nome }} - Preço: {{ produto.preco }} - Descrição: {{ produto.descricao }} - FornecedorId: {{ produto.fornecedorId }} - EmpresaId: {{ produto.empresaId }}
          </li>
        </ul>
      </div>
    </div>
  </template>
  
  <script>
  import NavBar from '@/components/NavBar.vue';
  import NavBarProdutos from '@/components/Produto/NavBarProdutos.vue';
  
  export default {
    name: 'FormGetProdutoByUserid',
    components: {
      NavBar,
      NavBarProdutos
    },
    data() {
      return {
        Produtos: [],  // Armazena os produtos buscados
        empresaId: '', // V-model para o ID do empresa
      };
    },
    methods: {
      async listarProdutos() {
        const apiUrl = `https://localhost:7248/Produto/cliente/${this.empresaId}`;  // Usa o empresaId no URL
        try {
          const response = await fetch(apiUrl, {
            method: 'GET',
            headers: {
              'Accept': 'application/json',
            },
          });
  
          if (!response.ok) {
            throw new Error('Erro ao buscar os Produtos');
          }
  
          const data = await response.json();
          console.log(data);
          this.Produtos = data; // Atribui os dados ao array 'Produtos'
        } catch (error) {
          console.error('Erro:', error);
        }
      },
    },
  };
  </script>
  
  <style scoped>
  @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap');
  
  .page-container {
    background-color: #f9f9f9;
    color: #333;
    font-family: 'Roboto', sans-serif;
    min-height: 100vh;
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
  }
  
  .content {
    padding: 20px;
    flex: 1;
  }
  
  .page-title {
    font-size: 28px;
    color: #333;
    text-align: center;
    margin-top: 20px;
    margin-bottom: 20px;
  }
  
  .form-group {
    margin-bottom: 20px;
  }
  
  .input-field {
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
    transition: border-color 0.3s ease;
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
  
  .product-list {
    list-style-type: none;
    padding: 0;
    margin: 0 auto;
    max-width: 600px;
  }
  
  .product-item {
    background-color: #f9f9f9;
    margin-bottom: 10px;
    padding: 15px;
    border-radius: 5px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  }
  
  .product-item strong {
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
  
    .product-item {
      padding: 12px;
      font-size: 14px;
    }
  }
  </style>
  
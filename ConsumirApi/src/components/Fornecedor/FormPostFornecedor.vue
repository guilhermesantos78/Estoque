<template>
  <div class="page-container">
    <NavBar />
    <NavBarFornecedores />
    <div class="form-container">
      <h1 class="form-title">Cadastrar Fornecedor</h1>
      <form @submit="CreateFornecedor" class="user-form">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <div class="form-group">
          <label for="nome">Nome :</label>
          <input type="text" id="nome" v-model="nome" required />
        </div>
        <div class="form-group">
          <label for="contato">Contato :</label>
          <input type="text" id="contato" v-model="contato" required />
        </div>
        <div class="form-group">
          <label for="endereco">Endereço :</label>
          <input type="text" id="endereco" v-model="endereco" required />
        </div>
        <div class="form-group">
          <label for="cnpj">CNPJ :</label>
          <input type="text" id="cnpj" v-model="cnpj" required />
        </div>
        <div class="form-group">
          <label for="produtoId">Produto ID :</label>
          <input type="text" id="produtoId" v-model="produtoId" required />
        </div>
        <div class="form-group">
          <label for="nomeProduto">Nome do Produto :</label>
          <input type="text" id="nomeProduto" v-model="nomeProduto" required />
        </div>
        <button type="submit" class="submit-btn">Cadastrar o Fornecedor</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBarFornecedores from './NavBarFornecedores.vue';
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormPostFornecedor',
  components: {
    NavBarFornecedores,
    NavBar
  },
  data() {
    return {
      id: '',
      nome: '',
      contato: '',
      endereco: '',
      cnpj: '',
      produtoId: '',
      nomeProduto: ''
    };
  },
  methods: {
    async CreateFornecedor(e) {
      e.preventDefault();
      const data = {
        id: this.id,
        nome: this.nome,
        contato: this.contato,
        endereco: this.endereco,
        cnpj: this.cnpj,
        produtoId: this.produtoId,
        nomeProduto: this.nomeProduto
      };
      const dataJson = JSON.stringify(data);
      const req = await fetch('https://localhost:7248/Fornecedor/adicionar-fornecedor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });
    },
  },
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

.form-container {
  background-color: white;
  padding: 40px;
  border-radius: 10px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  max-width: 600px;
  width: 100%;
  margin-top: 30px;
}

.form-title {
  text-align: center;
  margin-bottom: 20px;
  color: #333;
  font-size: 24px;
  font-weight: bold;
}

.user-form {
  display: flex;
  flex-direction: column;
}

.form-group {
  margin-bottom: 20px;
}

.form-group label {
  font-weight: bold;
  color: #333;
  margin-bottom: 5px;
  display: block;
}

.form-group input,
.form-group select {
  width: 95%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 16px;
  transition: border-color 0.3s ease;
}

.submit-btn {
  padding: 12px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 18px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.submit-btn:hover {
  background-color: #000;
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
</style>

<template>
  <NavBar />
  <div class="page-container">
    <div class="form-container">
      <h1>Editar Fornecedor</h1>
      <form @submit="EditFornecedor" class="user-form">
        <div v-if="message" :class="['message', message === 'Sucesso ao editar fornecedor.' ? 'success' : 'error']">
          {{ message }}
        </div>
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
        <button type="submit" class="submit-button">Editar o Fornecedor</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormUpdateFornecedor',
  components: {
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
      nomeProduto: '',
      message: ''
    };
  },
  methods: {
    async EditFornecedor(e) {
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
      const response = await fetch('https://localhost:7248/Fornecedor/editar-fornecedor', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });
      if (response.status === 200) {
        this.message = 'Sucesso ao editar fornecedor.';
      } else {
        this.message = 'Erro ao editar fornecedor.';
      }
    },
  },
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

.form-container {
  max-width: 500px;
  margin: 40px auto;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  background-color: #ffffff;
}

.form-container h1 {
  text-align: center;
  color: #333;
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

.submit-button {
  background-color: #333;
  color: white;
  padding: 12px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 18px;
  width: 100%;
  transition: background-color 0.3s;
}

.submit-button:hover {
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

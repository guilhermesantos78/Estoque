<template>
  <div class="page-container">
    <NavBar />
    <NavBarProdutos />
    <div class="form-container">
      <h1 class="form-title">Editar Produto</h1>
      <form @submit="EditUsuario" class="user-form">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <div class="form-group">
          <label for="nome">Nome :</label>
          <input type="text" id="nome" v-model="nome" required />
        </div>
        <div class="form-group">
          <label for="preco">Preço :</label>
          <input type="text" id="preco" v-model="preco" required />
        </div>
        <div class="form-group">
          <label for="Descricao">Descrição :</label>
          <input type="text" id="Descricao" v-model="Descricao" required />
        </div>
        <div class="form-group">
          <label for="QuantidadeEmEstoque">Quantidade em Estoque :</label>
          <input type="text" id="QuantidadeEmEstoque" v-model="QuantidadeEmEstoque" required />
        </div>
        <div class="form-group">
          <label for="FornecedorId">Fornecedor Id :</label>
          <input type="text" id="FornecedorId" v-model="FornecedorId" required />
        </div>
        <div class="form-group">
          <label for="EmpresaId">Empresa Id :</label>
          <input type="text" id="EmpresaId" v-model="EmpresaId" required />
        </div>
        <button type="submit" class="submit-btn">Editar o Produto</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';
import NavBarProdutos from '@/components/Produto/NavBarProdutos.vue';

export default {
  name: 'FormUpdateProduto',
  components: {
    NavBarProdutos,
    NavBar
  },
  data() {
    return {
      id: '',
      nome: '',
      preco: '',
      Descricao: '',
      QuantidadeEmEstoque: '',
      FornecedorId: '',
      EmpresaId: ''
    };
  },
  methods: {
    async EditUsuario(e) {
      e.preventDefault();
      const data = {
        id: this.id,
        nome: this.nome,
        preco: this.preco,
        Descricao: this.Descricao,
        QuantidadeEmEstoque: this.QuantidadeEmEstoque,
        FornecedorId: this.FornecedorId,
        EmpresaId: this.EmpresaId
      };
      const dataJson = JSON.stringify(data);
      const req = await fetch('https://localhost:7248/Produto/editar-produto', {
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

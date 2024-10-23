<template>
  <div>
    <NavBar />
    <NavBarFornecedores />
    <div class="form-container">
      <h1>Deletar Fornecedor</h1>
      <div v-if="message" :class="['message', message === 'Fornecedor deletado com sucesso.' ? 'success' : 'error']">
        {{ message }}
      </div>
      <form @submit="deleteFornecedor" class="delete-form">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <button type="submit" class="delete-button">Deletar Fornecedor</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBarFornecedores from './NavBarFornecedores.vue';
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormDeleteFornecedor',
  components: {
    NavBarFornecedores,
    NavBar
  },
  data() {
    return {
      id: '',
      message: ''
    };
  },
  methods: {
    async deleteFornecedor(e) {
      e.preventDefault();
      try {
        const req = await fetch(`https://localhost:7248/Fornecedor/remover-fornecedor?id=${this.id}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' }
        });
        if (!req.ok) {
          throw new Error('Erro ao deletar');
        }
        this.message = req.status === 200 ? 'Fornecedor deletado com sucesso.' : 'Erro ao deletar Fornecedor.';
      } catch (error) {
        this.message = 'Erro ao deletar Fornecedor.';
        console.error('Erro ao deletar Fornecedor:', error);
      }
    }
  }
};
</script>

<style scoped>
.form-container {
  max-width: 400px;
  margin: 40px auto;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  background-color: #ffffff;
}

.form-container h1 {
  text-align: center;
  margin-bottom: 20px;
  color: #333;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
  color: #555;
}

input {
  width: 95%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 16px;
  transition: border-color 0.3s;
}

.delete-button {
  background-color: #ff0000;
  color: white;
  padding: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
  width: 100%;
  transition: background-color 0.3s;
}

.delete-button:hover {
  background-color: #d10000;
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

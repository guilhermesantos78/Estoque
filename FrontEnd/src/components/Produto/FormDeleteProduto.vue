<template>
<NavBar/>
  <div class="page-container">
    <div class="form-container">
      <h1 class="form-title">Deletar Produto</h1>
      <form @submit="deleteUsuario" class="user-form">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="password" id="id" v-model="id" required />
        </div>
        <button type="submit" class="delete-button">Deletar Produto</button>
      </form>
      <div v-if="message" :class="['message', message === 'Produto deletado com sucesso.' ? 'success' : 'error']">
        {{ message }}
      </div>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';


export default {
  name: 'FormDeleteProduto',
  components:{
    NavBar
  },
  data() {
    return {
      id: '',
      message: ''
    };
  },
  methods: {
    async deleteUsuario(e) {
      e.preventDefault();
      try {
        const req = await fetch(`https://localhost:7248/Produto/remover-produto?id=${this.id}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' }
        });
        if (!req.ok) {
          throw new Error('Erro ao deletar');
        }
        const produto = await req.json();
        console.log('Resposta da API:', produto);
        if (produto) {
          this.message = 'Produto deletado com sucesso.';
          console.log('Sucesso');
        } else {
          this.message = 'Erro ao deletar Produto.';
          console.log('Erro');
        }
      } catch (error) {
        console.error('Erro ao deletar Produto:', error);
      }
    }
  }
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

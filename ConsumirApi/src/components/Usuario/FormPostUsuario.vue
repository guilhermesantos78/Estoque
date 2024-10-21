<template>
  <NavBar />
  <NavBarUsuarios />
  <div class="page-container">
    <div class="form-container">
      <h1 class="form-title">Cadastrar Usuário</h1>
      <form @submit="CreateUsuario" class="user-form">
        <div v-if="message" :class="['message', message === 'Sucesso ao Cadastrar o usuario.' ? 'success' : 'error']">
          {{ message }}</div>
        <div class="form-group">
          <label for="nome">Nome :</label>
          <input type="text" id="nome" v-model="nome" required />
        </div>
        <div class="form-group">
          <label for="username">Username :</label>
          <input type="text" id="username" v-model="username" required />
        </div>
        <div class="form-group">
          <label for="tipousuario">Tipo de Usuário :</label>
          <select id="tipousuario" v-model="tipousuario" required>
            <option value="" disabled>Selecione...</option>
            <option value="admin">Admin</option>
            <option value="cliente">Cliente</option>
          </select>
        </div>
        <div class="form-group">
          <label for="senha">Senha :</label>
          <input type="password" id="senha" v-model="senha" required />
        </div>
        <div class="form-group">
          <label for="email">Email :</label>
          <input type="email" id="email" v-model="email" required />
        </div>
        <button type="submit" class="submit-btn">Cadastrar Usuário</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';
import NavBarUsuarios from '@/components/Usuario/NavBarUsuarios.vue';

export default {
  name: 'FormPostUsuario',
  components: {
    NavBar,
    NavBarUsuarios,
  },
  data() {
    return {
      nome: '',
      username: '',
      tipousuario: '',
      senha: '',
      email: '',
      message: ''
    };
  },
  methods: {
    async CreateUsuario(e) {
      e.preventDefault();

      const data = {
        nome: this.nome,
        username: this.username,
        tipousuario: this.tipousuario,
        senha: this.senha,
        email: this.email,
      };

      const dataJson = JSON.stringify(data);

      const response = await fetch('https://localhost:7248/Usuario/adicionar-usuario', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });

      if (response.status === 200) {
        this.message = 'Sucesso ao Cadastrar o usuario.';
      }
      else {
        this.message = 'Erro ao Cadastrar o usuario.';
      }
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

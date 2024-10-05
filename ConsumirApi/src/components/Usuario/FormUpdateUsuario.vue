<template>
  <div>
    <NavBar />
    <NavBarUsuarios />
    <div class="form-container">
      <h1>Editar Usuário</h1>
      <form @submit="CreateUsuario" class="user-form">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <div class="form-group">
          <label for="nome">Nome :</label>
          <input type="text" id="nome" v-model="nome" required />
        </div>
        <div class="form-group">
          <label for="username">Username :</label>
          <input type="text" id="username" v-model="username" required />
        </div>
        <div class="form-group">
          <label for="senha">Senha :</label>
          <input type="password" id="senha" v-model="senha" required />
        </div>
        <div class="form-group">
          <label for="email">Email :</label>
          <input type="email" id="email" v-model="email" required />
        </div>
        <button type="submit" class="submit-button">Editar o Usuário</button>
      </form>
      <div v-if="message" class="message">{{ message }}</div>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';
import NavBarUsuarios from '@/components/Usuario/NavBarUsuarios.vue';

export default {
  name: 'FormUpdateusuario',
  components: {
    NavBar,
    NavBarUsuarios,
  },
  data() {
    return {
      id: '',
      nome: '',
      username: '',
      senha: '',
      email: '',
      message: '',
    };
  },
  methods: {
    async CreateUsuario(e) {
      e.preventDefault();

      const data = {
        id: this.id,
        nome: this.nome,
        username: this.username,
        senha: this.senha,
        email: this.email,
      };

      const dataJson = JSON.stringify(data);

      const req = await fetch('https://localhost:7248/Usuario/editar-usuario', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });

      if (req.status === 200) {
        this.message = 'Sucesso.';
      } else {
        this.message = 'Erro.';
      }
    },
  },
};
</script>

<style scoped>
.form-container {
  max-width: 500px;
  margin: 40px auto;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  background-color: #ffffff;
}

h1 {
  text-align: center;
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

.submit-button {
  background-color: #333;
  color: white;
  padding: 2em 4rem;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 14px;
  width: 100%;
  transition: background-color 0.3s;
}

.submit-button:hover {
  background-color: #000;
}

.message {
  margin-top: 10px;
  color: green;
  text-align: center;
}
</style>

<template>
  <NavBar />
  <div class="form__container">
    <h1>Editar Usuário</h1>
    <form @submit="CreateUsuario" class="user__form">
      <div class="form__roup">
        <label for="id">Id :</label>
        <input type="text" id="id" v-model="id" required />
      </div>
      <div class="form__group">
        <label for="nome">Nome :</label>
        <input type="text" id="nome" v-model="nome" />
      </div>
      <div class="form__group">
        <label for="username">Username :</label>
        <input type="text" id="username" v-model="username" />
      </div>
      <div class="form__group">
        <label for="senha">Senha :</label>
        <input type="password" id="senha" v-model="senha" />
      </div>
      <div class="form__group">
        <label for="email">Email :</label>
        <input type="email" id="email" v-model="email" />
      </div>
      <button type="submit" class="submit__button">Editar o Usuário</button>
    </form>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormUpdateUsuario',
  components: {
    NavBar
  },
  data() {
    return {
      id: '',
      nome: '',
      username: '',
      tipousuario: 'Cliente',
      senha: '',
      email: ''
    };
  },
  methods: {
    async CreateUsuario(e) {
      e.preventDefault();
      const data = {
        id: this.id,
        nome: this.nome,
        username: this.username,
        tipousuario: this.tipousuario,
        senha: this.senha,
        email: this.email,
      };
      const dataJson = JSON.stringify(data);

      const response = await fetch('https://localhost:7248/Usuario/editar-usuario', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });

      if (response.status === 200) {
        alert('Sucesso ao editar usuarios!');
      }
      else {
        alert('Erro ao editar usuarios!');
      }

    },
  },
};
</script>

<style scoped>
.Main__container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 80vh;
  width: 100%;
}

.form__container {
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

.form__group {
  margin-bottom: 20px;
}

.form__group label {
  font-weight: bold;
  color: #333;
  margin-bottom: 5px;
  display: block;
}

.form__group input,
.form__group select {
  width: 95%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 16px;
  transition: border-color 0.3s ease;
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

.submit__button {
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

.submit__button:hover {
  background-color: #000;
}
</style>

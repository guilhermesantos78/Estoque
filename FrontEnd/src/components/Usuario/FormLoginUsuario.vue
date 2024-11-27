<template>
  <div class="login__container">
    <div class="form__container">
      <h1>Faça Login</h1>
      <form @submit="loginUsuario" class="login__form">
        <div class="form__group">
          <label for="username">Username :</label>
          <input type="text" id="username" v-model="username" required />
        </div>
        <div class="form__group">
          <label for="senha">Senha :</label>
          <input type="password" id="senha" v-model="senha" required />
        </div>
        <button type="submit" class="login__btn">Login</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: 'FormLoginUsuario',
  data() {
    return {
      username: '',
      senha: ''
    };
  },
  methods: {
    async loginUsuario(e) {
      e.preventDefault();

      const data = {
        username: this.username,
        senha: this.senha
      };

      const dataJson = JSON.stringify(data);

      const req = await fetch('https://localhost:7248/Usuario/fazer-login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });

      const usuario = await req.json();
      console.log('Resposta da API:', usuario);

      if (data.username === usuario.username) {

        // Redireciona com base no tipo de usuário
        if (usuario.tipoUsuario === "Cliente") {
          alert('Sucesso ao logar!')
          this.$store.dispatch('setUsuario', usuario);
          this.$router.push('/InitialPageClientes'); // Redireciona para a rota para Clientes

        } else if (usuario.tipoUsuario === "Admin") {
          alert('Sucesso ao logar!')
          this.$store.dispatch('setUsuario', usuario);
          this.$router.push('/InitialPage'); // Redireciona para a rota para Administrador

        } else {
          alert('Tipo de usuário desconhecido!');
        }

        this.username = '';
        this.senha = '';

      }
      else {
        alert('Erro nas credenciais!');
      }
    }
  }
};
</script>

<style scoped>
.login__container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #f5f5f5;
}

.form__container {
  background-color: white;
  padding: 30px;
  border-radius: 10px;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
  width: 350px;
  text-align: center;
}

.login__form .form__group {
  margin-bottom: 15px;
}

.login__form label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
  color: #333;
}

.login__form input {
  width: 95%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 16px;
}

.login__btn {
  width: 100%;
  padding: 10px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 18px;
  cursor: pointer;
  transition: background-color 0.3s ease;
  margin-top: 15px;
}

.login__btn:hover {
  background-color: #000;
}
</style>

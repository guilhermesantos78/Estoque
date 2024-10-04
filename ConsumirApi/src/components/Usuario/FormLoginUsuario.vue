<template>
  <div class="login-container">
    <div class="form-container">
      <h1>Faça Login</h1>
      <form @submit="loginUsuario" class="login-form">
        <div class="form-group">
          <label for="username">Username :</label>
          <input type="text" id="username" v-model="username" required />
        </div>
        <div class="form-group">
          <label for="senha">Senha :</label>
          <input type="password" id="senha" v-model="senha" required />
        </div>
        <button type="submit" class="login-btn">Login</button>
      </form>
      <div v-if="message" :class="['message', message === 'Sucesso.' ? 'success' : 'error']">{{ message }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'FormLoginUsuario',
  data() {
    return {
      username: '',
      senha: '',
      tipoUsuario: 'Cliente', // Valor padrão
      message: ''
    };
  },
  methods: {
    async loginUsuario(e) {
      e.preventDefault();
      this.message = ''; // Limpa a mensagem antes de uma nova tentativa

      const data = {
        username: this.username,
        senha: this.senha
      };

      const dataJson = JSON.stringify(data);

      try {
        const req = await fetch('https://localhost:7248/Usuario/fazer-login', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: dataJson,
        });

        if (!req.ok) {
          throw new Error('Erro no login');
        }

        const usuario = await req.json();
        console.log('Resposta da API:', usuario);

        if (data.username === usuario.username) {
          this.message = 'Sucesso.';
          this.username = '';
          this.senha = '';

          // Redireciona com base no tipo de usuário
          if (usuario.tipoUsuario === "Cliente") {
            this.$router.push('/InitialPageClientes');
          } else if (usuario.tipoUsuario === "Admin") {
            this.$router.push('/InitialPage'); // Adicione a rota para Administrador
          } else {
            this.message = 'Tipo de usuário desconhecido.';
          }
        } else {
          this.message = 'Erro nas credenciais.';
        }

      } catch (error) {
        console.error('Erro ao fazer login:', error);
        this.message = 'Erro ao conectar à API.';
      }
    }
  }
};
</script>

<style scoped>
/* Container principal do login */
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #f5f5f5;
}

/* Formulário */
.form-container {
  background-color: white;
  padding: 30px;
  border-radius: 10px;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
  width: 350px;
  text-align: center;
}

.login-form .form-group {
  margin-bottom: 15px;
}

.login-form label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
  color: #333;
}

.login-form input {
  width: 95%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 16px;
}

.login-btn {
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

.login-btn:hover {
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

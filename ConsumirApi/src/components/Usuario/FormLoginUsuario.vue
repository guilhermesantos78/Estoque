<template>
  <div>
    <div class="form-container">
      <form @submit="loginUsuario">
        <div class="form-group">
          <label for="username">Username :</label>
          <input type="text" id="username" v-model="username" required />
        </div>
        <div class="form-group">
          <label for="senha">Senha :</label>
          <input type="password" id="senha" v-model="senha" required />
        </div>
        <button type="submit">Login</button>
      </form>
      <div v-if="message" class="message">{{ message }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'FormGetUsuario',
  data() {
    return {
      username: '',
      senha: '',
      message: ''
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
          this.$router.push('/CrudUsuarios'); // Redireciona para a nova página
        } else {
          this.message = 'Erro.';
        }

      } catch (error) {
        console.error('Erro ao fazer login:', error);
        this.message = 'Erro ao conectar à API.';
      }
    }
  },
};
</script>

<style scoped>
.message {
  margin-top: 10px;
  color: green; /* Mudar a cor conforme o status */
}
</style>

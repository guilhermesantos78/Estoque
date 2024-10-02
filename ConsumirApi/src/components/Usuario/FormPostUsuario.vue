<template>
  <div>
    <div class="form-container">
      <form @submit="CreateUsuario">
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
          <input type="text" id="senha" v-model="senha" required />
        </div>
        <div class="form-group">
          <label for="email">Email :</label>
          <input type="text" id="email" v-model="email" required />
        </div>
        <button type="submit">Cadastrar o Usuario</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: 'FormPostusuario',
  data() {
    return {
      id: '',
      nome: '',
      username: '',
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
        senha: this.senha,
        email: this.email
      };

      const dataJson = JSON.stringify(data);

      const req = await fetch('https://localhost:7248/Usuario/adicionar-usuario', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });

      

    },
  },
};
</script>


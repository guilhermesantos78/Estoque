<template>
    <div>
      <div class="form-container">
        <form @submit="deleteUsuario">
          <div class="form-group">
            <label for="id">Id :</label>
            <input type="password" id="id" v-model="id" required />
          </div>
          <button type="submit">Deletar Produto</button>
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
        id: '',
        message: ''
      };
    },
    methods: {
      async deleteUsuario(e) {
        e.preventDefault();
  
        try {
          const req = await fetch(`https://localhost:7248/Usuario/deletar-usuario?id=${this.id}`, {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' }
          });
  
          if (!req.ok) {
            throw new Error('Erro ao deletar');
          }
  
          const usuario = await req.json();
          console.log('Resposta da API:', usuario);
  
          if (usuario) { // Verifique conforme sua lógica de resposta
            this.message = 'Usuário deletado com sucesso.';
            console.log('Sucesso');
            this.$router.push('/pagina-de-sucesso'); // Redireciona para a nova página
          } else {
            this.message = 'Erro ao deletar usuário.';
            console.log('Erro');
          }
  
        } catch (error) {
          console.error('Erro ao deletar usuário:', error);
        }
      }
    }
  };
  </script>
  
  <style scoped>
  .message {
    margin-top: 10px;
    color: green; /* Mudar a cor conforme o status */
  }
  </style>
  
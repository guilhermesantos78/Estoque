<template>
  <div>
    <NavBar />
    <NavBarUsuarios />
    <div class="form-container">
      <h1>Deletar Usuário</h1>
      <form @submit="deleteUsuario" class="delete-form">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <button type="submit" class="delete-button">Deletar Usuário</button>
      </form>
      <div v-if="message" class="message">{{ message }}</div>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';
import NavBarUsuarios from '@/components/Usuario/NavBarUsuarios.vue';

export default {
  name: 'FormDeleteUsuario',
  components: {
    NavBar,
    NavBarUsuarios,
  },
  data() {
    return {
      id: '',
      message: '',
    };
  },
  methods: {
    async deleteUsuario(e) {
      e.preventDefault();

      try {
        const req = await fetch(`https://localhost:7248/Usuario/deletar-usuario?id=${this.id}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' },
        });

        if (!req.ok) {
          throw new Error('Erro ao deletar');
        }

        const usuario = await req.json();
        console.log('Resposta da API:', usuario);

        if (usuario) {
          this.message = 'Usuário deletado com sucesso.';
          console.log('Sucesso');
        } else {
          this.message = 'Erro ao deletar usuário.';
          console.log('Erro');
        }
      } catch (error) {
        console.error('Erro ao deletar usuário:', error);
      }
    }
  }
}
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

h1 {
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
  margin-top: 10px;
  color: green;
  text-align: center;
}
</style>

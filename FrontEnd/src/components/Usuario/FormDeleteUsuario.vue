<template>
  <NavBar />
  <div class="Main__container">
    <div class="form__container">
      <h1>Deletar Usuário</h1>
      <form @submit="deleteUsuario" class="delete__form">
        <div class="form__group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <button type="submit" class="delete__button">Deletar Usuário</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormDeleteUsuario',
  components: {
    NavBar
  },
  data() {
    return {
      id: ''
    };
  },
  methods: {
    async deleteUsuario(e) {
      e.preventDefault();
      try {
        const response = await fetch(`https://localhost:7248/Usuario/deletar-usuario?id=${this.id}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' },
        });

        if (response.status === 200) {
          alert('Sucesso ao deletar o usuario!')
        }
        else {
          alert('Erro ao deletar o usuario!')
        }

      } catch (error) {
        alert('Erro ao Conectar a API!');
      }
    },
  },
};
</script>

<style scoped>
.Main__container {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 80vh;
  width: 100%;
}

.form__container {
  max-width: 450px;
  width: 400px;
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

.form__group {
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

.delete__button {
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
</style>

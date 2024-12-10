<template>
  <NavBar />
  <div class="Main__container">
    <div class="form__container">
      <h1 class="form__title">Deletar Produto</h1>
      <form @submit="deleteUsuario" class="user__form">
        <div class="form__group">
          <label for="id">Id :</label>
          <input type="password" id="id" v-model="id" required />
        </div>
        <button type="submit" class="delete__button">Deletar Produto</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';


export default {
  name: 'FormDeleteProduto',
  components: {
    NavBar
  },
  data() {
    return {
      id: ''
    };
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario; // Acessando o usuário do Vuex Store
    }
  },
  methods: {
    async deleteUsuario(e) {
      e.preventDefault();
      try {
        const response = await fetch(`https://localhost:7248/Produto/remover-produto?id=${this.id}&EmpresaId=${this.usuario.id}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' }
        });

        if (response.status === 200) {
          alert('Produto deletado com sucesso!');
        }
        else {
          alert('Erro ao deletar Produto!');
        }
      } catch (error) {
        console.error(error);
      }
    }
  }
};
</script>

<style scoped>
.Main__container {
  font-family: "Funnel Display", sans-serif;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 80vh;
  width: 100%;
}

.form__container {
  background-color: white;
  padding: 40px;
  border-radius: 10px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  max-width: 600px;
  width: 100%;
  margin-top: 30px;
}

.form__title {
  text-align: center;
  margin-bottom: 20px;
  color: #333;
  font-size: 24px;
  font-weight: bold;
}

.user__form {
  display: flex;
  flex-direction: column;
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

.delete__button:hover {
  background-color: #d10000;
}
</style>

<template>
  <NavBar />
  <div class="Main__container">
    <div class="form__container">
      <h1>Deletar Fornecedor</h1>
      <form @submit="deleteFornecedor" class="delete__form">
        <div class="form__group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <button type="submit" class="delete__button">Deletar Fornecedor</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormDeleteFornecedor',
  components: {
    NavBar
  },
  data() {
    return {
      id: '',
      message: ''
    };
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario; // Acessando o usuário do Vuex Store
    }
  },
  methods: {
    async deleteFornecedor(e) {
      e.preventDefault();
      try {
        const response = await fetch(`https://localhost:7248/Fornecedor/remover-fornecedor?id=${this.id}&EmpresaId=${this.usuario.id}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' }
        });

        if (response.status === 200) {
          alert('Fornecedor deletado com sucesso!')
        }
        else {
          alert('Erro ao deletar o fornecedor!')
        }

      } catch (error) {
        console.log(error)
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
  height: 100vh;
  width: 100%;
}

.form__container {
  max-width: 400px;
  margin: 40px auto;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  background-color: #ffffff;
}

.form__container h1 {
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

.delete__button:hover {
  background-color: #d10000;
}
</style>

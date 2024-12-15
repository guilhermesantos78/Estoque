<template>
  <NavBar />
  <div class="Main__container">
    <div class="form__container">
      <h1>Editar Fornecedor</h1>
      <form @submit="EditFornecedor" class="user__form">
        <div class="form__group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <div class="form__group">
          <label for="nome">Nome :</label>
          <input type="text" id="nome" v-model="nome" required />
        </div>
        <div class="form__group">
          <label for="contato">Contato :</label>
          <input type="text" id="contato" v-model="contato" required />
        </div>
        <div class="form__group">
          <label for="endereco">Endereço :</label>
          <input type="text" id="endereco" v-model="endereco" required />
        </div>
        <div class="form__group">
          <label for="cnpj">CNPJ :</label>
          <input type="text" id="cnpj" v-model="cnpj" required />
        </div>
        <div class="form__group">
          <label for="produtoId">Produto ID :</label>
          <input type="text" id="produtoId" v-model="produtoId" required />
        </div>
        <button type="submit" class="submit__button">Editar o Fornecedor</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormUpdateFornecedor',
  components: {
    NavBar
  },
  data() {
    return {
      id: '',
      nome: '',
      contato: '',
      endereco: '',
      cnpj: '',
      produtoId: '',
      nomeProduto: '',
      message: ''
    };
  },
  computed: {
    // Acessando o usuario via Vuex
    usuario() {
      return this.$store.getters.getUsuario; // Supondo que o getter 'getUsuario' retorna os dados do usuário
    }
  },
  methods: {
    async EditFornecedor(e) {
      e.preventDefault();
      const data = {
        id: this.id,
        nome: this.nome,
        contato: this.contato,
        endereco: this.endereco,
        cnpj: this.cnpj,
        produtoId: this.produtoId,
        empresaId: this.usuario.id
      };
      const dataJson = JSON.stringify(data);
      const response = await fetch(`https://localhost:7248/Fornecedor/editar-fornecedor?EmpresaId=${this.usuario.id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });
      if (response.status === 200) {
        alert('Sucesso ao editar fornecedor.');
      } else {
        alert('Erro ao editar fornecedor.');
      }
    },
  },
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
  max-width: 500px;
  margin: 40px auto;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  background-color: #ffffff;
}

.form__container h1 {
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

.submit__button {
  background-color: #333;
  color: white;
  padding: 12px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 18px;
  width: 100%;
  transition: background-color 0.3s;
}

.submit__button:hover {
  background-color: #000;
}
</style>

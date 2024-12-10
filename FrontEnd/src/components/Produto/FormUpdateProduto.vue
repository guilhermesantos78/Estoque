<template>
  <NavBar />
  <div class="Main__container">
    <div class="form__container">
      <h1 class="form__title">Editar Produto</h1>
      <form @submit="EditUsuario" class="user__form">
        <div class="form__group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <div class="form__group">
          <label for="nome">Nome :</label>
          <input type="text" id="nome" v-model="nome" required />
        </div>
        <div class="form__group">
          <label for="preco">Preço :</label>
          <input type="text" id="preco" v-model="preco" required />
        </div>
        <div class="form__group">
          <label for="Descricao">Descrição :</label>
          <input type="text" id="Descricao" v-model="Descricao" required />
        </div>
        <div class="form__group">
          <label for="QuantidadeEmEstoque">Quantidade em Estoque :</label>
          <input type="text" id="QuantidadeEmEstoque" v-model="QuantidadeEmEstoque" required />
        </div>
        <div class="form__group">
          <label for="FornecedorId">Fornecedor Id :</label>
          <input type="text" id="FornecedorId" v-model="FornecedorId" required />
        </div>
        <div class="form__group">
          <label for="EmpresaId">Empresa Id :</label>
          <input type="text" id="EmpresaId" v-model="EmpresaId" required />
        </div>
        <button type="submit" class="submit__btn">Editar o Produto</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormUpdateProduto',
  components: {
    NavBar
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario; // Acessando o usuário do Vuex Store
    }
  },
  data() {
    return {
      id: '',
      nome: '',
      preco: '',
      Descricao: '',
      QuantidadeEmEstoque: '',
      FornecedorId: '',
      EmpresaId: ''
    };
  },
  methods: {
    async EditUsuario(e) {
      e.preventDefault();
      const data = {
        id: this.id,
        nome: this.nome,
        preco: this.preco,
        Descricao: this.Descricao,
        QuantidadeEmEstoque: this.QuantidadeEmEstoque,
        FornecedorId: this.FornecedorId,
        EmpresaId: this.EmpresaId
      };
      const dataJson = JSON.stringify(data);
      const req = await fetch(`https://localhost:7248/Produto/editar-produto?EmpresaId=${this.usuario.id}`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });
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
  height: 140vh;
  width: 100%;
}

.form__container {
  background-color: white;
  padding: 40px;
  border-radius: 10px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  max-width: 800px;
  height: 700px;
  width: 100%;
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

.submit__btn {
  padding: 12px;
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 18px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.submit__btn:hover {
  background-color: #1A5276;
}
</style>

<template>
  <NavBar />
  <div class="Main__container">
    <div class="form__container">
      <h1 class="form__title">Cadastrar Produto</h1>
      <form @submit="CreateUsuario" class="user__form">
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
        <button type="submit" class="submit__btn">Cadastrar o Produto</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormPostProduto',
  components: {
    NavBar
  },
  data() {
    return {
      nome: '',
      preco: '',
      Descricao: '',
      QuantidadeEmEstoque: '',
      FornecedorId: '',
    };
  },
  computed: {
    usuario() {
      return this.$store.getters.getUsuario; // Acessando o usuário do Vuex Store
    }
  },
  methods: {
    async CreateUsuario(e) {
      e.preventDefault();
      const data = {
        id: null,
        nome: this.nome,
        preco: this.preco,
        Descricao: this.Descricao,
        QuantidadeEmEstoque: this.QuantidadeEmEstoque,
        FornecedorId: this.FornecedorId,
        EmpresaId: this.usuario.id
      };
      const dataJson = JSON.stringify(data);

      try {
        const response = await fetch('https://localhost:7248/Produto/adicionar-produto', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: dataJson,
        });

        if (response.status === 200) {
          alert('Sucesso ao adicionar o Produto!');
        } else {
          alert('Erro ao adicionar o produto.');
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style scoped>
.Main__container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 80vh;
  width: 100%;
  font-family: "Funnel Display", sans-serif;
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

.form__group input {
  width: 95%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 16px;
  transition: border-color 0.3s ease;
}

.submit__btn {
  padding: 12px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 18px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.submit__btn:hover {
  background-color: #000;
}
</style>

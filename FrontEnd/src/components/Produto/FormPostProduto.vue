<template>
  <NavBar />
  <div class="Main__container">
    <div class="form-container">
      <h1 class="form-title">Cadastrar Produto</h1>
      <form @submit="CreateUsuario" class="user-form">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <div class="form-group">
          <label for="nome">Nome :</label>
          <input type="text" id="nome" v-model="nome" required />
        </div>
        <div class="form-group">
          <label for="preco">Preço :</label>
          <input type="text" id="preco" v-model="preco" required />
        </div>
        <div class="form-group">
          <label for="Descricao">Descrição :</label>
          <input type="text" id="Descricao" v-model="Descricao" required />
        </div>
        <div class="form-group">
          <label for="QuantidadeEmEstoque">Quantidade em Estoque :</label>
          <input type="text" id="QuantidadeEmEstoque" v-model="QuantidadeEmEstoque" required />
        </div>
        <div class="form-group">
          <label for="FornecedorId">Fornecedor Id :</label>
          <input type="text" id="FornecedorId" v-model="FornecedorId" required />
        </div>
        <div class="form-group">
          <label for="EmpresaId">Empresa Id :</label>
          <input type="text" id="EmpresaId" v-model="EmpresaId" required />
        </div>
        <button type="submit" class="submit-btn">Cadastrar o Produto</button>
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
    async CreateUsuario(e) {
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

      try {
        const response = await fetch('https://localhost:7248/Produto/adicionar-produto', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: dataJson,
        });

        if (response.status === 200) {
          alert('Sucesso ao adicionar o Produto!')
        }
        else {
          alert('Erro ao adicionar o produto')
        }
      }
      catch (error) {
        console.log(error)
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

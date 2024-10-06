<template>
  <NavBar />
  <NavBarFornecedores />
  <div>
    <div class="form-container">
      <form @submit="CreateFornecedor">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="text" id="id" v-model="id" required />
        </div>
        <div class="form-group">
          <label for="nome">Nome :</label>
          <input type="text" id="nome" v-model="nome" required />
        </div>
        <div class="form-group">
          <label for="contato">Contato :</label>
          <input type="text" id="contato" v-model="contato" required />
        </div>
        <div class="form-group">
          <label for="endereco">Endereco :</label>
          <input type="text" id="endereco" v-model="endereco" required />
        </div>
        <div class="form-group">
          <label for="cnpj">Cnpj :</label>
          <input type="text" id="cnpj" v-model="cnpj" required />
        </div>
        <div class="form-group">
          <label for="produtoId">ProdutoId :</label>
          <input type="text" id="produtoId" v-model="produtoId" required />
        </div>
        <div class="form-group">
          <label for="nomeProduto">Nome Produto :</label>
          <input type="text" id="nomeProduto" v-model="nomeProduto" required />
        </div>
        <button type="submit">Cadastrar o Fornecedor</button>
      </form>
    </div>
  </div>
</template>

<script>
import NavBarFornecedores from './NavBarFornecedores.vue';
import NavBar from '@/components/NavBar.vue';
export default {
  name: 'FormPostFornecedor',
  components: {
    NavBarFornecedores,
    NavBar
  },
  data() {
    return {
      id: '',
      Nome: '',
      contato: '',
      endereco: '',
      cnpj: '',
      produtoId: '',
      nomeProduto: ''
    };
  },
  methods: {
    async CreateFornecedor(e) {
      e.preventDefault();

      const data = {
        Id: this.Id,
        Nome: this.Nome,
        contato: this.contato,
        endereco: this.endereco,
        cnpj: this.cnpj,
        produtoId: this.produtoId,
        nomeProduto: this.nomeProduto
      };

      const dataJson = JSON.stringify(data);

      const req = await fetch('https://localhost:7248/Fornecedor/adicionar-fornecedor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: dataJson,
      });


    },
  },
};
</script>
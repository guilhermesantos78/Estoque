<template>
    <NavBar />
    <NavBarProdutos />
    <div>
      <div class="form-container">
        <form @submit="EditUsuario">
          <div class="form-group">
            <label for="id">Id :</label>
            <input type="text" id="id" v-model="id" required />
          </div>
          <div class="form-group">
            <label for="nome">Nome :</label>
            <input type="text" id="nome" v-model="nome" required />
          </div>
          <div class="form-group">
            <label for="preco">Preco :</label>
            <input type="text" id="preco" v-model="preco" required />
          </div>
          <div class="form-group">
            <label for="Descricao">Descricao :</label>
            <input type="text" id="Descricao" v-model="Descricao" required />
          </div>
          <div class="form-group">
            <label for="QuantidadeEmEstoque">Quantidade em estoque :</label>
            <input type="text" id="QuantidadeEmEstoque" v-model="QuantidadeEmEstoque" required />
          </div>
          <div class="form-group">
            <label for="FornecedorId">FornecedorId :</label>
            <input type="text" id="FornecedorId" v-model="FornecedorId" required />
          </div>
          <button type="submit">Editar o Produto</button>
        </form>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'FormUpdateusuario',
    components:{
      NavBarProdutos
    },
    data() {
      return {
        id: '',
        Nome: '',
        Preco: '',
        Descricao: '',
        QuantidadeEmEstoque: '',
        FornecedorId: ''
      };
    },
    methods: {
      async EditUsuario(e) {
        e.preventDefault();
  
        const data = {
          Id: this.Id,
          Nome: this.Nome,
          Preco: this.Preco,
          Descricao: this.Descricao,
          QuantidadeEmEstoque: this.QuantidadeEmEstoque,
          FornecedorId: this.FornecedorId
          };
  
        const dataJson = JSON.stringify(data);
  
        const req = await fetch('https://localhost:7248/Produto/editar-produto', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: dataJson,
        });
  
      },
    },
  };
  </script>
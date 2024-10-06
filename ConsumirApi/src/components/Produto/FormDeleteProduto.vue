<template>
  <NavBar />
  <NavBarProdutos />
  <div>
    <div class="form-container">
      <form @submit="deleteUsuario">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="password" id="id" v-model="id" required />
        </div>
        <button type="submit">Deletar Produto</button>
      </form>
      <div v-if="message" class="message">{{ message }}</div>
    </div>
  </div>
</template>

<script>
import NavBarProdutos from './NavBarProdutos.vue';

export default {
  name: 'FormDeleteProduto',
  components: {
    NavBarProdutos
  },
  data() {
    return {
      id: '',
      message: ''
    };
  },
  methods: {
    async deleteUsuario(e) {
      e.preventDefault();

      try {
        const req = await fetch(`https://localhost:7248/Produto/remover-produto?id=${this.id}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' }
        });

        if (!req.ok) {
          throw new Error('Erro ao deletar');
        }

        const produto = await req.json();
        console.log('Resposta da API:', produto);

        if (produto) {
          this.message = 'Produto deletado com sucesso.';
          console.log('Sucesso');
        } else {
          this.message = 'Erro ao deletar Produto.';
          console.log('Erro');
        }

      } catch (error) {
        console.error('Erro ao deletar Produto:', error);
      }
    }
  }
};
</script>

<style scoped>
.message {
  margin-top: 10px;
  color: green;
  /* Mudar a cor conforme o status */
}
</style>
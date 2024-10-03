<template>
  <NavBar />
  <NavBarFornecedores />
  <div>
    <div class="form-container">
      <form @submit="deleteFornecedor">
        <div class="form-group">
          <label for="id">Id :</label>
          <input type="password" id="id" v-model="id" required />
        </div>
        <button type="submit">Deletar Fornecedor</button>
      </form>
      <div v-if="message" class="message">{{ message }}</div>
    </div>
  </div>
</template>

<script>
import NavBarFornecedores from './NavBarFornecedores.vue';
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'FormGetUsuario',
  components: {
    NavBarFornecedores,
    NavBar
  },
  data() {
    return {
      id: '',
      message: ''
    };
  },
  methods: {
    async deleteFornecedor(e) {
      e.preventDefault();

      try {
        const req = await fetch(`https://localhost:7248/Fornecedor/deletar-fornecedor?id=${this.id}`, {
          method: 'DELETE',
          headers: { 'Content-Type': 'application/json' }
        });

        if (!req.ok) {
          throw new Error('Erro ao deletar');
        }

        const Fornecedor = await req.json();
        console.log('Resposta da API:', Fornecedor);

        if (Fornecedor) {
          this.message = 'Fornecedor deletado com sucesso.';
          console.log('Sucesso');
        } else {
          this.message = 'Erro ao deletar Fornecedor.';
          console.log('Erro');
        }

      } catch (error) {
        console.error('Erro ao deletar Fornecedor:', error);
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
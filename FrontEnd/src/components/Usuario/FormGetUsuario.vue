<template>
  <NavBar />
  <div class="Main__container">
    <h1 class="page__title">Lista de Usuários</h1>

    <div class="button__container">
      <button class="btn__load" @click="listarUsuarios">Carregar Usuários</button>
    </div>

    <ul class="user__list">
      <li v-for="usuario in usuarios" :key="usuario.id" class="user__item">
        <span><strong>Id:</strong> {{ usuario.id }}</span> -
        <span><strong>Usuário:</strong> {{ usuario.nome }}</span> -
        <span><strong>Username:</strong> {{ usuario.username }}</span> -
        <span><strong>Email:</strong> {{ usuario.email }}</span> -
        <span><strong>Tipo Usuário:</strong> {{ usuario.tipoUsuario }}</span>
      </li>
    </ul>
  </div>
</template>

<script scoped>
import NavBar from '@/components/NavBar.vue'

export default {
  name: 'FormGetUsuario',
  components: {
    NavBar
  },
  data() {
    return {
      usuarios: [],
      empresaId:''
    };
  },
  mounted() {
    this.empresaId = this.usuario.empresaId; // Acessar o usuario via this.usuario
    console.log(this.usuario);
  },
  computed: {
    // Acessando o usuario via Vuex
    usuario() {
      return this.$store.getters.getUsuario; // Supondo que o getter 'getUsuario' retorna os dados do usuário
    }
  },
  methods: {
    async listarUsuarios() {
      const apiUrl = `https://localhost:7248/Usuario/usuario/${this.empresaId}`;
      try {
        const response = await fetch(apiUrl, {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
          },
        });

        if (response.status === 200) {
          this.usuarios = await response.json();
          alert('Sucesso ao listar usuarios!');
        }
        else {
          alert('Erro ao listar usuarios!');
        }

      } catch (error) {
        alert('Erro ao Conectar a API!');
      }
    },
  },
};
</script>

<style>
.Main__container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 80vh;
  width: 100%;
}

.page__title {
  font-size: 28px;
  color: #333;
  text-align: center;
  margin-top: 20px;
  margin-bottom: 20px;
  font-family: "Funnel Display", sans-serif;
}

.button__container {
  text-align: center;
  margin-bottom: 20px;
}

.btn__load {
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.btn__load:hover {
  background-color: #000;
}

.user__list {
  list-style-type: none;
  padding: 0;
  margin: 0 auto;
  max-width: 600px;
}

.user__item {
  background-color: #f9f9f9;
  margin-bottom: 10px;
  padding: 15px;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  font-family: "Funnel Display", sans-serif;
}

.user__item strong {
  color: #555;
}

@media (max-width: 600px) {
  .page__title {
    font-size: 24px;
    margin: 15px;
  }

  .btn__load {
    width: 100%;
    padding: 12px 0;
  }

  .user__item {
    padding: 12px;
    font-size: 14px;
  }
}
</style>

<template>
  <div>
    <NavBar />
    <NavBarUsuarios />
    <!-- Título da página -->
    <h1 class="page-title">Lista de Usuários</h1>

    <!-- Botão para carregar usuários -->
    <div class="button-container">
      <button class="btn-load" @click="listarUsuarios">Carregar Usuários</button>
    </div>

    <!-- Lista de usuários -->
    <ul class="user-list">
      <li v-for="usuario in usuarios" :key="usuario.id" class="user-item">
        <span><strong>Id:</strong> {{ usuario.id }}</span> -
        <span><strong>Usuário:</strong> {{ usuario.nome }}</span> -
        <span><strong>Senha:</strong> {{ usuario.senha}}</span>

      </li>
    </ul>

  </div>
</template>

<script scoped>
import NavBar from '@/components/NavBar.vue'
import NavBarUsuarios from '@/components/Usuario/NavBarUsuarios.vue'

export default {
  name: 'FormGetUsuario',
  components: {
    NavBar,
    NavBarUsuarios
  },
  data() {
    return {
      usuarios: [],
      message: ''
    };
  },
  methods: {
    async listarUsuarios() {
      const apiUrl = 'https://localhost:7248/Usuario/listar-usuario';

      try {

        const response = await fetch(apiUrl, {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
          },
        });

        if (!response.ok) {
          throw new Error('Network response was not ok');
        }

        this.usuarios = await response.json();

      } catch (error) {
        console.error('Erro:', error);
      }
    },
  },
};
</script>

<style>
.page-title {
  font-size: 28px;
  color: #333;
  text-align: center;
  margin-top: 20px;
  margin-bottom: 20px;
  font-family: 'Arial', sans-serif;
}

.button-container {
  text-align: center;
  margin-bottom: 20px;
}

.btn-load {
  padding: 10px 20px;
  background-color: #333;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.btn-load:hover {
  background-color: #000;
}

.user-list {
  list-style-type: none;
  padding: 0;
  margin: 0 auto;
  max-width: 600px;
}

.user-item {
  background-color: #f9f9f9;
  margin-bottom: 10px;
  padding: 15px;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  font-family: 'Arial', sans-serif;
}

.user-item strong {
  color: #555;
}
</style>

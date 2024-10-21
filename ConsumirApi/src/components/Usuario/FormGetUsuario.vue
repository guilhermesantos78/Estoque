<template>
  <div>
    <NavBar />
    <NavBarUsuarios />
    <!-- Título da página -->
    <h1 class="page-title">Lista de Usuários</h1>
    <!-- Botão para carregar usuários -->
    <div class="button-container">
      <button class="btn-load" @click="listarUsuarios">Carregar Usuários</button>
      <div v-if="message" :class="['message', message === 'Sucesso ao listar usuarios.' ? 'success' : 'error']">{{ message }}</div>
    </div>
    <!-- Lista de usuários -->
    <ul class="user-list">
      <li v-for="usuario in usuarios" :key="usuario.id" class="user-item">
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
        if (response.status === 200) {
          this.usuarios = await response.json();
          this.message = 'Sucesso ao listar usuarios.';
        } else {
          this.message = 'Erro ao listar usuarios.';
        }
      } catch (error) {
        console.error('Erro:', error);
        this.message = 'Erro ao listar usuarios.';
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
.message {
  margin-top: 15px;
  font-size: 16px;
}
.success {
  color: green;
}
.error {
  color: red;
}

/* Responsividade */
@media (max-width: 600px) {
  .page-title {
    font-size: 24px;
    margin: 15px;
  }
  .btn-load {
    width: 100%;
    padding: 12px 0;
  }
  .user-item {
    padding: 12px;
    font-size: 14px;
  }
}
</style>

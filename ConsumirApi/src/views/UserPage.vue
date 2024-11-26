<template>
  <div class="user-page">
    <NavBar />
    <div class="user-info">
      <h1 class="greeting">Bem-vindo, <span class="username">{{ usuario.username }}</span>!</h1>
      <div class="user-details">
        <div class="detail-item">
          <strong>Nome:</strong> {{ usuario.nome }}
        </div>
        <div class="detail-item">
          <strong>Email:</strong> {{ usuario.email }}
        </div>
        <div class="detail-item">
          <strong>Tipo de Usuário:</strong> {{ usuario.tipoUsuario }}
        </div>
        <div class="detail-item">
          <strong>Senha:</strong> ********
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'UserPage',
  computed: {
    usuario() {
      return this.$store.getters.getUsuario; // Acessando o usuário do Vuex Store
    }
  },
  methods: {
    logout() {
      // Implementação do logout (exemplo: limpar o estado do Vuex e redirecionar)
      this.$store.dispatch('logout');
      this.$router.push('/login');
    }
  },
  components: {
    NavBar
  }
};
</script>

<style scoped>
.user-page {
  font-family: 'Roboto', sans-serif;
  background: linear-gradient(145deg, #f2f2f2, #d1d1d1);
  display: flex;
  flex-direction: column;
  align-items: center;
  height: 100vh;
  min-height: 100vh;
}

.user-info {
  background-color: #fff;
  border-radius: 10px;
  padding: 30px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
  width: 100%;
  height: 100vh;
  text-align: center;
  overflow: au;
  animation: fadeIn 1s ease-out;
  padding: 40px 20px;
}

.greeting {
  font-size: 2rem;
  color: #4CAF50;
  font-weight: 700;
  margin-bottom: 20px;
}

.username {
  color: #00796b;
  font-style: italic;
}

.user-details {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  margin: 20px 0;
  padding: 10px 0;
}

.detail-item {
  font-size: 1.1rem;
  color: #333;
  margin: 10px 0;
  padding-left: 20px;
  border-left: 4px solid #00796b;
}

@keyframes fadeIn {
  0% {
    opacity: 0;
    transform: translateY(-50px);
  }

  100% {
    opacity: 1;
    transform: translateY(0);
  }
}

/* Mobile Responsiveness */
@media (max-width: 768px) {
  .user-info {
    width: 90%;
    padding: 20px;
  }

  .greeting {
    font-size: 1.5rem;
  }

  .detail-item {
    font-size: 1rem;
  }
}
</style>

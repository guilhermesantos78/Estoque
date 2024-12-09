<template>
  <div class="navBar">
    <div class="menu__icon" @click="toggleMenu">
      ☰
    </div>

    <nav :class="{ 'sidebar': true, 'sidebar__open': isMenuOpen }">
      <RouterLink to="/InitialPageClientes" class="nav__link">Home</RouterLink>

      <div class="sidebar__item" @click="mostrarCarrinho">
        <button>Carrinho ({{ Carrinho.length }})</button>
      </div>

      <div v-if="!usuario">
        <RouterLink to="FormLoginUsuario" class="nav__link">Log in</RouterLink>
      </div>
      <div v-else>
        <RouterLink to="UserPage" class="nav__link">{{ usuario.username }}</RouterLink>
      </div>

      <RouterLink to="/" class="nav__link" @click="logout">Logout</RouterLink>
    </nav>
  </div>
  <div class="user-page">
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
export default {
  name: 'UserPageClientes',
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


.navBar {
  display: flex;
  justify-content: flex-end;
  background-color: #ededed;
  padding: 10px;
}

.menu__icon {
  font-size: 30px;
  cursor: pointer;
  color: #333;
  margin-right: 20px;
}

.sidebar {
  position: fixed;
  top: 0;
  left: 0;
  width: 250px;
  height: 100%;
  background-color: #FFF;
  box-shadow: 2px 0 5px rgba(0, 0, 0, 0.2);
  padding-top: 60px;
  transition: transform 0.3s ease;
  transform: translateX(-250px);
}

.sidebar__open {
  transform: translateX(0);
}

.sidebar__item {
  padding: 10px 20px;
  cursor: pointer;
}

.sidebar__item button {
  padding: 10px 20px;
  cursor: pointer;
  border:3px solid #ededed;
  border-radius: 8px;
}

.nav__link {
  display: block;
  padding: 10px 20px;
  text-decoration: none;
  color: #333;
  background-color: rgba(255, 255, 255, 0.2);
  border-radius: 5px;
  transition: background-color 0.3s ease, color 0.3s;
}

.nav__link:hover {
  background-color: rgba(0, 0, 0, 0.1);
  color: #007bff;
}

.user-page {
  font-family: "Funnel Display", sans-serif;
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
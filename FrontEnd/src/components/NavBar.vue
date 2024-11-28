<template>
  <div class="navBar">
    <div class="menu__icon" @click="toggleMenu">
      ☰
    </div>

    <nav :class="{ 'sidebar': true, 'sidebar__pen': isMenuOpen, 'sidebar__open': isMenuOpen }">
      <RouterLink to="/InitialPage" class="nav__link">Home</RouterLink>
      <div class="sidebar__item" @click="toggleDropdown('produtos')">
        Produtos
        <div v-if="dropdown.produtos" class="dropdown">
          <RouterLink to="/FormGetProduto" class="nav__link">Listar</RouterLink>
          <RouterLink to="/FormGetProdutoByEmpresaid" class="nav__link">ListarPorEmpresa</RouterLink>
          <RouterLink to="/FormPostProduto" class="nav__link">Criar</RouterLink>
          <RouterLink to="/FormUpdateProduto" class="nav__link">Editar</RouterLink>
          <RouterLink to="/FormDeleteProduto" class="nav__link">Deletar</RouterLink>
        </div>
      </div>

      <div class="sidebar__item" @click="toggleDropdown('fornecedores')">
        Fornecedores
        <div v-if="dropdown.fornecedores" class="dropdown">
          <RouterLink to="/FormGetFornecedor" class="nav__link">Listar</RouterLink>
          <RouterLink to="/FormPostFornecedor" class="nav__link">Criar</RouterLink>
          <RouterLink to="/FormUpdateFornecedor" class="nav__link">Editar</RouterLink>
          <RouterLink to="/FormDeleteFornecedor" class="nav__link">Deletar</RouterLink>
        </div>
      </div>

      <div class="sidebar__item" @click="toggleDropdown('usuarios')">
        Usuários
        <div v-if="dropdown.usuarios" class="dropdown">
          <RouterLink to="/FormGetUsuario" class="nav__link">Listar</RouterLink>
          <RouterLink to="/FormPostUsuario" class="nav__link">Criar</RouterLink>
          <RouterLink to="/FormUpdateUsuario" class="nav__link">Editar</RouterLink>
          <RouterLink to="/FormDeleteUsuario" class="nav__link">Deletar</RouterLink>
        </div>
      </div>

      <RouterLink to="/" class="nav__link">Logout</RouterLink>
    </nav>
  </div>
</template>

<script>
export default {
  name: 'NavBar',
  data() {
    return {
      isMenuOpen: false,
      dropdown: {
        produtos: false,
        fornecedores: false,
        usuarios: false
      }
    };
  },
  methods: {
    toggleMenu() {
      this.isMenuOpen = !this.isMenuOpen;
    },
    toggleDropdown(menu) {
      this.dropdown[menu] = !this.dropdown[menu];
    }
  }
}
</script>

<style scoped>
.navBar {
  display: flex;
  justify-content: flex-end;
  background-color: #ededed;
}

.menu__icon {
  font-size: 30px;
  cursor: pointer;
  margin: 20px;
  color: #333;
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

.nav__link {
  display: block;
  padding: 8px 20px;
  text-decoration: none;
  color: #000;
  background-color: rgba(255, 255, 255, 0.2);
  transition: background-color 0.3s;
}

.nav__link:hover {
  background-color: rgba(0, 0, 0, 0.1);
}

.dropdown {
  padding-left: 20px;
  display: block;
}

@media (max-width: 768px) {
  .navBar {
    flex-direction: column;
  }

  .sidebar {
    width: 200px;
  }
}
</style>

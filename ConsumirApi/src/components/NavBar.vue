<template>
  <nav class="nav">
    <RouterLink to="/CrudUsuarios" class="nav-link">Usuários</RouterLink>
    <RouterLink to="/CrudFornecedores" class="nav-link">Fornecedores</RouterLink>
    <RouterLink to="/CrudProdutos" class="nav-link">Produtos</RouterLink>
    <RouterLink to="/" class="nav-link">Logout</RouterLink>
  </nav>
</template>

<script>
export default {
  name: 'NavBar'
}
</script>

<style scoped>
/* Estilos principais da navegação */
.nav {
  width: 100%;
  height: 80px;
  background-color: #FFF;
  display: flex;
  align-items: center;
  justify-content: space-around;
  padding: 0 20px;
  border-bottom: 2px solid #fff;
}

.nav a {
  color: #000;
}

.nav-link {
  color: #f0f0f0;
  text-decoration: none;
  font-size: 20px;
  padding: 10px 20px;
  border-radius: 30px;
  background-color: rgba(255, 255, 255, 0.1);
  transition: all 0.3s ease;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
}

.nav-link:hover {
  background-color: rgba(255, 255, 255, 0.1);
  color: #e0e0e0;
}
</style>
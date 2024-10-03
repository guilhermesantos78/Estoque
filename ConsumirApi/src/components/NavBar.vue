<template>
  <nav class="nav">
    <RouterLink to="/CrudUsuarios" class="nav-link">Usuários</RouterLink>
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
  background-color: #333;
  display: flex;
  align-items: center;
  justify-content: space-around;
  padding: 0 20px;
  border-bottom: 2px solid #fff;
}

.nav-link {
  color: #f5f5f5;
  font-size: 18px;
  text-decoration: none;
  padding: 10px 20px;
  border-radius: 8px;
  transition: background-color 0.3s, color 0.3s;
  font-weight: 200;
}

.nav-link:hover {
  background-color: rgba(255, 255, 255, 0.1);
  color: #e0e0e0;
}
</style>
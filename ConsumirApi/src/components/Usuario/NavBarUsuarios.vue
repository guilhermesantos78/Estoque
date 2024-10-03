<template>
  <nav class="nav">
    <RouterLink to="/FormGetUsuario" class="nav-link">Listar</RouterLink>
    <RouterLink to="/FormPostUsuario" class="nav-link">Criar</RouterLink>
    <RouterLink to="/FormUpdateUsuario" class="nav-link">Editar</RouterLink>
    <RouterLink to="/FormDeleteUsuario" class="nav-link">Deletar</RouterLink>
  </nav>
</template>

<script>
export default {
  name: 'NavBarUsuarios',
};
</script>

<style scoped>
.nav {
  width: 100%;
  height: 80px;
  background: #333;
  display: flex;
  align-items: center;
  justify-content: space-around;
  padding: 0 20px;
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
  background-color: rgba(255, 255, 255, 0.3);
  color: #fff;
  transform: scale(1.1);
}
</style>
<template>
    <nav class="nav">
        <RouterLink to="/FormGetFornecedor" class="nav-link">Listar</RouterLink>
        <RouterLink to="/FormPostFornecedor" class="nav-link">Criar</RouterLink>
        <RouterLink to="/FormUpdateFornecedor" class="nav-link">Editar</RouterLink>
        <RouterLink to="/FormDeleteFornecedor" class="nav-link">Deletar</RouterLink>
    </nav>
</template>

<script>
export default {
    name: 'NavBarFornecedores',
};
</script>

<style scoped>
.nav {
    width: 100%;
    height: 80px;
    background: #FFF;
    display: flex;
    align-items: center;
    justify-content: space-around;
    padding: 0 20px;
    box-shadow: 0 3px 2px rgba(0, 0, 0, 0.3);
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
    background-color: rgba(255, 255, 255, 0.3);
    color: #000;
    transform: scale(1.1);
}
</style>
<template>
    <NavBar />
    <NavBarProdutos />
    <div class="Tittle">
        <h1>Produtos</h1>
    </div>
    <div class="Description__container">
        <div class="Description">
            <h2>Use essa pagina para Editar, Criar, Deletar, e Visualizar os seus Produtos</h2>
        </div>
    </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue'
import NavBarProdutos from '@/components/Produto/NavBarProdutos.vue';

export default {
    name: 'CrudUsuarios',
    components: {
        NavBar,
        NavBarProdutos
    }
}
</script>

<style scoped>
.Tittle {
    display: flex;
    justify-content: center;
    align-items: center;
    padding-top: 50px;
}

.Description__container {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 50vh;
}

.Description {
    max-width: 400px;
    font-size: 0.75rem;
    text-align: justify;
}
</style>
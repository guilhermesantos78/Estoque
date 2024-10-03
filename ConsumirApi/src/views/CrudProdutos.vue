<template>
    <NavBar />
    <div class="all">
        <FormPostProduto />
        <br>
        <FormDeleteProduto />
        <br>
        <FormUpdateProduto />
        <br>
        <FormGetProduto />
    </div>
</template>

<script>
import FormPostProduto from '@/components/Produto/FormPostProduto.vue'
import FormDeleteProduto from '@/components/Produto/FormDeleteProduto.vue'
import FormUpdateProduto from '@/components/Produto/FormUpdateProduto.vue'
import FormGetProduto from '@/components/Produto/FormGetProduto.vue'
import NavBar from '@/components/NavBar.vue'

export default {
    name: 'CrudProdutos',
    components: {
        FormPostProduto,
        FormDeleteProduto,
        FormUpdateProduto,
        FormGetProduto,
        NavBar
    }
}
</script>

<style scoped>
.all {
    display: flex;
    gap: 50px;
}
</style>
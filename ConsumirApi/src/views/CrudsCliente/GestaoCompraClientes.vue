<template>
    <h2>Seus Produtos </h2>
    <div class="products">
        <ul class="product-list">
            <li v-for="produto in produtos" :key="produto.id" class="product-item">
                {{ produto.nome }} <br><br> A partir de : {{ produto.preco }}$ <br><br>
                Descrição: {{ produto.descricao }}
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name: 'GestaoCompraClientes',
    data() {
        return {
            produtos: []
        };
    },
    mounted() {
        const produtos = JSON.parse(this.$route.query.produtos || '[]');
        this.produtos = produtos;
        console.log(this.produtos);
    },
    methods: {
        adicionarAoCarrinho(produto) {
            console.log(`Produto adicionado ao carrinho: ${produto.nome}`);
        }
    }
};
</script>

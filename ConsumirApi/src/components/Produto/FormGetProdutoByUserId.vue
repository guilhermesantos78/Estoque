<template>
    <NavBar />
    <NavBarProdutos />
    <div>
        <h1>Lista de Produto</h1>

        <!-- Campo de entrada para o ID do cliente -->
        <label for="clienteId">ID do Cliente:</label>
        <input v-model="clienteId" type="number" id="clienteId" placeholder="Digite o ID do Cliente" />

        <!-- Botão para carregar os produtos -->
        <button @click="listarProdutos">Carregar Produto</button>

        <!-- Listagem dos produtos -->
        <ul>
            <li v-for="produto in Produtos" :key="produto.id">
                Id: {{ produto.id }} - Nome: {{ produto.nome }} - Preço: {{ produto.preco }} - Descrição: {{
                    produto.descricao }} - FornecedorId: {{ produto.fornecedorId }} - UsuarioId: {{ produto.usuarioId }}
            </li>
        </ul>
    </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';
import NavBarProdutos from '@/components/Produto/NavBarProdutos.vue';

export default {
    name: 'FormGetProdutoByUserid',
    components: {
        NavBar,
        NavBarProdutos
    },
    data() {
        return {
            Produtos: [],  // Armazena os produtos buscados
            clienteId: '', // V-model para o ID do cliente
        };
    },
    methods: {
        async listarProdutos() {
            const apiUrl = `https://localhost:7248/Produto/cliente/${this.clienteId}`;  // Usa o clienteId no URL
            try {
                const response = await fetch(apiUrl, {
                    method: 'GET',
                    headers: {
                        'Accept': 'application/json',
                    },
                });

                if (!response.ok) {
                    throw new Error('Erro ao buscar os Produtos');
                }

                const data = await response.json();
                console.log(data);
                this.Produtos = data; // Atribui os dados ao array 'Produtos'
            } catch (error) {
                console.error('Erro:', error);
            }
        },
    },
};
</script>

<style>
/* Adicione estilos aqui, se necessário */
</style>
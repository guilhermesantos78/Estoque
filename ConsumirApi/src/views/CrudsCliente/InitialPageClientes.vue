<template>
    <div class="container__center">
      <div class="Tittle">
        <h1>Bem Vindo ao gerenciamento da sua empresa</h1>
        <h3>Use este site para gerenciar os parâmetros da sua empresa</h3>
      </div>
      <button v-on:click="handleClick">Clique aqui</button>
    </div>
  </template>
  
  <script>
  export default {
    name: 'InitalPageClientes',
    methods: {
      handleClick() {
        console.log('Botão clicado!');
      }
    }
  }
  </script>
  
  <style scoped>
  .container__center {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    height: 100vh;
  }
  
  .Tittle {
    text-align: center; /* Alinha o texto centralmente */
  }
  </style>
  
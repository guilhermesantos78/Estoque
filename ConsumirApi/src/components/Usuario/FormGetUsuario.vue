<template>
    <div>
      <h1>Lista de Usuários</h1>
      <button @click="listarUsuarios">Carregar Usuários</button>
      <ul>
        <li v-for="usuario in usuarios" :key="usuario.id">
            Id: {{ usuario.id }} - Usuario: {{ usuario.nome }} - Senha: {{ usuario.senha }}
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    name:'FormGetUsuario',
    data() {
      return {
        usuarios: [],
      };
    },
    methods: {
      async listarUsuarios() {
        const apiUrl = 'https://localhost:7096/Usuario/listar-usuario';
        try {
          const response = await fetch(apiUrl, {
            method: 'GET',
            headers: {
              'Accept': 'application/json',
            },
          });
  
          if (!response.ok) {
            throw new Error('Erro ao buscar os Usuários');
          }
  
          this.usuarios = await response.json();
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
  
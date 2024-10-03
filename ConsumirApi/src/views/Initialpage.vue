<template>
  <div class="initial-page">
    <NavBar />
    <header class="hero">
      <h1>Bem-vindo ao nosso site!</h1>
      <p>Gerencie o seu estoque.</p>
    </header>
    <main class="content">
      <h2>Gerenciar</h2>
    </main>
    <footer>
      <p>&copy; 2024 Estoque. Todos os direitos reservados.</p>
    </footer>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'InitialPage',
  components: {
    NavBar,
  },
};
</script>

<style scoped>
html, body {
  margin: 0;
  height: 100%;
}

.initial-page {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.hero {
  background-color: #333;
  color: white;
  text-align: center;
  padding: 50px 20px;
  margin-bottom: 20px;
}

.cta-button {
  background-color: #000;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  text-decoration: none;
  font-weight: bold;
}

.content {
  flex: 1;
  width: 80%;
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
}
footer {
  text-align: center;
  padding: 10px;
  background-color: #333;
  color: white;
  width: 100%;
}
</style>

<template>
  <NavBar />
  <div class="initial-page">
    <header class="hero">
      <h1>Bem-vindo ao site de gerenciamento do seu Sistema!</h1>
      <p>Gerencie o seu estoque.</p>
    </header>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';

export default {
  name: 'InitialPage',
  components: {
    NavBar
  },
};
</script>

<style scoped>
html,
body {
  margin: 0;
  height: 100%;
  font-family: "Funnel Display", sans-serif;
}

.initial-page {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  font-family: "Funnel Display", sans-serif;
}

.hero {
  background-color: #ededed;
  color: black;
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

footer {
  text-align: center;
  padding: 10px;
  background-color: #333;
  color: white;
  width: 100%;
}
</style>

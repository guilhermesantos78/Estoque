<template>
  <div class="initial-page">
    <NavBar />
    <header class="hero">
      <h1>Bem-vindo ao nosso site!</h1>
      <p>Gerencie o seu estoque.</p>
    </header>
    <main class="content">
      <h2>Recursos Principais</h2>
      <section class="features">
        <div class="feature-card">
          <h3>Aprendizado Interativo</h3>
          <p>Engaje-se em atividades práticas e interativas.</p>
        </div>
        <div class="feature-card">
          <h3>Comunidade</h3>
          <p>Junte-se a uma comunidade de aprendizes e educadores.</p>
        </div>
        <div class="feature-card">
          <h3>Conteúdo Atualizado</h3>
          <p>Mantenha-se atualizado com os últimos recursos e informações.</p>
        </div>
      </section>
    </main>
    <footer>
      <p>&copy; 2024 Salinha Inovação. Todos os direitos reservados.</p>
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
  min-height: 100vh; /* Garante que a página preencha a altura da tela */
}

.hero {
  background-color: #333; /* Cor de fundo do cabeçalho */
  color: white; /* Texto em branco para contraste */
  text-align: center;
  padding: 50px 20px;
  margin-bottom: 20px;
}

.cta-button {
  background-color: #000; /* Botão preto */
  color: white; /* Texto do botão em branco */
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  text-decoration: none;
  font-weight: bold;
}

.content {
  flex: 1; /* Faz com que o conteúdo principal cresça para ocupar o espaço restante */
  width: 80%;
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
}

.features {
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
  margin: 20px 0;
}

.feature-card {
  background-color: #f8f8f8; /* Fundo claro para cartões */
  border-radius: 10px;
  padding: 20px;
  margin: 10px;
  flex: 1 1 30%;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

footer {
  text-align: center;
  padding: 10px;
  background-color: #333; /* Cor de fundo do rodapé */
  color: white; /* Texto em branco no rodapé */
  width: 100%;
}
</style>

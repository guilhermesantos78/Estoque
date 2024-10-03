<template>
    <NavBar />
    <NavBarUsuarios />
</template>

<script>
import NavBar from '@/components/NavBar.vue'
import NavBarUsuarios from '@/components/Usuario/NavBarUsuarios.vue'

export default {
  name: 'Home',
  components: {
    NavBar,
    NavBarUsuarios
  }
}
</script>

<style scoped>

</style>
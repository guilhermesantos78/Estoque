<template>
  <div>
    <FormLoginUsuario />
  </div>
</template>

<script>
import FormLoginUsuario from '@/components/Usuario/FormLoginUsuario.vue'
import NavBar from '@/components/NavBar.vue'
export default {
  name: 'Home',
  components: {
    FormLoginUsuario,
    NavBar
  }
}
</script>
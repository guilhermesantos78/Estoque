<template>
  <div class="all">
    <FormPostUsuario />
    <br>
    <FormDeleteUsuario />
    <br>
    <FormUpdateUsuario />
    <br>
    <FormGetUsuario />
  </div>
</template>

<script>
import FormPostUsuario from '@/components/Usuario/FormPostUsuario.vue'
import FormDeleteUsuario from '@/components/Usuario/FormDeleteUsuario.vue'
import FormUpdateUsuario from '@/components/Usuario/FormUpdateUsuario.vue'
import FormGetUsuario from '@/components/Usuario/FormGetUsuario.vue'
export default {
  name: 'Home',
  components: {
    FormPostUsuario,
    FormDeleteUsuario,
    FormUpdateUsuario,
    FormGetUsuario
  }
}
</script>

<style scoped>
.all{
  display: flex;
  gap: 50px;
}
</style>
<template>
  <div>
    <InitialPageClientes />
  </div>
</template>

<script>
import InitialPageClientes from './CrudsCliente/InitialPageClientes.vue';

export default {
  name: 'Home',
  components: {
    InitialPageClientes
  }
}
</script>
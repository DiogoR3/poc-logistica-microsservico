<template>
  <caixa-login />
</template>

<script lang="ts">
  import Vue from 'vue'
  import CaixaLogin from '../components/CaixaLogin.vue'

  export default Vue.extend({
    name: 'Login',

    components: {
      CaixaLogin,
    },
  })
</script>

<template>
  <v-row align="center" justify="center">
    <v-col cols="12" xs="11" sm="10" md="8" lg="7" xl="6">
      <CaixaLogin />
    </v-col>
  </v-row>
</template>

<script lang="ts">
import Vue from "vue";
import CaixaLogin from "../components/CaixaLogin.vue";

export default Vue.extend({
  name: "Login",

  components: {
    CaixaLogin,
  },
});
</script>

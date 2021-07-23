<template>
  <v-app>
    <v-container>
      <router-link to="/Login">Ir para Login</router-link>
      <br>
      <router-link to="/">Ir para Menu</router-link>
      <router-view></router-view>
    </v-container>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "App",

  data: () => ({
    //
  }),
});
</script>

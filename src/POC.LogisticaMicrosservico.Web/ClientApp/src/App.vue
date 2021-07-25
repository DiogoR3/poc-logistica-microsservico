<template>
  <v-app>
    <v-container fill-height fluid>
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

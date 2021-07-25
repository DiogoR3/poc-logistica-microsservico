<template>
  <v-row align="center" justify="center">
    <v-col cols="12" xs="12" md="3">
      <Opcoes />
    </v-col>
    <v-col cols="12" xs="12" md="9">
      <router-view></router-view>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import Vue from "vue";
import Opcoes from "../components/Menu/Opcoes.vue";

export default Vue.extend({
  name: "Menu",
  mounted() {

  },
  components: {
    Opcoes,
  },
});
</script>

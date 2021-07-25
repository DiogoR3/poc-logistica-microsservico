<template>
  <v-card elevation="4">
    <v-list dense>
      <v-subheader>Usuário:</v-subheader>
      <v-list-item-group v-model="selectedItem" color="primary" mandatory>
        <v-list-item @click="irPara('/Menu/Usuarios')">
          <v-list-item-icon>
            <v-icon>mdi-account</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>Usuários</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item @click="irPara('/Menu/Atendimento')">
          <v-list-item-icon>
            <v-icon>mdi-phone-outline</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>Atendimento</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item @click="irPara('/Menu/Mercadoria')">
          <v-list-item-icon>
            <v-icon>mdi-package-variant-closed</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>Mercadoria</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item>
          <v-list-item-icon>
            <v-icon>mdi-logout</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>Sair</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
  </v-card>
</template>



<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "Opcoes",

  data: () => ({
    selectedItem: 0,
  }),
  methods: {
    irPara(caminho: string) {
      if (this.$route.path.indexOf(caminho) == -1) {
        this.$router.push(caminho);
      }
    },
  },
});
</script>


<template>
  <v-card elevation="4">
    <v-list dense>
      <v-subheader class="negrito">Usuário: {{ tipoUsuario }}</v-subheader>
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
        <v-list-item @click="dialogo = true">
          <v-list-item-icon>
            <v-icon>mdi-logout</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>Sair</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
    <v-dialog v-model="dialogo" max-width="290">
      <v-card>
        <v-card-title class="text-h5"> Sair </v-card-title>

        <v-card-text> Deseja realmente sair? </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn color="blue darken-1" text @click="dialogo = false">
            Cancelar
          </v-btn>

          <v-btn color="red darken-1" text @click="sair()"> Confirmar </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-card>
</template>

<script lang="ts">
import Vue from "vue";
import { tipoUsuario, logout } from '../../api/autenticacao'

export default Vue.extend({
  name: "Opcoes",

  data: () => ({
    selectedItem: 0 as number,
    dialogo: false as boolean,
    tipoUsuario: 'Desconhecido' as string
  }),
  mounted() {
    this.tipoUsuario = tipoUsuario();
  },
  methods: {
    irPara(caminho: string): void {
      if (this.$route.path.indexOf(caminho) == -1) {
        this.$router.push(caminho);
      }
    },
    sair(): void {
      logout();
    },
  },
});
</script>

<style scoped>
  .negrito{
    font-size: 1.05rem;
    font-weight: bold;
  }
</style>
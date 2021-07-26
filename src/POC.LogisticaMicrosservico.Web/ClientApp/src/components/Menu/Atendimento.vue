<template>
  <v-card elevation="4">
    <v-card-title>
      <v-form @submit.prevent="buscarAtendimento()" style="width: 100%">
        <v-text-field
          v-model="busca"
          append-icon="mdi-magnify"
          label="Buscar por atendimento..."
          single-line
          hide-details
        ></v-text-field>
      </v-form>
    </v-card-title>
    <v-card-text>
      <div v-if="carregado">
        <v-list subheader three-line>
          <v-subheader>Título: {{ atendimento.titulo }}</v-subheader>

          <v-list-item v-for="(mensagem, indice) in atendimento.mensagens">
            <v-list-item-content>
              <v-list-item-title>{{
                atendimento.partes[indice]
              }}</v-list-item-title>
              <v-list-item-subtitle>{{ mensagem }}</v-list-item-subtitle>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </div>
      <div class="text-center" v-else>
        <v-progress-circular
          :size="100"
          :width="8"
          color="primary"
          indeterminate
        ></v-progress-circular>
      </div>
    </v-card-text>
    <v-snackbar v-model="snackbar" :timeout="3000">
      {{ mensagemSnackbar }}
      <template v-slot:action="{ attrs }">
        <v-btn color="red" v-bind="attrs" text @click="snackbar = false"
          >FECHAR</v-btn
        >
      </template>
    </v-snackbar>
  </v-card>
</template>


<script lang="ts">
import Vue from "vue";
import api from "../../api/";
import { logout } from "../../api/autenticacao";

export default Vue.extend({
  name: "Atendimento",
  data: () => ({
    busca: "" as string,
    snackbar: false as boolean,
    mensagemSnackbar: "" as string,
    carregado: true as boolean,
    atendimento: {
      titulo: "" as string,
      partes: [] as string[],
      mensagens: [] as string[],
    } as any,
  }),
  methods: {
    async buscarAtendimento(): Promise<void> {
      try {
        this.carregado = false;
        const atendimento = (await api.Atendimento(this.busca)).data;

        if (!atendimento.length) {
          this.atendimento.titulo = '';
          this.atendimento.partes = [];
          this.atendimento.mensagens = [];
          this.mostrarSnackbar("Não foi possível encontrar o atendimento!");
          return;
        }

        this.mostrarSnackbar("Atendimento encontrado com sucesso!");
        this.atendimento.titulo = atendimento[0].titulo;

        for (const [indice, valor] of atendimento.entries()) {
          this.atendimento.partes.push(
            indice % 2 == 0 ? "Cliente" : "Colaborador"
          );
          this.atendimento.mensagens.push(valor.mensagem);
        }
      } catch (ex) {
        if (ex.response.status == 401) {
          this.mostrarSnackbar("Login expirado!");
          logout();
        } else if (ex.response.status == 403) {
          this.mostrarSnackbar("Sem permissão para buscar por atendimentos!");
        } else {
          this.mostrarSnackbar("Erro de servidor");
        }
      } finally {
        this.carregado = true;
      }
    },
    mostrarSnackbar(texto: string): void {
      this.mensagemSnackbar = texto;
      this.snackbar = true;
    },
  },
});
</script>

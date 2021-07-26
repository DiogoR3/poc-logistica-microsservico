<template>
  <v-card elevation="4">
    <v-card-title>
      <v-form @submit.prevent="buscarHistoricoMercadoria()" class="w-100">
        <v-text-field
          v-model="busca"
          append-icon="mdi-magnify"
          label="Buscar por mercadoria..."
          single-line
          hide-details
        ></v-text-field>
      </v-form>
    </v-card-title>
    <v-card-text>
      <div v-if="carregado">
        <h3>Descrição da Mercadoria: {{ historicoMercadoria.mercadoria.descricao }}</h3>
        <h4>Data e Hora de Entrada: {{ historicoMercadoria.mercadoria.dataEntrada ? new Date(historicoMercadoria.mercadoria.dataEntrada).toLocaleString() : ''}}</h4>

        <v-timeline>
          <v-timeline-item
            v-for="(dataHora, indice) in historicoMercadoria.dataHora" :key="indice" :class="indice % 2 == 0 ? '' : 'text-right'"
          >
            <strong>{{ new Date(dataHora).toLocaleString() }}</strong>
            <div class="text-caption">{{ historicoMercadoria.descricao[indice] }}</div>
          </v-timeline-item>
        </v-timeline>
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
  name: "Mercadoria",
  data: () => ({
    busca: "" as string,
    snackbar: false as boolean,
    mensagemSnackbar: "" as string,
    carregado: true as boolean,
    historicoMercadoria: {
      mercadoria: {
        dataEntrada: '' as string,
        descricao: "" as string,
      },
      dataHora: [] as string[],
      descricao: [] as string[],
    } as any,
  }),
  methods: {
    async buscarHistoricoMercadoria(): Promise<void> {
      try {
        this.carregado = false;
        const historicoMercadoria = (await api.Mercadoria(this.busca)).data;

        if (!historicoMercadoria.length) {
          this.historicoMercadoria.mercadoria.descricao = "";
          this.historicoMercadoria.mercadoria.dataEntrada = "";
          this.historicoMercadoria.dataHora = [];
          this.historicoMercadoria.descricao = [];
          this.mostrarSnackbar("A mercadoria não foi encontrada!");
          return;
        }

        this.mostrarSnackbar("Mercadoria encontrada com sucesso!");
        this.historicoMercadoria.mercadoria.descricao = historicoMercadoria[0].mercadoria.descricao;
        this.historicoMercadoria.mercadoria.dataEntrada = historicoMercadoria[0].mercadoria.dataEntrada;

        for (const historico of historicoMercadoria) {
          this.historicoMercadoria.dataHora.push(historico.dataHora);
          this.historicoMercadoria.descricao.push(historico.descricao);
        }

        console.log(this.historicoMercadoria)
      } catch (ex) {
        if (ex.response.status == 401) {
          this.mostrarSnackbar("Login expirado!");
          logout();
        } else if (ex.response.status == 403) {
          this.mostrarSnackbar("Sem permissão para buscar por mercadorias!");
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

<style scoped>
.w-100 {
  width: 100%;
}
</style>
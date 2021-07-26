<template>
  <v-card elevation="4" :loading="carregando">
    <template slot="progress">
      <v-progress-linear
        color="primary"
        height="5"
        indeterminate
      ></v-progress-linear>
    </template>

    <v-snackbar v-model="snackbar" :timeout="3000">
      {{ mensagemSnackbar }}
      <template v-slot:action="{ attrs }">
        <v-btn color="red" v-bind="attrs" text @click="snackbar = false">FECHAR</v-btn>
      </template>
    </v-snackbar>

    <v-img max-height="200" src="../assets/boa-entrega.png"></v-img>

    <v-card-title>Boa Entrega</v-card-title>

    <v-card-text>
      <v-form v-model="valido" @submit.prevent="logar">
        <v-text-field
          v-model="login"
          :counter="20"
          label="Login"
          :rules="regras"
          required
          autocomplete="on"
        ></v-text-field>

        <v-text-field
          v-model="senha"
          :counter="20"
          label="Senha"
          :rules="regras"
          required
          type="password"
          autocomplete="on"
        ></v-text-field>

        <v-layout justify-center>
          <v-btn
            color="primary"
            elevation="2"
            :disabled="!valido"
            type="submit"
          >
            Login
          </v-btn>
        </v-layout>
      </v-form>
    </v-card-text>
  </v-card>
</template>

<script lang="ts">
import Vue from "vue";
import api from "../api";

export default Vue.extend({
  name: "CaixaLogin",

  data: () => ({
    snackbar: false as boolean,
    mensagemSnackbar: "" as string,
    login: "" as string,
    senha: "" as string,
    carregando: false as boolean,
    valido: true as boolean,
    regras: [
      (v: string) => !!v || "Campo obrigatório",
      (v: string) => v.length <= 20 || "Campo deve ter menos de 20 caracteres",
    ],
  }),
  methods: {
    async logar(): Promise<void> {
      this.carregando = true;

      try {
        let resultado = await api.Login(this.login, this.senha);

        sessionStorage.setItem('login', JSON.stringify(resultado.data))

        this.$router.push("/Menu/Usuarios");
      } catch (ex) {
        this.mensagemSnackbar =
          ex?.response?.status == 400
            ? "Credenciais inválidas!"
            : "Erro de Servidor";
        this.snackbar = true;
      } finally {
        this.carregando = false;
      }
    },
  },
});
</script>

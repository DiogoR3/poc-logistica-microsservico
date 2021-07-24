<template>
  <v-card
    elevation="4"
    :loading="carregando"
    class="mx-auto my-12"
    max-width="374"
  >
    <template slot="progress">
      <v-progress-linear
        color="primary"
        height="5"
        indeterminate
      ></v-progress-linear>
    </template>

    <v-img height="200" src="../assets/boa-entrega.png"></v-img>

    <v-card-title>Boa Entrega</v-card-title>

    <v-form v-model="valido">
      <v-card-text>
        <v-text-field
          v-model="login"
          :counter="10"
          label="Login"
          :rules="regras"
          required
          max-length="10"
          autocomplete="on"
        ></v-text-field>

        <v-text-field
          v-model="senha"
          :counter="10"
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
            @click="logar"
            :disabled="!valido"
          >
            Login
          </v-btn>
        </v-layout>
      </v-card-text>
    </v-form>
  </v-card>
</template>

<script lang="ts">
import Vue from "vue";
import api from '../api'

export default Vue.extend({
  name: "CaixaLogin",

  data: () => ({
    login: '' as string,
    senha: '' as string,
    carregando: false as boolean,
    valido: true as boolean,
    regras:[
      (v: string) => !!v || "Campo obrigatório",
      (v: string) => v.length <= 10 || "Campo deve ter menos de 10 caracteres"
    ]
  }),
  methods: {
    async logar() {
      this.carregando = true

      try{
        let resultado = await api.Login(this.login, this.senha);
        console.log(resultado)
      }catch(ex){
        console.log(ex)
      }finally{
        this.carregando = false
      }
    },
  },
});
</script>

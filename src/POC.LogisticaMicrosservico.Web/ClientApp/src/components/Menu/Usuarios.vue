<template>
  <v-card elevation="4">
    <div v-if="carregado">
      <v-dialog
        v-model="formularioNovoUsuario.mostrar"
        persistent
        max-width="400"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-layout justify-center class="espaco-acima">
            <v-btn color="primary" v-bind="attrs" v-on="on">
              Criar Usuário<v-icon right dark>mdi-plus</v-icon>
            </v-btn>
          </v-layout>
        </template>
        <v-form
          v-model="formularioNovoUsuario.valido"
          @submit.prevent="criarUsuario()"
        >
          <v-card>
            <v-card-title class="text-h5">Criação de Usuário</v-card-title>
            <v-card-text>
              <v-text-field
                v-model="formularioNovoUsuario.nome"
                label="Nome"
                :rules="formularioNovoUsuario.regras"
                required
              ></v-text-field>
              <v-text-field
                v-model="formularioNovoUsuario.login"
                label="Login"
                :rules="formularioNovoUsuario.regras"
                required
              ></v-text-field>
              <v-text-field
                v-model="formularioNovoUsuario.senha"
                label="Senha"
                :rules="formularioNovoUsuario.regras"
                required
                type="password"
              ></v-text-field>
              <v-text-field
                v-model="formularioNovoUsuario.contato"
                label="Contato"
                :rules="formularioNovoUsuario.regras"
                required
              ></v-text-field>
              <v-select
                v-model="formularioNovoUsuario.tipo"
                :items="formularioNovoUsuario.tipos"
                item-value="id"
                item-text="texto"
                label="Tipo"
                :rules="formularioNovoUsuario.regraTipo"
                solo
              ></v-select>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="red"
                text
                @click="formularioNovoUsuario.mostrar = false"
                >Cancelar</v-btn
              >
              <v-btn
                color="blue darken-1"
                text
                :disabled="!formularioNovoUsuario.valido"
                type="submit"
                >Criar</v-btn
              >
            </v-card-actions>
          </v-card>
        </v-form>
      </v-dialog>
      <v-card-title>
        <v-text-field
          v-model="busca"
          append-icon="mdi-magnify"
          label="Busca..."
          single-line
          hide-details
        ></v-text-field>
      </v-card-title>
      <v-data-table
        :search="busca"
        append-icon="mdi-magnify"
        :headers="cabecalhos"
        :items.sync="linhas"
        :items-per-page="10"
        :footer-props="{
          itemsPerPageText: 'Itens por página',
          pageText: 'Página {0}-{1} de {2}',
        }"
        class="elevation-2"
      >
        <template v-slot:item.dataCriacao="{ item }">
          {{ new Date(item.dataCriacao).toLocaleDateString() }}
        </template>

        <template v-slot:item.habilitado="{ item }">
          <v-chip :color="item.habilitado ? 'green' : 'red'" dark>
            {{ item.habilitado ? "SIM" : "NÃO" }}
          </v-chip>
        </template>

        <template v-slot:item.tipo="{ item }">
          {{ formularioNovoUsuario.tipos[item.tipo - 1].texto }}
        </template>
      </v-data-table>
    </div>
    <div class="text-center" v-else>
      <v-progress-circular
        :size="100"
        :width="8"
        color="primary"
        indeterminate
      ></v-progress-circular>
    </div>

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
  name: "Usuarios",
  data: () => ({
    busca: "" as string,
    snackbar: false as boolean,
    mensagemSnackbar: "" as string,
    formularioNovoUsuario: {
      mostrar: false as boolean,
      valido: true as boolean,
      regras: [(v: any) => !!v || "Campo obrigatório"],
      regraTipo: [(v: any) => v != 0 || "Selecione um tipo"],
      nome: "" as string,
      login: "" as string,
      senha: "" as string,
      contato: "" as string,
      tipos: [
        { id: 1, texto: "Administrador" },
        { id: 2, texto: "Cliente" },
        { id: 3, texto: "Fornecedor" },
        { id: 4, texto: "Colaborador" },
      ],
      tipo: 0 as number,
    },
    carregado: false as boolean,
    cabecalhos: [
      { text: "Id", value: "id" },
      { text: "Nome", value: "nome" },
      { text: "Login", value: "login" },
      { text: "Data de Criação", value: "dataCriacao" },
      { text: "Habilitado", value: "habilitado" },
      { text: "Tipo", value: "tipo" },
    ],
    linhas: [] as any[],
  }),
  async mounted(): Promise<void> {
    try {
      this.linhas = (await api.ListarUsuarios()).data;
    } catch (ex) {
      if (ex.response.status == 401) {
        this.mostrarSnackbar("Login expirado!");
        logout();
      } else if (ex.response.status == 403) {
        this.mostrarSnackbar("Sem permissão para listar usuários!");
      } else {
        this.mostrarSnackbar("Erro de servidor");
      }
    } finally {
      this.carregado = true;
    }
  },

  methods: {
    async criarUsuario(): Promise<void> {
      const dados = this.formularioNovoUsuario;

      try {
        let novoUsuario = await api.CriarUsuario(
          dados.nome,
          dados.login,
          dados.senha,
          dados.contato,
          dados.tipo ?? 1
        );

        this.linhas.push(novoUsuario.data);
        this.mostrarSnackbar("Usuário criado com sucesso!");
      } catch (ex) {
        if (ex.response.status == 401) {
          this.mostrarSnackbar("Login expirado!");
          logout();
        } else if (ex.response.status == 403) {
          this.mostrarSnackbar("Sem permissão para criar usuários!");
        } else {
          this.mostrarSnackbar("Erro de servidor");
        }
      } finally {
        this.formularioNovoUsuario.mostrar = false;
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
.espaco-acima {
  padding-top: 15px;
}
</style>
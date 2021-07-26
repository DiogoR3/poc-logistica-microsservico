import axios, { AxiosResponse } from 'axios'
import JWT from './autenticacao'

function Login(login: string, senha: string) : Promise<AxiosResponse>{
    return axios.post('/api/Login', { login: login, senha: senha })
}

function ListarUsuarios() : Promise<AxiosResponse>{
    return axios.get('/api/ListarUsuarios', { headers: JWT() })
}

function CriarUsuario(nome: string, login: string, senha: string, contato: string, tipo: number) : Promise<AxiosResponse>{
    return axios.post('api/CriarUsuario', { nome, login, senha, contato, tipo }, { headers: JWT() })
}

function Atendimento(id: string) : Promise<AxiosResponse>{
    return axios.get('/api/ListarAtendimentos/' + id, { headers: JWT() })
}

function Mercadoria(id: string) : Promise<AxiosResponse>{
    return axios.get('/api/ObterHistoricoMercadoria/' + id, { headers: JWT() })
}

export default {
    Login,
    ListarUsuarios,
    CriarUsuario,
    Atendimento,
    Mercadoria
}

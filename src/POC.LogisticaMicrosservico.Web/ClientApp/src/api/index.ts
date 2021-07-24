import axios, { AxiosResponse } from 'axios'

function Login(login: string, senha: string) : Promise<AxiosResponse>{
    return axios.post('/api/Login', { login: login, senha: senha })
}

function ListarUsuarios() : Promise<AxiosResponse>{
    return axios.get('/api/Usuario')
}

function Atendimento(id: number) : Promise<AxiosResponse>{
    return axios.get('/api/Atendimento/' + id)
}

function Mercadoria(id: number) : Promise<AxiosResponse>{
    return axios.get('/api/Mercadoria/' + id)
}

export default {
    Login,
    ListarUsuarios,
    Atendimento,
    Mercadoria
}

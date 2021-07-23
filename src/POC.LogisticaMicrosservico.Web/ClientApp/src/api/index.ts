import axios, { AxiosResponse } from 'axios'

const EndpointInformacoesCadastrais = process.env.HOSTNAME_INFORMACOESCADASTRAIS
const EndpointServicosAoCliente = process.env.HOSTNAME_SERVICOSAOCLIENTE

function Login(login: string, senha: string) : Promise<AxiosResponse>{
    return axios.post(EndpointInformacoesCadastrais + '/Login', { login: login, senha: senha })
}

function ListarUsuarios() : Promise<AxiosResponse>{
    return axios.get(EndpointInformacoesCadastrais + '/Usuario')
}

function Atendimento(id: number) : Promise<AxiosResponse>{
    return axios.get(EndpointServicosAoCliente + '/Atendimento/' + id)
}

function Mercadoria(id: number) : Promise<AxiosResponse>{
    return axios.get(EndpointServicosAoCliente + '/Mercadoria/' + id)
}

export default {
    Login,
    ListarUsuarios,
    Atendimento,
    Mercadoria
}

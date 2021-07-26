import Router from '../router'; 

export default function cabecalhoJWT(): { Authorization: string } {
    let token: string = JSON.parse(tokenSalvo()).token
    return { Authorization: 'Bearer ' + token };
}

export function jaFezLogin(): boolean {

    if (sessionStorage.getItem('login')){
        return true;
    }

    return false;
}

export function tipoUsuario(): string {
    return JSON.parse(tokenSalvo()).tipo;
}

export function logout(): void {
    sessionStorage.removeItem('login');
    Router.push('/')
}

function tokenSalvo(): string {
    return sessionStorage.getItem('login') ?? '{"login": "", "tipo": "Desconhecido", "token": "" }';
}
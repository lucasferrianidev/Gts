import { Injectable } from '@angular/core';

const KEY = 'token'

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }

  //terá os metedos de salvar, excluir e verificar se existe o token
  salvarToken(token: string) {
    return localStorage.setItem(KEY, token)
  }

  excluirToken(){
    localStorage.removeItem(KEY)
  }

  retornarToken() {
    return localStorage.getItem(KEY) ?? ""
  }

  possuiToken() {
    return !!this.retornarToken()
  }
}

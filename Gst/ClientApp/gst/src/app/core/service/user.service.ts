import { Injectable } from '@angular/core';
import { TokenService } from './token.service';
import jwt_decode from 'jwt-decode'
import { BehaviorSubject } from 'rxjs';
import { Usuario } from '../interfaces/usuario';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userSubject = new BehaviorSubject<Usuario | null>(null)

  // injetar o service do tokenService
  constructor(private tokenService: TokenService) {
    if(tokenService.possuiToken()) {
      this.decodificarJWT()
    }
  }

  decodificarJWT() {
    const token = this.tokenService.retornarToken();
    if (token != '') {
      const user = jwt_decode(token) as Usuario;
      this.userSubject.next(user)
    }
  }

  retornarUser() {
    return this.userSubject.asObservable();
  }

  salvarToken(token: string) {
    this.tokenService.salvarToken(token)
    this.decodificarJWT()
  }

  logout() {
    this.tokenService.excluirToken()
    this.userSubject.next(null)
  }

  estalogado() {
    return this.tokenService.possuiToken();
  }
}


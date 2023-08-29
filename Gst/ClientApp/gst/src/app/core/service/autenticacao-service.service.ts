import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { UserService } from './user.service';
import { AuthToken } from '../interfaces/authToken';

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {

  api_URL = 'https://localhost:7047'

  constructor(
    private http: HttpClient,
    private userService: UserService
  ) { }

  autenticar(email: string, senha: string): Observable<HttpResponse<AuthToken>> {
    return this.http.post<AuthToken>(`${this.api_URL}/usuario/login`,
      { username: email, password: senha },
      { observe: 'response' }).pipe(
        tap((response: HttpResponse<AuthToken>) => {
          const authToken = response?.body?.accessToken || ''
          this.userService.salvarToken(authToken)
        })
      )
  }
}

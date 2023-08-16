import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Especialidade } from './especialidade';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EspecialidadeService {
  private API = 'https://localhost:7164/Especialidade'

  constructor(private http: HttpClient) { }


  listarEspecialidade(): Observable<Especialidade[]> {
    return this.http.get<Especialidade[]>(this.API)
  }

  criarEspecialidade(especialidade: Especialidade): Observable<Especialidade> {
    return this.http.post<Especialidade>(this.API, especialidade)
  }

  excluirEspecialidade(especialidade: Especialidade): Observable<Especialidade> {
    const url = `${this.API}/${especialidade.cdEspecialidade}`
    return this.http.delete<Especialidade>(url)
  }

  buscarEspecialidadePorId(id: number): Observable<Especialidade> {
    const url = `${this.API}/${id}`
    return this.http.get<Especialidade>(url)
  }

}

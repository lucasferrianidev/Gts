import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Especialidade } from './especialidade';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EspecialidadeService {

  itensPorPagina = 5

  private API = 'https://localhost:7164/Especialidade'

  constructor(private http: HttpClient) { }


  listarEspecialidade(pagina: number, filtro: string): Observable<Especialidade[]> {

    let params = new HttpParams()
      .set('page', pagina)
      .set('perPage', this.itensPorPagina)

    if (filtro.length > 2) {
      params = params.set('query', filtro)
    }

    return this.http.get<Especialidade[]>(this.API, { params })
  }

  criarEspecialidade(especialidade: Especialidade): Observable<Especialidade> {
    return this.http.post<Especialidade>(this.API, especialidade)
  }

  editarEspecialidade(especialidade: Especialidade): Observable<Especialidade> {
    const url = `${this.API}/${especialidade.cdEspecialidade}`
    return this.http.put<Especialidade>(url, especialidade)
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

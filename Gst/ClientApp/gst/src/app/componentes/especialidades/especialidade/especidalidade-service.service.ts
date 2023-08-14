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

}

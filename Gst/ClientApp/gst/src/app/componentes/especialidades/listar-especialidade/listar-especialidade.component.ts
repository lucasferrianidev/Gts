import { Component, OnInit } from '@angular/core';
import { Especialidade } from '../especialidade/especialidade';
import { EspecialidadeService } from '../especialidade/especidalidade-service.service';

@Component({
  selector: 'app-listar-especialidade',
  templateUrl: './listar-especialidade.component.html',
  styleUrls: ['./listar-especialidade.component.css']
})
export class ListarEspecialidadeComponent implements OnInit {

  listaEspecialidade: Especialidade[] = []

  constructor(private http: EspecialidadeService) {}

  ngOnInit(): void {
    this.http.listarEspecialidade().subscribe((listaEspecialidade) => {
      this.listaEspecialidade = listaEspecialidade
    })
  }


}

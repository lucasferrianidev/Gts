import { Component, OnInit } from '@angular/core';
import { Especialidade } from '../especialidade/especialidade';
import { EspecialidadeService } from '../especialidade/especidalidade-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listar-especialidade',
  templateUrl: './listar-especialidade.component.html',
  styleUrls: ['./listar-especialidade.component.css']
})
export class ListarEspecialidadeComponent implements OnInit {

  listaEspecialidade: Especialidade[] = []

  constructor(
    private http: EspecialidadeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.http.listarEspecialidade().subscribe((listaEspecialidade) => {
      this.listaEspecialidade = listaEspecialidade
    })
  }

  criarEspecialidade1() {
    console.log('caia qui')
    this.router.navigate(['especialidade/criarEspecialidade'])
  }
}

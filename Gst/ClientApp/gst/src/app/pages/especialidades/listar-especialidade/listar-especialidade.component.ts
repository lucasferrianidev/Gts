import { Component, Input, OnInit } from '@angular/core';
import { Especialidade } from '../especialidade';
import { Router } from '@angular/router';
import { EspecialidadeService } from '../especidalidade-service.service';

@Component({
  selector: 'app-listar-especialidade',
  templateUrl: './listar-especialidade.component.html',
  styleUrls: ['./listar-especialidade.component.css']
})
export class ListarEspecialidadeComponent implements OnInit {

  listaEspecialidade: Especialidade[] = []
  paginaAtual: number = 0
  haMaisEspecialidades: boolean = true
  filtro: string = ''

  constructor(
    private service: EspecialidadeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.service.listarEspecialidade(this.paginaAtual, this.filtro).subscribe((listaEspecialidade) => {
      this.listaEspecialidade = listaEspecialidade
    })
  }

  criarEspecialidade1() {
    console.log('caia qui')
    this.router.navigate(['especialidade/criarEspecialidade'])
  }

  carregarMais() {
    this.service.listarEspecialidade(++this.paginaAtual, this.filtro).subscribe((listaEspecialidade) => {
      this.listaEspecialidade.push(...listaEspecialidade)
      if (listaEspecialidade.length < this.service.itensPorPagina) {
        this.haMaisEspecialidades = false
      }
    })
  }

  listarFiltrado() {
    this.service.listarEspecialidade(this.paginaAtual, this.filtro)
      .subscribe(especialidades => {
        this.listaEspecialidade = especialidades
      })
  }
}

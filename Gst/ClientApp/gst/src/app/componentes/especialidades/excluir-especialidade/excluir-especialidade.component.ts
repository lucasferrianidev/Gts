import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { EspecialidadeService } from '../especialidade/especidalidade-service.service';
import { Especialidade } from '../especialidade/especialidade';

@Component({
  selector: 'app-excluir-especialidade',
  templateUrl: './excluir-especialidade.component.html',
  styleUrls: ['./excluir-especialidade.component.css']
})
export class ExcluirEspecialidadeComponent implements OnInit {

  especialidade: Especialidade = {
    cdEspecialidade: 0,
    nome: '',
  }

  constructor(
    private http: EspecialidadeService,
    private router: Router,
    private route: ActivatedRoute
  ){}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('cdEspecialidade')
    console.log(id)
    this.http.buscarEspecialidadePorId(parseInt(id!)).subscribe((especialidade) => {
      this.especialidade = especialidade
    })
  }

  excluirEspecialidade() {
    this.http.excluirEspecialidade(this.especialidade).subscribe((especialidade) => {
      this.router.navigate(['/especialidade/listarEspecialidade'])
    })
  }

  cancelar() {
    this.router.navigate(['/especialidade/listarEspecialidade'])
  }
}

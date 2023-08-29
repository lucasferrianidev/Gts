import { Component, OnInit } from '@angular/core';
import { EspecialidadeService } from '../especidalidade-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Especialidade } from '../especialidade';

@Component({
  selector: 'app-editar-especialidade',
  templateUrl: './editar-especialidade.component.html',
  styleUrls: ['./editar-especialidade.component.css']
})
export class EditarEspecialidadeComponent implements OnInit {

  especialidade: Especialidade = {
    cdEspecialidade: 0,
    nome: '',
    favorito: false
  }

  constructor(
    private http: EspecialidadeService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('cdEspecialidade')
    this.http.buscarEspecialidadePorId(parseInt(id!)).subscribe((especialidade) => {
      this.especialidade = especialidade
      // this.router.navigate(['/especialidade/listarEspecialidade'])
    })
  }

  editarEspecialidade() {
    this.http.editarEspecialidade(this.especialidade).subscribe((especialidade) => {
      this.router.navigate(['/especialidade/listarEspecialidade'])
    })
  }

  cancelar() {
      this.router.navigate(['/especialidade/listarEspecialidade'])
  }

}

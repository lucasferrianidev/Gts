import { Especialidade } from './../especialidade';
import { Component, Input, OnInit } from '@angular/core';
import { EspecialidadeService } from '../especidalidade-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-especialidade',
  templateUrl: './especialidade.component.html',
  styleUrls: ['./especialidade.component.css']
})
export class EspecialidadeComponent implements OnInit {

  constructor(
    private service: EspecialidadeService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id')
    if (id != null) {
      this.service.buscarEspecialidadePorId(parseInt(id)).subscribe(especialidade => {

      })
    }
  }

  @Input() especialidade: Especialidade = {
    cdEspecialidade: 0,
    nome: '',
    favorito: false
  }

  mudarIcone() {
    if (this.especialidade.favorito) {
      return 'ativo'
    }
    return 'inativo'
  }

  mudarFavorito() {
    this.especialidade.favorito = !this.especialidade.favorito
    this.service.editarEspecialidade(this.especialidade).subscribe()
    console.log(this.especialidade.favorito)
  }

}

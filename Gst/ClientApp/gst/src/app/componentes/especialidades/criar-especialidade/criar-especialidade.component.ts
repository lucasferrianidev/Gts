import { Component, OnInit } from '@angular/core';
import { EspecialidadeService } from '../especialidade/especidalidade-service.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-criar-especialidade',
  templateUrl: './criar-especialidade.component.html',
  styleUrls: ['./criar-especialidade.component.css']
})
export class CriarEspecialidadeComponent implements OnInit {

  formulario!: FormGroup

  constructor(
    private service: EspecialidadeService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    // vou setar o formulario
    this.formulario = this.formBuilder.group({
      nome: [
        '', // valor default
        Validators.compose([
          Validators.required,
          Validators.pattern(/(.|\s)*\S(.|\s)*/)
        ])
      ]
    })
  }

  criarEspecialidade() {
    console.log(this.formulario)
    if (this.formulario.valid) {
      this.service.criarEspecialidade(this.formulario.value).subscribe(() => {
        this.router.navigate(['/especialidade/listarEspecialidade'])
      })
    }
  }

  cancelar() {
    this.router.navigate(['/especialidade/listarEspecialidade'])
  }
}

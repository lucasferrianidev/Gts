import { AutenticacaoService } from '../../core/service/autenticacao-service.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup

  constructor(
    private formBuilder: FormBuilder,
    private autenticacaoService: AutenticacaoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required]],
      senha: [null, Validators.required]
    })
  }

  login() {
    const email = this.loginForm.value.email
    const senha = this.loginForm.value.senha

    console.log(`email:${email} - senha: ${senha}`)


    this.autenticacaoService.autenticar(email, senha).subscribe({
      next: (value) => {
        this.router.navigate(['/especialidade/listarEspecialidade'])
        console.log(`Login efetuado com sucesso`, value)
      },
      error: (err) => {
        console.log(`Login falou`, err)
      }
    })
  }

}

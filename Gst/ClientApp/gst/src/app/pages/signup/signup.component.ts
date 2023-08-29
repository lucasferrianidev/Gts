import { AutenticacaoService } from '../../core/service/autenticacao-service.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  loginForm!: FormGroup

  constructor(
    private formBuilder: FormBuilder,
    private autenticacaoService: AutenticacaoService
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      senha: [null, Validators.required]
    })
  }

  login() {
    const email = this.loginForm.value.email
    const senha = this.loginForm.value.senha

    console.log(`email:${email} - senha: ${senha}`)


    this.autenticacaoService.autenticar(email, senha).subscribe({
      next: (value) => {
        console.log(`Login efetuado com sucesso`, value)
      },
      error: (err) => {
        console.log(`Login falou`, err)
      }
    })
  }

}

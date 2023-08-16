import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CabecalhoComponent } from './componentes/cabecalho/cabecalho.component';
import { CriarEspecialidadeComponent } from './componentes/especialidades/criar-especialidade/criar-especialidade.component';
import { ListarEspecialidadeComponent } from './componentes/especialidades/listar-especialidade/listar-especialidade.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ExcluirEspecialidadeComponent } from './componentes/especialidades/excluir-especialidade/excluir-especialidade.component';

@NgModule({
  declarations: [
    AppComponent,
    ListarEspecialidadeComponent,
    CriarEspecialidadeComponent,
    CabecalhoComponent,
    ExcluirEspecialidadeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceComponent } from './service/service.component';
import { CabecalhoComponent } from './componentes/cabecalho/cabecalho.component';
import { CriarEspecialidadeComponent } from './componentes/especialidades/criar-especialidade/criar-especialidade.component';
import { ListarEspecialidadeComponent } from './componentes/especialidades/listar-especialidade/listar-especialidade.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ListarEspecialidadeComponent,
    CriarEspecialidadeComponent,
    CabecalhoComponent,
    ServiceComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

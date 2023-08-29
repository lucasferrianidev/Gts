import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CabecalhoComponent } from './shared/cabecalho/cabecalho.component';
import { SignupComponent } from './pages/signup/signup.component';
import { CriarEspecialidadeComponent } from './pages/especialidades/criar-especialidade/criar-especialidade.component';
import { ListarEspecialidadeComponent } from './pages/especialidades/listar-especialidade/listar-especialidade.component';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ExcluirEspecialidadeComponent } from './pages/especialidades/excluir-especialidade/excluir-especialidade.component';
import { EditarEspecialidadeComponent } from './pages/especialidades/editar-especialidade/editar-especialidade.component';
import { EspecialidadeComponent } from './pages/especialidades/especialidade/especialidade.component';
import { BotaoCarregarMaisComponent } from './pages/especialidades/listar-especialidade/botao-carregar-mais/botao-carregar-mais.component';
import { LoginComponent } from './pages/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { AutenticacaoInterceptor } from './core/interceptors/autenticacao.interceptor';
import { HeaderComponent } from './shared/header/header.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MenuComponent } from './shared/menu/menu.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';

@NgModule({
  declarations: [
    AppComponent,
    ListarEspecialidadeComponent,
    CriarEspecialidadeComponent,
    CabecalhoComponent,
    ExcluirEspecialidadeComponent,
    EditarEspecialidadeComponent,
    EspecialidadeComponent,
    BotaoCarregarMaisComponent,
    LoginComponent,
    SignupComponent,
    HeaderComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    MatCardModule,
    MatButtonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatMenuModule,
    MatListModule,
    MatExpansionModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AutenticacaoInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarEspecialidadeComponent } from './pages/especialidades/listar-especialidade/listar-especialidade.component';
import { CriarEspecialidadeComponent } from './pages/especialidades/criar-especialidade/criar-especialidade.component';
import { ExcluirEspecialidadeComponent } from './pages/especialidades/excluir-especialidade/excluir-especialidade.component';
import { EditarEspecialidadeComponent } from './pages/especialidades/editar-especialidade/editar-especialidade.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'especialidade/listarEspecialidade',
    pathMatch: 'full'
  },
  {
    path: 'especialidade/listarEspecialidade',
    component: ListarEspecialidadeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'especialidade/criarEspecialidade',
    component: CriarEspecialidadeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'especialidade/excluirEspecialidade/:cdEspecialidade',
    component: ExcluirEspecialidadeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'especialidade/editarEspecialidade/:cdEspecialidade',
    component: EditarEspecialidadeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

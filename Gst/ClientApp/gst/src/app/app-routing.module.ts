import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarEspecialidadeComponent } from './componentes/especialidades/listar-especialidade/listar-especialidade.component';
import { CriarEspecialidadeComponent } from './componentes/especialidades/criar-especialidade/criar-especialidade.component';
import { ExcluirEspecialidadeComponent } from './componentes/especialidades/excluir-especialidade/excluir-especialidade.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'especialidade/listarEspecialidade',
    pathMatch: 'full'
  },
  {
    path: 'especialidade/listarEspecialidade',
    component: ListarEspecialidadeComponent
  },
  {
    path: 'especialidade/criarEspecialidade',
    component: CriarEspecialidadeComponent
  },
  {
    path: 'especialidade/excluirEspecialidade/:cdEspecialidade',
    component: ExcluirEspecialidadeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

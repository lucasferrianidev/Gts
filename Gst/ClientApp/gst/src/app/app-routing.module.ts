import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarEspecialidadeComponent } from './componentes/especialidades/listar-especialidade/listar-especialidade.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'listarEspecidalidade',
    pathMatch: 'full'
  },
  {
    path: 'listarEspecidalidade',
    component: ListarEspecialidadeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

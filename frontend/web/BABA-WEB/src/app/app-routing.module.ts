import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AtletasComponent } from './components/atletas/atletas.component';
import { AtletaDetalhesComponent } from './components/atletas/atletaDetalhes/atletaDetalhes.component';
import { AtletaListaComponent } from './components/atletas/atletaLista/atletaLista.component';

import { ControleComponent } from './components/controle/controle.component';
import { MensalidadeComponent } from './components/mensalidade/mensalidade.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  {
    path: 'atleta', component: AtletasComponent,
    children: [
      { path: 'detalhes/:id', component: AtletaDetalhesComponent },
      { path: 'detalhes', component: AtletaDetalhesComponent },
      { path: 'lista', component: AtletaListaComponent },
    ]
  },
  { path: 'controle', component: ControleComponent},
  { path: 'mensalidade', component: MensalidadeComponent},
  { path: 'perfil', component: PerfilComponent},
  { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full'},
  { path: 'dashboard', component: DashboardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { MensalidadeComponent } from './components/mensalidade/mensalidade.component';

import { AtletasComponent } from './components/atletas/atletas.component';
import { AtletaDetalhesComponent } from './components/atletas/atletaDetalhes/atletaDetalhes.component';
import { AtletaListaComponent } from './components/atletas/atletaLista/atletaLista.component';

import { ControleComponent } from './components/controle/controle.component';
import { DetalhesControleComponent } from './components/controle/detalhesControle/detalhesControle.component';
import { ListaControleComponent } from './components/controle/listaControle/listaControle.component';

import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

const routes: Routes = [
  {path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registro', component: RegistrationComponent }
    ]},
    { path: 'user/perfil', component: PerfilComponent},
  {path: 'atleta', redirectTo: 'atletas/lista', pathMatch: 'full'},
  {path: 'atletas', redirectTo: 'atletas/lista', pathMatch: 'full'},
  {
    path: 'atletas', component: AtletasComponent,
    children: [
      { path: 'detalhes/:id', component: AtletaDetalhesComponent },
      { path: 'detalhes', component: AtletaDetalhesComponent },
      { path: 'lista', component: AtletaListaComponent },
    ]
  },
  { path: 'controle', component: ControleComponent,
  children: [
    { path: 'detalhes/:id', component: DetalhesControleComponent },
    { path: 'detalhes', component: DetalhesControleComponent },
    { path: 'lista', component: ListaControleComponent },
  ]
},
  
  { path: 'mensalidade', component: MensalidadeComponent},
  { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full'},
  { path: 'dashboard', component: DashboardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

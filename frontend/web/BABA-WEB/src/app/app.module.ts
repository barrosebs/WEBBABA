import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule} from 'ngx-bootstrap/modal';
import { TooltipModule} from 'ngx-bootstrap/tooltip';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';


import { MenuComponent } from './shared/menu/menu.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { ButtonVoltarComponent } from './shared/button-voltar/button-voltar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { AtletaListaComponent } from './components/atletas/atletaLista/atletaLista.component';
import { AtletaDetalhesComponent } from './components/atletas/atletaDetalhes/atletaDetalhes.component';
import { MensalidadeComponent } from './components/mensalidade/mensalidade.component';
import { ControleComponent } from './components/controle/controle.component';
import { AtletasComponent } from './components/atletas/atletas.component';

import  { AtletaService } from './services/atleta.service';

import { AppRoutingModule } from './app-routing.module';

import { DateTimeFormatPipePipe } from './helpers/DateTimeFormatPipe.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
      MenuComponent,
      PerfilComponent,
      DashboardComponent,
      AtletasComponent,
      AtletaDetalhesComponent,
      AtletaListaComponent,
      ControleComponent,
      MensalidadeComponent,
      TituloComponent,
      ButtonVoltarComponent,
      DateTimeFormatPipePipe,
      UserComponent,
      LoginComponent,
      RegistrationComponent
   ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
      progressAnimation: 'increasing'
    }),
    NgxSpinnerModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    AtletaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { TituloComponent } from './shared/titulo/titulo.component';
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

import { MenuComponent } from './shared/menu/menu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { MensalidadeComponent } from './components/mensalidade/mensalidade.component';
import { ControleComponent } from './components/controle/controle.component';
import { AtletasComponent } from './components/atletas/atletas.component';

import  { AtletaService } from './services/atleta.service';

import { AppRoutingModule } from './app-routing.module';

import { DateTimeFormatPipePipe } from './helpers/DateTimeFormatPipe.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
      MenuComponent,
      PerfilComponent,
      DashboardComponent,
      AtletasComponent,
      ControleComponent,
      MensalidadeComponent,
      TituloComponent,
      DateTimeFormatPipePipe
   ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
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

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule} from 'ngx-bootstrap/modal';
import { TooltipModule} from 'ngx-bootstrap/tooltip';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import  { AtletaService } from './services/atleta.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AtletasComponent } from './atletas/atletas.component';
import { MenuComponent } from './menu/menu.component';

import { DateTimeFormatPipePipe } from './helpers/DateTimeFormatPipe.pipe';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
      AtletasComponent,
      MenuComponent,
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

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AtletasComponent } from './atletas/atletas.component';
import { MenuComponent } from './menu/menu.component';
import { DateTimeFormatPipePipe } from './helps/DateTimeFormatPipe.pipe';

@NgModule({
  declarations: [
    AppComponent,
      AtletasComponent,
      MenuComponent,
      DateTimeFormatPipePipe
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

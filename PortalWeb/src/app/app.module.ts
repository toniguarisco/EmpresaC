import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { AuthGuard } from "./auth.guard";
import { TokenInterceptorService } from './services/token-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [AuthGuard/* ,
              {     // ACTIVAR PARA MODIFICAR EL TOKEN
                provide: HTTP_INTERCEPTORS,
                useClass: TokenInterceptorService,
                multi: true
              } */
            ],
  bootstrap: [AppComponent]
})
export class AppModule { }

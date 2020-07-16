import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistroComercioRoutingModule } from './registro-comercio-routing.module';
import { RegistroComercioComponent } from './registro-comercio.component';


@NgModule({
  declarations: [RegistroComercioComponent],
  imports: [
    CommonModule,
    RegistroComercioRoutingModule
  ]
})
export class RegistroComercioModule { }

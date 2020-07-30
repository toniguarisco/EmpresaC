import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistroComercioRoutingModule } from './registro-comercio-routing.module';
import { RegistroComercioComponent } from './registro-comercio.component';

import { ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';


@NgModule({
  declarations: [RegistroComercioComponent],
  imports: [
    CommonModule,
    RegistroComercioRoutingModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ]
})
export class RegistroComercioModule { }

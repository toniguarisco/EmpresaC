import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistroPersonaRoutingModule } from './registro-persona-routing.module';
import { RegistroPersonaComponent } from './registro-persona.component';

import { ReactiveFormsModule } from "@angular/forms";
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';


@NgModule({
  declarations: [RegistroPersonaComponent],
  imports: [
    CommonModule,
    RegistroPersonaRoutingModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ]
})
export class RegistroPersonaModule { }

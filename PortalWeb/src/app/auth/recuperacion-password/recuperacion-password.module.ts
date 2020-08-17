import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RecuperacionPasswordRoutingModule } from './recuperacion-password-routing.module';
import { RecuperacionPasswordComponent } from './recuperacion-password.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [RecuperacionPasswordComponent],
  imports: [
    CommonModule,
    RecuperacionPasswordRoutingModule,
    ReactiveFormsModule
  ]
})
export class RecuperacionPasswordModule { }

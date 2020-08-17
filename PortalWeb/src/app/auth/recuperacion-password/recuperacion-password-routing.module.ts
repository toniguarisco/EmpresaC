import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RecuperacionPasswordComponent } from './recuperacion-password.component';

const routes: Routes = [{ path: '', component: RecuperacionPasswordComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecuperacionPasswordRoutingModule { }

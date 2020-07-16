import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegistroComercioComponent } from './registro-comercio.component';

const routes: Routes = [{ path: '', component: RegistroComercioComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegistroComercioRoutingModule { }

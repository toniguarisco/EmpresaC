import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegistroPersonaComponent } from './registro-persona.component';

const routes: Routes = [{ path: '', component: RegistroPersonaComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegistroPersonaRoutingModule { }

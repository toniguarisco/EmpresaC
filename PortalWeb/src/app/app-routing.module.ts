import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';

import { AuthGuard } from "./auth.guard";

const routes: Routes = [
  {
    path:'',
    redirectTo:'/login',
    pathMatch:'full'
  },
  { 
    path: 'home', 
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule), 
    canActivate:[AuthGuard]
  }, 
  { path: 'login', 
    loadChildren: () => import('./auth/login/login.module').then(m => m.LoginModule) 
  }, 
  { 
    path: 'registroPersona', 
    loadChildren: () => import('./auth/registro-persona/registro-persona.module').then(m => m.RegistroPersonaModule) 
  }, 
  { 
    path: 'registroComercio', 
    loadChildren: () => import('./auth/registro-comercio/registro-comercio.module').then(m => m.RegistroComercioModule) 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

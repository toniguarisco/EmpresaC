import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { AdminCantidadOperacionesComponent } from './admin/admin-cantidad-operaciones/admin-cantidad-operaciones.component';
import { AdminConfigParametrosComponent } from './admin/admin-config-parametros/admin-config-parametros.component';
import { AdminOperacionesCobroComponent } from './admin/admin-operaciones-cobro/admin-operaciones-cobro.component';
import { AdminOperacionesFallidasComponent } from './admin/admin-operaciones-fallidas/admin-operaciones-fallidas.component';
import { AdminOperacionesRetiroComponent } from './admin/admin-operaciones-retiro/admin-operaciones-retiro.component';
import { AdminRecaudoComisionComponent } from './admin/admin-recaudo-comision/admin-recaudo-comision.component';
import { AdministrarUsuariosComponent } from './admin/administrar-usuarios/administrar-usuarios.component';
import { AdminModificarUsuarioComponent } from './admin/admin-modificar-usuario/admin-modificar-usuario.component';

const routes: Routes = [{
                          path: '',
                          component: HomeComponent,
                          children: [
                            { path: 'dashboard', component: DashboardComponent },
                            /* ADMIN */
                            { path: 'admin-dashboard', component: AdminDashboardComponent },
                            { path: 'admin-cantidad-operaciones', component: AdminCantidadOperacionesComponent },
                            { path: 'admin-config-parametros', component: AdminConfigParametrosComponent },
                            { path: 'admin-operaciones-cobro', component: AdminOperacionesCobroComponent },
                            { path: 'admin-operaciones-fallidas', component: AdminOperacionesFallidasComponent },
                            { path: 'admin-operaciones-retiro', component: AdminOperacionesRetiroComponent },
                            { path: 'admin-recaudo-comision', component: AdminRecaudoComisionComponent },
                            { path: 'administrar-usuarios', component: AdministrarUsuariosComponent },
                            { path: 'admin-modificar-usuario', component: AdminModificarUsuarioComponent },
                          ]
                        },
                        ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }

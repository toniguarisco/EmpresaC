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
import { ComercioDashboardComponent } from './comercio/comercio-dashboard/comercio-dashboard.component';
import { ComercioAjustesPerfilComponent } from './comercio/comercio-ajustes-perfil/comercio-ajustes-perfil.component';
import { ComercioConsultarSaldoComponent } from './comercio/comercio-consultar-saldo/comercio-consultar-saldo.component';
import { ComercioConsultarSolicitudesRetiroComponent } from './comercio/comercio-consultar-solicitudes-retiro/comercio-consultar-solicitudes-retiro.component';
import { ComercioSolicitudRetiroComponent } from './comercio/comercio-solicitud-retiro/comercio-solicitud-retiro.component';
import { AjustesPerfilComponent } from './pages/ajustes-perfil/ajustes-perfil.component';
import { BloqueoOperacionesComponent } from './pages/bloqueo-operaciones/bloqueo-operaciones.component';
import { ConfigParametrosComponent } from './pages/config-parametros/config-parametros.component';
import { ConsultarSaldoComponent } from './pages/consultar-saldo/consultar-saldo.component';
import { RecargaComponent } from './pages/recarga/recarga.component';
import { SubUsuariosComponent } from './pages/sub-usuarios/sub-usuarios.component';
import { ConsultarSubUsuariosComponent } from './pages/consultar-sub-usuarios/consultar-sub-usuarios.component';
import { EliminarSubUsuariosComponent } from './pages/eliminar-sub-usuarios/eliminar-sub-usuarios.component';
import { IngresarCuentaComponent } from './pages/ingresar-cuenta/ingresar-cuenta.component';
import { MostrarCuentasComponent } from './pages/mostrar-cuentas/mostrar-cuentas.component';

const routes: Routes = [{
                          path: '',
                          component: HomeComponent,
                          children: [
                        
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
                            // COMERCIO
                            { path: 'comercio-dashboard', component: ComercioDashboardComponent },
                            { path: 'comercio-ajustes-perfil', component: ComercioAjustesPerfilComponent },
                            { path: 'comercio-consultar-saldo', component: ComercioConsultarSaldoComponent },
                            { path: 'comercio-consultar-solicitudes-retiro', component: ComercioConsultarSolicitudesRetiroComponent },
                            { path: 'comercio-solicitud-retiro', component: ComercioSolicitudRetiroComponent },
                            //PAGES (Persona)
                            { path: 'ajustes-perfil', component: AjustesPerfilComponent },
                            { path: 'bloqueo-operaciones', component: BloqueoOperacionesComponent },
                            { path: 'config-parametros', component: ConfigParametrosComponent },
                            { path: 'consultar-saldo', component: ConsultarSaldoComponent },
                            { path: 'dashboard', component: DashboardComponent },
                            { path: 'recarga', component: RecargaComponent },
                            { path: 'sub-usuarios', component: SubUsuariosComponent },
                            { path: 'consultar-sub-usuarios', component: ConsultarSubUsuariosComponent },
                            { path: 'eliminar-sub-usuarios', component: EliminarSubUsuariosComponent },
                            { path: 'ingresar-cuenta', component: IngresarCuentaComponent },
                            { path: 'mostrar-cuentas', component: MostrarCuentasComponent }
                          ]
                        },
                        ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }

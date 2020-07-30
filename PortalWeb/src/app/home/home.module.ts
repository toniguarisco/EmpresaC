import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { SidebarComponent } from '../components/sidebar/sidebar.component';
import { NavbarComponent } from '../components/navbar/navbar.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { RecargaComponent } from './pages/recarga/recarga.component';
import { ConfigParametrosComponent } from './pages/config-parametros/config-parametros.component';
import { BloqueoOperacionesComponent } from './pages/bloqueo-operaciones/bloqueo-operaciones.component';
import { AjustesPerfilComponent } from './pages/ajustes-perfil/ajustes-perfil.component';
import { ConsultarSaldoComponent } from './pages/consultar-saldo/consultar-saldo.component';
import { SubUsuariosComponent } from './pages/sub-usuarios/sub-usuarios.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { AdministrarUsuariosComponent } from './admin/administrar-usuarios/administrar-usuarios.component';
import { AdminConfigParametrosComponent } from './admin/admin-config-parametros/admin-config-parametros.component';
import { AdminCantidadOperacionesComponent } from './admin/admin-cantidad-operaciones/admin-cantidad-operaciones.component';
import { AdminRecaudoComisionComponent } from './admin/admin-recaudo-comision/admin-recaudo-comision.component';
import { AdminOperacionesFallidasComponent } from './admin/admin-operaciones-fallidas/admin-operaciones-fallidas.component';
import { AdminOperacionesCobroComponent } from './admin/admin-operaciones-cobro/admin-operaciones-cobro.component';
import { AdminOperacionesRetiroComponent } from './admin/admin-operaciones-retiro/admin-operaciones-retiro.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import { AdminModificarUsuarioComponent } from './admin/admin-modificar-usuario/admin-modificar-usuario.component';
import { ComercioDashboardComponent } from './comercio/comercio-dashboard/comercio-dashboard.component';
import { ComercioAjustesPerfilComponent } from './comercio/comercio-ajustes-perfil/comercio-ajustes-perfil.component';
import { ComercioConsultarSaldoComponent } from './comercio/comercio-consultar-saldo/comercio-consultar-saldo.component';
import { ComercioConsultarSolicitudesRetiroComponent } from './comercio/comercio-consultar-solicitudes-retiro/comercio-consultar-solicitudes-retiro.component';
import { ComercioSolicitudRetiroComponent } from './comercio/comercio-solicitud-retiro/comercio-solicitud-retiro.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap'




@NgModule({
  declarations: [HomeComponent,
                SidebarComponent,
                NavbarComponent,
                DashboardComponent,
                RecargaComponent,
                ConfigParametrosComponent,
                BloqueoOperacionesComponent,
                AjustesPerfilComponent,
                ConsultarSaldoComponent,
                SubUsuariosComponent,
                AdminDashboardComponent,
                AdministrarUsuariosComponent,
                AdminConfigParametrosComponent,
                AdminCantidadOperacionesComponent,
                AdminRecaudoComisionComponent,
                AdminOperacionesFallidasComponent,
                AdminOperacionesCobroComponent,
                AdminOperacionesRetiroComponent,
                AdminModificarUsuarioComponent,
                ComercioDashboardComponent,
                ComercioAjustesPerfilComponent,
                ComercioConsultarSaldoComponent,
                ComercioConsultarSolicitudesRetiroComponent,
                ComercioSolicitudRetiroComponent ],
  exports: [HomeComponent, DataTablesModule] ,
  imports: [
    CommonModule,
    HomeRoutingModule,
    ReactiveFormsModule,
    DataTablesModule,
    BsDatepickerModule.forRoot(),
    NgbModule

  ]
})
export class HomeModule { }

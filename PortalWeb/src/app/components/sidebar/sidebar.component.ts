import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Usuario } from '../../_model/usuario';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  isPersona = false;
  isComercio = false;
  isAdministrador = false;
  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem('tipoUsuario') === 'persona' ) {
      this.isPersona = true;
      this.router.navigate(['/home/dashboard']);
    }
    if (localStorage.getItem('tipoUsuario') === 'administrador' ) {
      this.isAdministrador = true;
      this.router.navigate(['/home/admin-dashboard']);
    }
    if (localStorage.getItem('tipoUsuario') === 'comercio' ) {
      this.isComercio = true;
      this.router.navigate(['/home/comercio-dashboard']);
    }
  }

}

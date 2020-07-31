import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig, BsDatepickerModule, DateFormatter } from 'ngx-bootstrap/datepicker';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { AdminService } from '../../../services/admin.service';


@Component({
  selector: 'app-admin-modificar-usuario',
  templateUrl: './admin-modificar-usuario.component.html',
  styleUrls: ['./admin-modificar-usuario.component.scss']
})
export class AdminModificarUsuarioComponent implements OnInit {

datePickerConfig: Partial<BsDatepickerConfig>;

data: any ;

registerForm = new FormGroup({
    usuario : new FormControl('', Validators.required),
    email : new FormControl('', [Validators.required, Validators.email]),
    password : new FormControl('', Validators.required),
    nombre : new FormControl('', Validators.required),
    apellido: new FormControl('', Validators.required),
    fechaNacimiento : new FormControl(null, Validators.required),
    telefono : new FormControl('', Validators.required),
  });

  public usuario: any;

  constructor(private router: Router,
              private adminService: AdminService) {
    this.data = window.history.state;
    this.datePickerConfig = Object.assign({},
      {
        containerClass: 'theme-blue',
        dateInputFormat: 'DD/MM/YYYY',
        isAnimated: true,
        adaptivePosition: true
        /* minDate : new Date(2018,0,1),
        maxDate : new Date(2018,11,31), */
      });
   }

  ngOnInit(): void {

    // Verificando que la pagina no este vacia

    if (this.data.navigationId === 1) {
      console.log('no hay data, aca ns devolvemos, chauuuu');
      this.router.navigate(['/home/administrar-usuarios']);
    }else{
      console.log('Si hay data ->', this.data);
      // obtener usuario elegido con la data del state
      // console.log( this.userService.getUserById(this.data.info.id));
      this.usuario = JSON.parse( localStorage.getItem('fakeUser'));
      // obteniendo usuario del FakeUser para funcionalidad
      console.log('retrievedObject: ', this.usuario);
    }
  }

/* 
  formatDate(){
    let day = this.registerForm.value.fechaNacimiento.getDate();
    let month = this.registerForm.value.fechaNacimiento.getMonth() + 1;
    let year = this.registerForm.value.fechaNacimiento.getFullYear();

    if (day < 10) {
      day = `0${day}`;

    }
    if (month < 10) {
      month = `0${month}`;
    }
    return (`${day}/${month}/${year}`);
  } */

    actualizarUsuario(){
      console.log('registrar');
      console.log('Form -> ', this.registerForm.value);

      // this.adminService.actualizarDatosUsuarios();

    }
}

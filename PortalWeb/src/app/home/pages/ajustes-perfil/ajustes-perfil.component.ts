import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig, BsDatepickerModule, DateFormatter } from 'ngx-bootstrap/datepicker';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../../../services/user.service';
@Component({
  selector: 'app-ajustes-perfil',
  templateUrl: './ajustes-perfil.component.html',
  styleUrls: ['./ajustes-perfil.component.scss']
})
export class AjustesPerfilComponent implements OnInit {


  
    idUsuario = localStorage.getItem('idUsuario');
    nombreUsuario: string;
    nombre: string;
    segundoNombre: string;
    apellido: string;
    segundoApellido: string;
    email: string;
    telefono: string;
    direccion: string;
    descripcionEstadoCivil: string;
  /*   nombreRepresentante: string;
    apellidoRepresentante: string; */

  datePickerConfig: Partial<BsDatepickerConfig>;

  registerForm = new FormGroup({
    nombre : new FormControl('', Validators.required),
    segundoNombre : new FormControl('', Validators.required),
    apellido : new FormControl('', Validators.required),
    segundoApellido : new FormControl('', Validators.required),
    nombreUsuario : new FormControl('', Validators.required),
    email : new FormControl('', [Validators.required, Validators.email]),
    telefono : new FormControl('', Validators.required),
    direccion : new FormControl('', Validators.required),
  });

  constructor(private userService: UserService) { 
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
    this.userService.getInfoPersona(localStorage.getItem('idUsuario'))
    .subscribe(
      res => {
        console.log('Persona -> ', res);
        this.nombre = res.nombre;
        this.segundoNombre = res.segundoNombre;
        this.apellido = res.apellido;
        this.segundoApellido = res.segundoApellido;
        this.nombreUsuario = res.usuario;
        this.email = res.email;
        this.telefono = res.telefono;
        this.direccion = res.direccion;

        
      },
      error => {
        console.log('error -> ', error);
      }
    );

 /*    this.userService.getUsuarioPorId(localStorage.getItem('idUsuario'))
    .subscribe(
      res2 => {
        console.log('Usuario -> ', res2);
        this.nombreUsuario = res2.usuario;
        this.email = res2.email;
        this.telefono = res2.telefono;
        this.direccion = res2.direccion;
      },
      error2 => {
        console.log('error -> ', error2);
      }
    ); */

  }



  actualizarUsuario(){
    console.log('registrar');
    console.log('Form -> ', this.registerForm.value);

    // this.adminService.actualizarDatosUsuarios();
    /* this.userService.actualizarDatosPersona(this.usuario.id,
                                            this.registerForm.value.nombre,
                                            this.registerForm.value.apellido,
                                            this.registerForm.value.fechaNacimiento ,
                                            this.registerForm.value.telefono,
                                            this.registerForm.value.email,); */
  }
}

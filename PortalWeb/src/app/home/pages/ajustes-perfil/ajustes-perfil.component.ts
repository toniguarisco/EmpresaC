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

  public usuario: any;

  datePickerConfig: Partial<BsDatepickerConfig>;

  registerForm = new FormGroup({
    usuario : new FormControl('', Validators.required),
    email : new FormControl('', [Validators.required, Validators.email]),
    password : new FormControl('', Validators.required),
    nombre : new FormControl('', Validators.required),
    apellido: new FormControl('', Validators.required),
    fechaNacimiento : new FormControl(null, Validators.required),
    telefono : new FormControl('', Validators.required),
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
    this.usuario = JSON.parse( localStorage.getItem('fakeUser'));
    // obteniendo usuario del FakeUser para funcionalidad
    console.log('retrievedObject: ', this.usuario);
  }

  actualizarUsuario(){
    console.log('registrar');
    console.log('Form -> ', this.registerForm.value);

    // this.adminService.actualizarDatosUsuarios();
    this.userService.actualizarDatosPersona(this.usuario.id,
                                            this.registerForm.value.nombre,
                                            this.registerForm.value.apellido,
                                            this.registerForm.value.fechaNacimiento ,
                                            this.registerForm.value.telefono,
                                            this.registerForm.value.email,);
  }
}

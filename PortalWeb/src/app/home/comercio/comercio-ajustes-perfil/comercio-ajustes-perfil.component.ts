import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig, BsDatepickerModule, DateFormatter } from 'ngx-bootstrap/datepicker';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ComercioService } from '../../../services/comercio.service';

@Component({
  selector: 'app-comercio-ajustes-perfil',
  templateUrl: './comercio-ajustes-perfil.component.html',
  styleUrls: ['./comercio-ajustes-perfil.component.scss']
})
export class ComercioAjustesPerfilComponent implements OnInit {


  public comercio: any;

  datePickerConfig: Partial<BsDatepickerConfig>;

  registerForm = new FormGroup({
    usuario : new FormControl('', Validators.required),
    email : new FormControl('', [Validators.required, Validators.email]),
    nombre : new FormControl('', Validators.required),
    razon_social : new FormControl('', Validators.required),
    direccion: new FormControl('', Validators.required)
  });

/*   private fakeCommerce =  {
    id_comercio: '1',
    nombre: 'chocolates Golorico',
    razon_social: 'Hermanos Gómez y Ripoldi S.R.L.',
    direccion: 'Caricuao',
    fk_persona: '1'
    }; */
    
  constructor(private comercioService: ComercioService) { 
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
    this.comercio = JSON.parse( localStorage.getItem('fakeCommerce'));
    // obteniendo usuario del FakeUser para funcionalidad
    console.log('retrievedObject: ', this.comercio);
  }

  actualizarUsuario(){
    console.log('registrar');
    console.log('Form -> ', this.registerForm.value);

    // this.adminService.actualizarDatosUsuarios();
    this.comercioService.actualizarDatosComercio(this.comercio.id_comercio,
                                            this.registerForm.value.usuario,
                                            this.registerForm.value.email,
                                            this.registerForm.value.nombre ,
                                            this.registerForm.value.razon_social,
                                            this.registerForm.value.direccion,);
  }
}

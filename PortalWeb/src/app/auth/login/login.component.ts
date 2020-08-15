import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

import { AuthService } from '../../services/auth.service';
import { Routes, Router } from '@angular/router'
import { Usuario } from '../../_model/usuario';
import { stringify } from '@angular/compiler/src/util';
import { isObject } from 'ngx-bootstrap/chronos/utils/type-checks';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    username: new FormControl('gabriella', [Validators.required]),
    password: new FormControl(12345678, [Validators.required, Validators.minLength(2)])
  });
/* 
  gabriella -> persona
  dexter-bit -> comercio
  toniguarisco -> Admin
  
 */  hasError: boolean;

  private fakeUser =  {
                id_usuario: '1',
                nombre: 'Ricardo',
                apellido: 'Bastardo',
                fecha_registro: '30/07/2019',
                num_identificacion: '1',
                email: 'rabastardo11@gmail.com',
                usuario: 'bastvai',
                password: '1234',
                telefono: '04141234567',
                direccion: 'Caricuao',
                status: 'No se',
                tipo_usuario: 'administrador'
              };

              private fakeCommerce =  {
                id_comercio: '1',
                usuario: 'chokoloco',
                nombre: 'chocolates Golorico',
                razon_social: 'Hermanos Gómez y Ripoldi S.R.L.',
                direccion: 'Caricuao',
                fk_persona: '1'
                };

  constructor(private authSrevice: AuthService,
              private router: Router) { }
private myToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzNTM0NTQzNTQzNTQzNTM0NTMiLCJleHAiOjE1MDQ2OTkyNTZ9.zG-2FvGegujxoLWwIQfNB5IT46D-xC4e8dEDYwi6aRM';
  ngOnInit(): void {

    this.hasError = false;
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  async login(){

    console.log('Form -> ',this.loginForm.value);
    //localStorage.setItem('token', this.token);
    console.log(localStorage.getItem('token'));
    this.authSrevice.login(this.f.username.value,  this.f.password.value.toString())
    .subscribe(
      res => {
        console.log('RESPUESTA Value =>' , res.value);
        console.log('RESPUESTA token =>' , res.value.token);
        localStorage.setItem('token', res.value.token);
        localStorage.setItem('tipoUsuario', res.value.tipo);
        localStorage.setItem('idUsuario', res.value.id);
        // valores esperados del servicio
        /* let usuario = {
          id_usuario: '1',
          usuario: 'bastvai',
          // password: '1234',
          tipo_usuario: 'administrador'
        }; */

        /* localStorage.setItem('usuario', JSON.stringify(usuario));
        // creando un Fake User para pruebas
        localStorage.setItem('fakeUser', JSON.stringify(this.fakeUser));
        // creando un Fake Commerce para pruebas
        localStorage.setItem('fakeCommerce', JSON.stringify(this.fakeCommerce));

        let comercio = {
          id_comercio: '1',
          usuario: 'bastvai',
          // password: '1234',
          tipo_usuario: 'administrador'
        }; */
        this.router.navigate(['/home']);
      }
      ,err => {
        console.log('ERROR =>', err);
        this.hasError = true;
      }
    );
    console.log('de nuevo en el login');
  }

  fakeLogin(){

    localStorage.setItem('token', this.myToken);
    console.log(localStorage.getItem('token'));
        // valores esperados del servicio
    let usuario = {
          id_usuario: '1',
          usuario: 'bastvai',
          // password: '1234',
          tipo_usuario: 'administrador'
        };

    localStorage.setItem('usuario', JSON.stringify(usuario));
        // creando un Fake User para pruebas
    localStorage.setItem('fakeUser', JSON.stringify(this.fakeUser));
        // creando un Fake Commerce para pruebas
    localStorage.setItem('fakeCommerce', JSON.stringify(this.fakeCommerce));

    let comercio = {
          id_comercio: '1',
          usuario: 'bastvai',
          // password: '1234',
          tipo_usuario: 'administrador'
        };
    this.router.navigate(['/home']);

  }


  hideAlert(): void {
    this.hasError = false;
  }

}

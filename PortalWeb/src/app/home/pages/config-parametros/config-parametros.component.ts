import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-config-parametros',
  templateUrl: './config-parametros.component.html',
  styleUrls: ['./config-parametros.component.scss']
})
export class ConfigParametrosComponent implements OnInit {

  parametrosForm = new FormGroup({
    montoMaxTransacciones : new FormControl('', Validators.required),
    maxOperacionesDiarias : new FormControl('', [Validators.required]),
    montoMaxDiario : new FormControl('', Validators.required)
  });
  constructor() { }

  ngOnInit(): void {
  }

  actualizarParametros(): void{
    //this.usuario = JSON.parse( localStorage.getItem('fakeUser'));
    console.log('click en actualizar paramteros del usuario' );
    console.log('Id usuario -> ', JSON.parse( localStorage.getItem('usuario')).id_usuario );
    console.log('Form -> ', this.parametrosForm.value);
  }
}

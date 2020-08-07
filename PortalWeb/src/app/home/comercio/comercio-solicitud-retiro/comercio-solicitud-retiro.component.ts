import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap/';

@Component({
  selector: 'app-comercio-solicitud-retiro',
  templateUrl: './comercio-solicitud-retiro.component.html',
  styleUrls: ['./comercio-solicitud-retiro.component.scss']
})
export class ComercioSolicitudRetiroComponent implements OnInit {

  retiroForm = new FormGroup({
    monto : new FormControl('', Validators.required),
    banco : new FormControl('', Validators.required),
   numeroTarjeta : new FormControl('', Validators.required),
    codigoSeguridad : new FormControl('', Validators.required),
    cedula : new FormControl('', Validators.required),
  
  });


  constructor() { }


  ngOnInit(): void {
  }

  retirarFondos(): void{

    console.log('click en actualizar comision');
    console.log(this.retiroForm.value);
  }
  }


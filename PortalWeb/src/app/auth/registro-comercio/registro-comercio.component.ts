import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl, Validators, } from '@angular/forms';
import { BsDatepickerModule, BsDatepickerConfig, DateFormatter } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-registro-comercio',
  templateUrl: './registro-comercio.component.html',
  styleUrls: ['./registro-comercio.component.scss']
})
export class RegistroComercioComponent implements OnInit {

  registerForm = new FormGroup({
    nombreRepresentante : new FormControl('', Validators.required),
    apellidoRepresentante : new FormControl('', Validators.required),
    razonSocial : new FormControl('', Validators.required),
    telefono : new FormControl('', Validators.required),
    email : new FormControl('', [Validators.required, Validators.email]),
    password : new FormControl('', Validators.required),
    
  });
    

  constructor() { }

  ngOnInit(): void {
  }

  registrarComercio(){
    console.log('registrar');
    console.log('Form -> ',this.registerForm.value);
  }

}


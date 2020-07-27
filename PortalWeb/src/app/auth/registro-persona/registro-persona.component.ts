import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl, Validators, } from "@angular/forms";
import { BsDatepickerModule, BsDatepickerConfig, DateFormatter } from "ngx-bootstrap/datepicker";


@Component({
  selector: 'app-registro-persona',
  templateUrl: './registro-persona.component.html',
  styleUrls: ['./registro-persona.component.scss'],

})
export class RegistroPersonaComponent implements OnInit {
  datePickerConfig : Partial<BsDatepickerConfig>;
  
  registerForm = new FormGroup({
    usuario : new FormControl('', Validators.required),
    email : new FormControl('', [Validators.required, Validators.email]),
    password : new FormControl('', Validators.required),
    nombre : new FormControl('', Validators.required),
    apellido: new FormControl('', Validators.required),
    fechaNacimiento : new FormControl(null, Validators.required),
    telefono : new FormControl('', Validators.required),
    
    //genero : new FormControl(''),    
    //numId : new FormControl('', Validators.required)

  });


  constructor() {
    this.datePickerConfig = Object.assign({}, 
      { 
        containerClass: 'theme-blue',
        dateInputFormat:'DD/MM/YYYY',
        isAnimated: true,
        adaptivePosition: true
        /* minDate : new Date(2018,0,1),
        maxDate : new Date(2018,11,31), */  
      });
   }

  ngOnInit(): void {
    
  }

formatDate(){
  let day = this.registerForm.value.fechaNacimiento.getDate()
  let month = this.registerForm.value.fechaNacimiento.getMonth() + 1
  let year = this.registerForm.value.fechaNacimiento.getFullYear()
  
  if (day<10) {
    day=`0${day}`
    
  }
  if (month<10) {
    month=`0${month}`
  }
  return (`${day}/${month}/${year}`)
}

  registrarPersona(){
    console.log('registrar');
    console.log('Form -> ',this.registerForm.value);

  }
}

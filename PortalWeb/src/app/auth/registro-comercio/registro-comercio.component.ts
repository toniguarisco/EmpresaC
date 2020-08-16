import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl, Validators, } from '@angular/forms';
import { BsDatepickerModule, BsDatepickerConfig, DateFormatter } from 'ngx-bootstrap/datepicker';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-registro-comercio',
  templateUrl: './registro-comercio.component.html',
  styleUrls: ['./registro-comercio.component.scss']
})
export class RegistroComercioComponent implements OnInit {


  registerForm = new FormGroup({
    usuario : new FormControl('ricardoPersona', Validators.required),
    email : new FormControl('bastvai@gmail.com', [Validators.required, Validators.email]),
    password : new FormControl('1234', [Validators.required]),
    nombre : new FormControl('Ricardo', Validators.required),
    segundoNombre : new FormControl('Alejandro', Validators.required),
    apellido: new FormControl('Bastardo', Validators.required),
    segundoApellido: new FormControl('Rodruiguez', Validators.required),
    fechaNacimiento : new FormControl(null, Validators.required),
    telefono : new FormControl('04149334665', [Validators.required, Validators.pattern('^[0-9]*$')]),
    direccion : new FormControl('Caricuao', Validators.required)

  });
/* 
{
  "usuario": "string",
  "fechaRegistro": "2020-08-16T22:06:08.713Z",
  "numIdentificacion": 0,
  "email": "string",
  "telefono": "string",
  "direccion": "string",
  "direrazon_socialccion": "string",
  "nombreRepresentante": "string",
  "apellidoRepresentante": "string",
  "contrasena": "string"
}
 */
  constructor( private userService: UserService) { }

  ngOnInit(): void {
  }

  formatoDate(fecha: Date){
    // "Sun Aug 16 2020 14:30:19 GMT-0400 (hora de Venezuela)"
    // Con formato
    let dia: string;
    let mes: string;
    let hora: string;
    let minutos: string;
    let segundos: string;
    let mlsegundos: string;
    // Sin formato
    let day = fecha.getDate();
    let month = fecha.getMonth() + 1;
    let year = fecha.getFullYear();
    let hour = fecha.getHours();
    let minutes = fecha.getMinutes();
    let seconds = fecha.getSeconds();
    let mlseconds = fecha.getMilliseconds();

    //  Transformaciones
    if (day < 10) { dia = `0${day}`; }
      else{dia = day.toString(); }
    
    if (month < 10) { mes = `0${month}`; }
      else{ mes = month.toString(); }

    if (hour < 10) { hora = `0${hour.toString()}`; }
      else{hora = hour.toString(); }
    
    if (minutes < 10) { minutos = `0${minutes.toString()}`; }
      else{minutos = minutes.toString(); }
    
    if (seconds < 10) { segundos = `0${seconds.toString()}`; }
      else{segundos = seconds.toString(); }
    
    if (seconds < 10) { segundos = `0${seconds.toString()}`; }
      else{segundos = seconds.toString(); }

    if (mlseconds < 100) { mlsegundos = `0${mlseconds.toString()}`; }
      else{
        if (mlseconds < 10) { mlsegundos = `00${mlseconds.toString()}`; }
        else{mlsegundos = mlseconds.toString(); }
      }

    if (mlseconds < 10) { mlsegundos = `00${mlseconds.toString()}`; }
      else{mlsegundos = mlseconds.toString(); }
   
        // "fecha": "2020-08-16T15:00:44.859Z",
    return (`${year}-${mes}-${dia}T${hora}:${minutos}:${segundos}.${mlsegundos}Z`.toString());
  }

  registrarComercio(){
    console.log('registrar');
    console.log('Form -> ', this.registerForm.value);
    console.log('fechaaNacimiento -> ', this.formatoDate(this.registerForm.value.fechaNacimiento));
    console.log('fechaaRegistro -> ', this.formatoDate(new Date()));
    let fechaNac = this.formatoDate(this.registerForm.value.fechaNacimiento);
    let fechaRegistro =  this.formatoDate(new Date());

    this.userService.registrarPersona(this.registerForm.value.usuario,
                                      this.registerForm.value.email,
                                      this.registerForm.value.password,
                                      this.registerForm.value.nombre,
                                      this.registerForm.value.segundoNombre ,
                                      this.registerForm.value.apellido,
                                      this.registerForm.value.segundoApellido,
                                      fechaNac,
                                      this.registerForm.value.telefono,
                                      this.registerForm.value.direccion,
                                      fechaRegistro)
    .subscribe(
      res =>{
        alert('Persona Registrada con exito');
      },
      error => {
        alert('Persona no pudo ser regitrada');
      });

  }
  

}


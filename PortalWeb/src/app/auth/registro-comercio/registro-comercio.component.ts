import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl, Validators, } from '@angular/forms';
import { BsDatepickerModule, BsDatepickerConfig, DateFormatter } from 'ngx-bootstrap/datepicker';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registro-comercio',
  templateUrl: './registro-comercio.component.html',
  styleUrls: ['./registro-comercio.component.scss']
})
export class RegistroComercioComponent implements OnInit {


  registerForm = new FormGroup({
    usuario : new FormControl('ricardoComercio', Validators.required),
    email : new FormControl('rabastardo.11@est.ucab.edu.ve', [Validators.required, Validators.email]),
    password : new FormControl('1234', [Validators.required]),
    nombreRepresentante : new FormControl('Ricardo', Validators.required),
    apellidoRepresentante: new FormControl('Bastardo', Validators.required),
    telefono : new FormControl('04127140849', [Validators.required, Validators.pattern('^[0-9]*$')]),
    direccion : new FormControl('Caricuao', Validators.required),
    razon_social : new FormControl('Nestle S.A.', Validators.required)

  });

  constructor( private userService: UserService,
               private router: Router) { }

  ngOnInit(): void {
  }

  formatoDate(fecha: Date){
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
    console.log('fechaaRegistro -> ', this.formatoDate(new Date()));
    let fechaRegistro =  this.formatoDate(new Date());

    this.userService.registrarComercio(this.registerForm.value.usuario,
                                      fechaRegistro,
                                      this.registerForm.value.email,
                                      this.registerForm.value.telefono,
                                      this.registerForm.value.direccion,
                                      this.registerForm.value.razon_social,
                                      this.registerForm.value.nombreRepresentante,
                                      this.registerForm.value.apellidoRepresentante,
                                      this.registerForm.value.password
                                      )
    .subscribe(
      res => {
        alert('Comercio Registrado con exito');
        this.router.navigate(['/login']);
      },
      error => {
        alert('El Comercio no pudo ser regitrado');
      });
  }
}


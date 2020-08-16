import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { UserService } from '../../../services/user.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-recarga',
  templateUrl: './recarga.component.html',
  styleUrls: ['./recarga.component.scss']
})
export class RecargaComponent implements OnInit {

  public cuentas = [];

  registerForm = new FormGroup({
    cuenta : new FormControl('', Validators.required),
    monto: new FormControl('', [Validators.required, Validators.pattern("^[0-9]*$")]),
    });

 
  
  

  constructor(private userService: UserService) { }

  ngOnInit(  ): void {

    this.userService.getCuentas(localStorage.getItem('idUsuario'))
    .subscribe(res => {

      console.log(res);
      res.forEach(element => {
        this.cuentas.push({mostrar: element.banco + ' ' + element.cuenta, cuenta: element.cuenta, monto : element.monto});
      });
      

      /* let fecha = new Date();
    console.log('la fechaaa ', fecha.getFullYear(),fecha.getMonth(),fecha.getDate());
    console.log('la fechaaa ', fecha.toLocaleDateString());
    console.log('la fechaaa ', fecha.getUTCMonth());
    console.log('la fechaaa ', fecha.getHours());
    console.log('la fechaaa ', fecha.getMinutes());
    console.log('la fechaaa ', fecha.getSeconds());
    console.log('la fechaaa ', fecha.getUTCSeconds());
    console.log('la fechaaa ', fecha.getMilliseconds());
    console.log('la fechaaa ', fecha.getUTCMilliseconds()); */


    
  },
  error => {
    console.log('error ->', error);
  }
  );
  

  }

  formatoDate(){
    let fecha = new Date();
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

  recargarSaldo(): void{
    console.log('recargar');
    console.log('Form -> ', this.registerForm.value);

    let fechaD: string = this.formatoDate();
    this.userService.recargarSaldo(fechaD, this.registerForm.value.monto, this.registerForm.value.cuenta)
    .subscribe(
      res => {
        alert('Recarga Exitosa');
      },
      error => {
        alert('Recarga Fallida');
      }
    );
  }


}

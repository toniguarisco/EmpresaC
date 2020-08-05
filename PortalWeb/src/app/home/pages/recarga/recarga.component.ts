import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-recarga',
  templateUrl: './recarga.component.html',
  styleUrls: ['./recarga.component.scss']
})
export class RecargaComponent implements OnInit {

 
  billeteraForm = new FormGroup({
    monto : new FormControl('', Validators.required)

  });

  tarjetaForm = new FormGroup({
    monto2 : new FormControl('', Validators.required),
    banco : new FormControl('', Validators.required),
    numeroTarjeta : new FormControl('', Validators.required),
    codigoSeguridad : new FormControl('', Validators.required)
  });

  constructor() { }

  ngOnInit(): void {
  }

  porBilletera(): void{
  }

  porTarjeta(): void{
  }

}

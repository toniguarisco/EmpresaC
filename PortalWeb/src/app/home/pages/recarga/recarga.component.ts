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

  sortOrders: string[] = ["Billetera 1", "Billetera 2", "Billetera 3"];
  selectedSortOrder: string = "Seleccionar Billetera";



 

 
  
  

  constructor() { }

  ngOnInit(): void {
  }

  ChangeSortOrder(newSortOrder: string) { 
    this.selectedSortOrder = newSortOrder;
  }

  porBilletera(): void{
    console.log('Recarga por billetera');
    console.log('Form -> ',this.billeteraForm.value);

  }

  porTarjeta(): void{
    console.log('Recarga por tarjeta');
    console.log('Form -> ',this.tarjetaForm.value);

  }

}

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-admin-cantidad-operaciones',
  templateUrl: './admin-cantidad-operaciones.component.html',
  styleUrls: ['./admin-cantidad-operaciones.component.scss']
})
export class AdminCantidadOperacionesComponent implements OnInit {

  saldoForm = new FormGroup({
    saldo : new FormControl('', Validators.required),

  });
  
  public operaciones: Array <{
    id: number,
    tipo: string,
    total: string,

       }> = [
      {id: 0, tipo: 'Pagos', total: '240340'},
      {id: 1, tipo: 'Recargas', total: '150600'},
      {id: 2, tipo: 'Reintegros', total: '8900'},
      {id: 3, tipo: 'Retiro de fondos', total: '12030'},
      {id: 4, tipo: 'Cierre de cajas', total: '5440'},
      {id: 5, tipo: 'Operaicones fallidas', total: '1213'}
];
dtOptions: DataTables.Settings = {};

  constructor() { }

  saldoActual(): void{

  }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      columns: [
      {title: 'ID', data: 'id'},
      {title: 'Tipo de Operacion', data: 'tipo'},
      {title: 'Total de Operaciones', data: 'total'}
      ]
  };

 
}

}



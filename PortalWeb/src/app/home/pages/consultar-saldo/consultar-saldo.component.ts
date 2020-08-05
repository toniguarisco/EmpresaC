import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-consultar-saldo',
  templateUrl: './consultar-saldo.component.html',
  styleUrls: ['./consultar-saldo.component.scss']
})
export class ConsultarSaldoComponent implements OnInit {

  saldoForm = new FormGroup({
    saldo : new FormControl('', Validators.required),

  });
  
  public operaciones: Array <{
    id: number,
    monto: string,
    fecha: string,
    concepto: string,
   }> = [
      {id: 0, monto: '100.00', fecha: '20-03-2019', concepto: 'recarga carmelita'},
      {id: 1, monto: '-150.00', fecha: '23-03-2019', concepto: 'recarga carmelita'},
      {id: 2, monto: '300.00', fecha: '29-03-2019', concepto: 'para los viveres'},
      {id: 3, monto: '400.00', fecha: '02-04-2019', concepto: 'abono '},
      {id: 4, monto: '-1000.00', fecha: '09-04-2019', concepto: 'recarga carmelita'},
      {id: 5, monto: '2000.00', fecha: '20-04-2019', concepto: 'para los viveres'},
      {id: 6, monto: '1000.00', fecha: '20-05-2019', concepto: 'abono '},
      {id: 7, monto: '3000.00', fecha: '25-05-2019', concepto: 'recarga carmelita'},
      {id: 8, monto: '1000.00', fecha: '02-06-2019', concepto: 'recarga carmelita'},
      {id: 9, monto: '1000.00', fecha: '04-06-2019', concepto: 'abono '},
      {id: 1, monto: '4000.00', fecha: '20-06-2019', concepto: 'para los viveres'},
      {id: 11, monto: '1000.00', fecha: '23-06-2019', concepto: 'recarga carmelita'},
      {id: 12, monto: '1000.00', fecha: '25-06-2019', concepto: 'recarga carmelita'},
      {id: 13, monto: '-10000.00', fecha: '29-06-2019', concepto: 'para los viveres'},
      {id: 14, monto: '1000.00', fecha: '20-07-2019', concepto: 'abono '},
      {id: 16, monto: '1000.00', fecha: '21-07-2019', concepto: 'recarga carmelita'},
      {id: 17, monto: '1000.00', fecha: '28-07-2019', concepto: 'recarga carmelita'},
      {id: 18, monto: '1000.00', fecha: '12-08-2019', concepto: 'recarga carmelita'},
      {id: 19, monto: '8000.00', fecha: '20-08-2019', concepto: 'para los viveres'},
      {id: 20, monto: '1000.00', fecha: '17-09-2019', concepto: 'recarga carmelita'},
      {id: 21, monto: '1412.00', fecha: '25-09-2019', concepto: 'abono '}
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
      {title: 'Monto', data: 'monto'},
      {title: 'Fecha', data: 'fecha'},
      {title: 'Concepto', data: 'concepto'},
      ]
  };

 
}

}



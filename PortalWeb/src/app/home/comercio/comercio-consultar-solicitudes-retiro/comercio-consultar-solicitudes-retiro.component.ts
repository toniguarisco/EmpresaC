import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-comercio-consultar-solicitudes-retiro',
  templateUrl: './comercio-consultar-solicitudes-retiro.component.html',
  styleUrls: ['./comercio-consultar-solicitudes-retiro.component.scss']
})
export class ComercioConsultarSolicitudesRetiroComponent implements OnInit {

  public operaciones: Array <{
    id: number,
    monto: string,
    fecha: string,
       }> = [
      {id: 0, monto: '100.00', fecha: '20-03-2019'},
      {id: 1, monto: '150.00', fecha: '23-03-2019'},
      {id: 2, monto: '300.00', fecha: '29-03-2019'},
      {id: 3, monto: '400.00', fecha: '02-04-2019'},
      {id: 4, monto: '1000.00', fecha: '09-04-2019'},
      {id: 5, monto: '2000.00', fecha: '20-04-2019'},
      {id: 6, monto: '1000.00', fecha: '20-05-2019'},
      {id: 7, monto: '3000.00', fecha: '25-05-2019'},
      {id: 8, monto: '1000.00', fecha: '02-06-2019'},
      {id: 9, monto: '1000.00', fecha: '04-06-2019'},
      {id: 1, monto: '4000.00', fecha: '20-06-2019'},
      {id: 11, monto: '1000.00', fecha: '23-06-2019'},
      {id: 12, monto: '1000.00', fecha: '25-06-2019'},
      {id: 13, monto: '10000.00', fecha: '29-06-2019'},
      {id: 14, monto: '1000.00', fecha: '20-07-2019'},
      {id: 16, monto: '1000.00', fecha: '21-07-2019'},
      {id: 17, monto: '1000.00', fecha: '28-07-2019'},
      {id: 18, monto: '1000.00', fecha: '12-08-2019'},
      {id: 19, monto: '8000.00', fecha: '20-08-2019'},
      {id: 20, monto: '1000.00', fecha: '17-09-2019'},
      {id: 21, monto: '1412.00', fecha: '25-09-2019'}
];
dtOptions: DataTables.Settings = {};

  constructor() { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      columns: [
      {title: 'ID', data: 'id'},
      {title: 'Monto Retiro', data: 'monto'},
      {title: 'Fecha', data: 'fecha'},
      ]
  };
}

}
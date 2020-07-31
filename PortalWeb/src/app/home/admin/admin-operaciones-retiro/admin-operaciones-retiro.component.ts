import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-operaciones-retiro',
  templateUrl: './admin-operaciones-retiro.component.html',
  styleUrls: ['./admin-operaciones-retiro.component.scss']
})
export class AdminOperacionesRetiroComponent implements OnInit {

  public operaciones: Array <{id: number,
    tipo: string,
    monto: string,
    informacion: string,
    fecha: string,
    estado: string}> = [
      {id: 0, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 1, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 2, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 3, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
      {id: 4, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 5, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 6, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
      {id: 7, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 8, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 9, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
      {id: 1, tipo: 'Retiro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 11, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 12, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 13, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 14, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
      {id: 16, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 17, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 18, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 19, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 20, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 21, tipo: 'Reitro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'}
];


dtOptions: DataTables.Settings = {};

constructor() { }

ngOnInit(): void {
this.dtOptions = {
pagingType: 'full_numbers',
pageLength: 10,
columns: [{title: 'ID', data: 'id'},
{title: 'Tipo', data: 'tipo'},
{title: 'Monto', data: 'monto'},
{title: 'Informacion', data: 'informacion'},
{title: 'Fecha', data: 'fecha'},
{title: 'Estado', data: 'estado'},
]
};
}


}

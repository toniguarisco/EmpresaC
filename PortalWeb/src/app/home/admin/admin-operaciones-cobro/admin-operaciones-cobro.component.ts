import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-operaciones-cobro',
  templateUrl: './admin-operaciones-cobro.component.html',
  styleUrls: ['./admin-operaciones-cobro.component.scss']
})
export class AdminOperacionesCobroComponent implements OnInit {

  public operaciones: Array <{id: number,
    tipo: string,
    monto: string,
    informacion: string,
    fecha: string,
    estado: string}> = [
      {id: 0, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 1, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 2, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 3, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
      {id: 4, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 5, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 6, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
      {id: 7, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 8, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 9, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
      {id: 1, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 11, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 12, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 13, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 14, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
      {id: 16, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 17, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 18, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 19, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'En Proceso'},
      {id: 20, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'Exitosa'},
      {id: 21, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'}
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

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-operaciones-fallidas',
  templateUrl: './admin-operaciones-fallidas.component.html',
  styleUrls: ['./admin-operaciones-fallidas.component.scss']
})
export class AdminOperacionesFallidasComponent implements OnInit {

public operaciones: Array <{id: number,
                            tipo: string,
                            monto: string,
                            informacion: string,
                            fecha: string,
                            estado: string}> = [
                              {id: 0, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 1, tipo: 'Recarga', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 2, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 3, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 4, tipo: 'Recarga', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 5, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 6, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 7, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 8, tipo: 'Recarga', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 9, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 1, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 11, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 12, tipo: 'Recarga', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 13, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 14, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 16, tipo: 'Recarga', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 17, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 18, tipo: 'Cobro', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 19, tipo: 'Recarga', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 20, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'},
                              {id: 21, tipo: 'Pago', monto: '1000.00', informacion: 'Info', fecha: '20-03-2019', estado: 'fallido'}
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

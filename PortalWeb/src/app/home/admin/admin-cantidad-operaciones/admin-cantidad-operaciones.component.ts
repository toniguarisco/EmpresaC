import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { AdminService } from '../../../services/admin.service';
@Component({
  selector: 'app-admin-cantidad-operaciones',
  templateUrl: './admin-cantidad-operaciones.component.html',
  styleUrls: ['./admin-cantidad-operaciones.component.scss']
})
export class AdminCantidadOperacionesComponent implements OnInit {

  saldoForm = new FormGroup({
    saldo : new FormControl('', Validators.required),

  });
  // referencia: "57898775", monto: 222, tipoOperacion: "recarga banco tarjeta", cantidadOperacion: 1}
  public saldo: string;
  /*   public misOperaciones: Array<any> = []; */
     public misOperaciones: Array <{
      cantidadOperacion: string,
      monto: string,
      referencia: string,
      tipoOperacion: string
     }> = [];

dtOptions: DataTables.Settings = {};

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      columns: [
      {title: 'Fecha', data: 'fecha'},
      {title: 'Monto', data: 'monto'},
      {title: 'Numero de Referencia', data: 'referencia'},
      {title: 'Tipo de operacion', data: 'tipoOperacion'}
      ]
  };

    this.adminService.getCantidadOperacion()
    .subscribe(
      res => {
        console.log('respuesta de cantidad de operacion', res );
        res.forEach( element => {
        this.misOperaciones.push({cantidadOperacion: element.cantidadOperacion,
                                   monto: element.monto,
                                   referencia: element.referencia,
                                   tipoOperacion: element.tipoOperacion});
        });
     
     },
      error => {
        console.log('error de cantidad de operacion', error );
    }
  )
   /*  this.adminService.getBalance(localStorage.getItem('idUsuario'))
    .subscribe(res => {
 
      // Asignando el Saldo
      this.saldo = res.monto;

      // LLenando el array para mostrar
      res.historyOperations.forEach( element => {
 
        this.misOperaciones.push({fecha: element.fecha,
                                  monto: element.monto,
                                  operation: element.operation ,
                                  referencia: element.referencia,
                                  tipoOperacion: element.tipoOperacion});
      });

      console.log('misOperaciones -> ', this.misOperaciones);
    }, error => {
      console.log('de nuevo por error');
      console.log('error; ->',error);
    }
    ); */

  
  }

  

}

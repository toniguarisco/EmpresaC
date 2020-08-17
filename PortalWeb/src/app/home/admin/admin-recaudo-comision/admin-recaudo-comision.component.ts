import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { AdminService } from '../../../services/admin.service';

@Component({
  selector: 'app-admin-recaudo-comision',
  templateUrl: './admin-recaudo-comision.component.html',
  styleUrls: ['./admin-recaudo-comision.component.scss']
})
export class AdminRecaudoComisionComponent implements OnInit {

  public total: number;
  public misRecaudos: Array <{
    usuario: string,
    monto: number,

   }> = [];


  dtOptions: DataTables.Settings = {};

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      columns: [
      {title: 'Comercio', data: 'usuario'},
      {title: 'Monto por Recaudos', data: 'monto'},
      ]
  };
    this.adminService.getTotalRecaudos()
    .subscribe(
      res => {
        console.log('res total recaudos =>', res);
        this.total = res.totalComision;
        res.readComisiones.forEach(element =>{
          this.misRecaudos.push({usuario: element.usuario, monto : element.monto});
        });
        console.log( this.misRecaudos);
      },
      error => {
        console.log('error total recaudos =>', error);
      }
    )
  }

  consultarTotalEmpresa(): void{
    console.log('click en actualizar parametros');
    console.log(this.parametrosForm.value);
    
  }

  consultarTotalTotal(): void{
    console.log('click en actualizar comision');
    console.log(this.comisionForm.value);
  }

}

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-consultar-sub-usuarios',
  templateUrl: './consultar-sub-usuarios.component.html',
  styleUrls: ['./consultar-sub-usuarios.component.scss']
})
export class ConsultarSubUsuariosComponent implements OnInit {

  public operaciones: Array <{
    id: number,
  nombre: string,
    apellido: string,
    telefono: string,

   }> = [
      {id: 0,nombre: 'Carlos', apellido: 'Perez', telefono: '0414323349'},
      {id: 1,nombre: 'Karla', apellido: 'Perez', telefono: '04120953112'},
      {id: 2,nombre: 'Manuel', apellido: 'Perez', telefono: '04164566312'},
      {id: 3,nombre: 'Marcia', apellido: 'Avila', telefono: '04249089021 '},
      
];
dtOptions: DataTables.Settings = {};

  constructor() { }


  

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      columns: [
      {title: 'ID', data: 'id'},
      {title: 'Nombre', data: 'nombre'},
      {title: 'Apellido', data: 'apellido'},
      {title: 'Telefono', data: 'telefono'},
      ]
  };

 
}

}




import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-consultar-subusuarios',
  templateUrl: './consultar-subusuarios.component.html',
  styleUrls: ['./consultar-subusuarios.component.scss']
})
export class ConsultarSubusuariosComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  constructor(public userService: UserService) { }

  /*   {
    "nombre": "string",
    "segundoNombre": "string",
    "apellido": "string",
    "segundoApellido": "string",
    "descripcionEstadoCivil": "string",
    "usuario": "string",
    "email": "string",
    "telefono": "string",
    "direccion": "string"
  } */

  public hijos: Array <{
    nombre: string,
    apellido: string,
    usuario: string,
    email: string,
    telefono: string
   }> = []; 

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      columns: [
      {title: 'Nombre', data: 'nombre'},
      {title: 'Apellido', data: 'apellido'},
      {title: 'Usuario', data: 'usuario'},
      {title: 'Email', data: 'email'},
      {title: 'Telefono', data: 'telefono'},
      ]
  }
  // Obteniendo el Saldo
    this.userService.getHijos(localStorage.getItem('idUsuario'))
    .subscribe(res => {

      console.log(res);
    // LLenando el array para mostrar
      res.forEach(element => {
      this.hijos.push({nombre: element.nombre,
                       apellido: element.apellido,
                       usuario: element.usuario ,
                       email: element.email,
                       telefono: element.telefono});
    });

  });

}
}
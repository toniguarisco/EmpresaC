import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

import { Router } from '@angular/router';

@Component({
  selector: 'app-administrar-usuarios',
  templateUrl: './administrar-usuarios.component.html',
  styleUrls: ['./administrar-usuarios.component.scss']
})
export class AdministrarUsuariosComponent implements OnInit {

  message = '';

   public persons: Array <{id: number, nombre: string, apellido: string}> = [
    {id: 0, nombre: 'Ricardo', apellido: 'Bastardo'},
    {id: 1, nombre: 'Ricardo1', apellido: 'Bastardo1'},
    {id: 2, nombre: 'Ricardo2', apellido: 'Bastardo2'},
    {id: 3, nombre: 'Ricardo3', apellido: 'Bastardo3'},
    {id: 4, nombre: 'Ricardo3', apellido: 'Bastardo3'},
    {id: 5, nombre: 'Ricardo3', apellido: 'Bastardo3'},
    {id: 6, nombre: 'Ricardo3', apellido: 'Bastardo3'},
    {id: 7, nombre: 'Ricardo3', apellido: 'Bastardo3'},
    {id: 8, nombre: 'Ricardo3', apellido: 'Bastardo3'},
    {id: 9, nombre: 'Ricardo3', apellido: 'Bastardo3'},
    {id: 10, nombre: 'Ricardo3', apellido: 'Bastardo3'}
];
  dtOptions: DataTables.Settings = {};
 // dtTrigger: Subject = new Subject();

  constructor(private router: Router) { }

  ngOnInit(): void {

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      columns: [{
        title: 'ID',
        data: 'id'
      }, {
        title: 'Nombre',
        data: 'nombre'
      }, {
        title: 'Apellido',
        data: 'apellido'
      }],
      rowCallback: (row: Node, data: any[] | Object, index: number) => {
        const self = this;
        // Unbind first in order to avoid any duplicate handler
        // (see https://github.com/l-lin/angular-datatables/issues/87)
        $('td', row).off('click');
        $('td', row).on('click', () => {
          self.someClickHandler(data);
        });
        return row;
      }
    };

  }

  someClickHandler(info: any): void {
    this.message = info.id + ' - ' + info.nombre;
    console.log('a navegar');
    this.router.navigate(['/home/admin-modificar-usuario'], { state: { info} });
  }

}

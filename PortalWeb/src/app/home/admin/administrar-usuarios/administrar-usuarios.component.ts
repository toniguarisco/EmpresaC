import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { BsDatepickerConfig, BsDatepickerModule, DateFormatter } from 'ngx-bootstrap/datepicker';
import { FormGroup, FormControl, Validators } from '@angular/forms';

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

//*** PARA OTRO COMPONENTE */

datePickerConfig : Partial<BsDatepickerConfig>;

registerForm = new FormGroup({
  usuario : new FormControl('', Validators.required),
  email : new FormControl('', [Validators.required, Validators.email]),
  password : new FormControl('', Validators.required),
  nombre : new FormControl('', Validators.required),
  apellido: new FormControl('', Validators.required),
  fechaNacimiento : new FormControl(null, Validators.required),
  telefono : new FormControl('', Validators.required),
  
  //genero : new FormControl(''),    
  //numId : new FormControl('', Validators.required)
});


  constructor() {

    this.datePickerConfig = Object.assign({},
      {
        containerClass: 'theme-blue',
        dateInputFormat:'DD/MM/YYYY',
        isAnimated: true,
        adaptivePosition: true
        /* minDate : new Date(2018,0,1),
        maxDate : new Date(2018,11,31), */
      });
   }


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
  }




  //******OTRO COMPONENTE */
  formatDate(){
    let day = this.registerForm.value.fechaNacimiento.getDate()
    let month = this.registerForm.value.fechaNacimiento.getMonth() + 1
    let year = this.registerForm.value.fechaNacimiento.getFullYear()
    
    if (day<10) {
      day=`0${day}`
      
    }
    if (month<10) {
      month=`0${month}`
    }
    return (`${day}/${month}/${year}`)
  }
  
    registrarPersona(){
      console.log('registrar');
      console.log('Form -> ',this.registerForm.value);
  
    }

}

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-mostrar-cuentas',
  templateUrl: './mostrar-cuentas.component.html',
  styleUrls: ['./mostrar-cuentas.component.scss']
})
export class MostrarCuentasComponent implements OnInit {

  public misCuentas: Array <{
    cuenta: string
    tipo: string,
    banco: string,
   }> = [];

   dtOptions: DataTables.Settings = {};

  constructor(private userService: UserService) { }

  ngOnInit(): void {
   
    this.userService.getCuentas(localStorage.getItem('idUsuario'))
    .subscribe(res => {

      console.log(res);
      // LLenando el array para mostrar
      res.forEach(element => {
        
        this.misCuentas.push({cuenta: element.cuenta,
                              tipo: element.tipo,
                              banco: element.banco});
      });

      console.log('misCuentas -> ', this.misCuentas);

      this.dtOptions = {
        pagingType: 'full_numbers',
        pageLength: 3,
        columns: [
        {title: 'Numero de Cuenta', data: 'cuenta'},
        {title: 'Tipo', data: 'tipo'},
        {title: 'Banco', data: 'banco'},
        ],
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
      }
  });

}

someClickHandler(info: any): void {
  //this.message = info.id + ' - ' + info.nombre;
  console.log('a navegar');
  //this.router.navigate(['/home/admin-modificar-usuario'], { state: { info} });
}
}

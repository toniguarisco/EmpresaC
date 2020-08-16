import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { UserService } from '../../../services/user.service';


@Component({
  selector: 'app-recarga',
  templateUrl: './recarga.component.html',
  styleUrls: ['./recarga.component.scss']
})
export class RecargaComponent implements OnInit {

  public cuentas = [];

  registerForm = new FormGroup({
    cuenta : new FormControl('', Validators.required),
    monto: new FormControl('', [Validators.required,Validators.pattern("^[0-9]*$")]),
    });

 
  
  

  constructor(private userService: UserService) { }

  ngOnInit(  ): void {

    this.userService.getCuentas(localStorage.getItem('idUsuario'))
    .subscribe(res => {

      console.log(res);
      res.forEach(element => {
        this.cuentas.push(element.banco + ' ' + element.cuenta);
      });
      
  });

    /* {
  "fecha": "2020-08-16T07:43:13.724Z",
  "hora": {},
  "monto": 0,
  "idUSuario": 0,
  "cuenta": "string"
} */
  }
  recargarSaldo(): void{
    console.log('recargar');
    console.log('Form -> ', this.registerForm.value);

    /* this.userService.registrarCuenta(this.registerForm.value.cuenta,
                                    this.registerForm.value.banco,
                                    this.registerForm.value.tipo)
    .subscribe(
     resp => {
      console.log('res ->' , resp);
      alert('Cuenta agregada exitosamente');
     },
     error => {
      console.log('error ->' , error.error.text);
      alert(error.error.text);
     }); */
  }


}

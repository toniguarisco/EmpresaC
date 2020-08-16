import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, } from '@angular/forms';
import { UserService } from '../../../services/user.service';


@Component({
  selector: 'app-ingresar-cuenta',
  templateUrl: './ingresar-cuenta.component.html',
  styleUrls: ['./ingresar-cuenta.component.scss']
})
export class IngresarCuentaComponent implements OnInit {

  public misCuentas: Array <{
    cuenta: string
    tipo: string,
    banco: string,
   }> = [];

  registerForm = new FormGroup({
    cuenta : new FormControl('', [Validators.required, Validators.minLength(10), Validators.pattern("^[0-9]*$")]),
    banco : new FormControl('', Validators.required),
    tipo: new FormControl('', Validators.required),
    });
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

  
  });
  }

  get cuenta() { return this.registerForm.get('cuenta'); }
  get banco() { return this.registerForm.get('banco'); }
  get tipo() { return this.registerForm.get('tipo'); }

  registrarCuenta(): void{
    console.log('registrar');
    console.log('Form -> ', this.registerForm.value);

    this.misCuentas.forEach(element => {
      if (element.cuenta === this.registerForm.value.cuenta &&
          element.banco === this.registerForm.value.banco){
            alert('Esta cuuenta ya se encuentra regitrada');
            return;
          }
    });

    this.userService.registrarCuenta(this.registerForm.value.cuenta,
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
     });
  }
}

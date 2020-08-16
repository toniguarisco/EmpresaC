import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, } from '@angular/forms';
import { UserService } from '../../../services/user.service';
import { error } from 'console';

@Component({
  selector: 'app-ingresar-cuenta',
  templateUrl: './ingresar-cuenta.component.html',
  styleUrls: ['./ingresar-cuenta.component.scss']
})
export class IngresarCuentaComponent implements OnInit {

  registerForm = new FormGroup({
    cuenta : new FormControl('', [Validators.required, Validators.minLength(10)]),
    banco : new FormControl('', Validators.required),
    tipo: new FormControl('', Validators.required),
    });
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      cuenta : new FormControl('', [Validators.required, Validators.minLength(10)]),
      banco : new FormControl('', Validators.required),
      tipo: new FormControl('', Validators.required),
      });
  }

  get cuenta() { return this.registerForm.get('cuenta'); }
  get banco() { return this.registerForm.get('banco'); }
  get tipo() { return this.registerForm.get('tipo'); }

  registrarCuenta(): void{
    console.log('registrar');
    console.log('Form -> ', this.registerForm.value);
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

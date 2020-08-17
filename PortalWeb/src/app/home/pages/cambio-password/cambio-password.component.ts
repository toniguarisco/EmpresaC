import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-cambio-password',
  templateUrl: './cambio-password.component.html',
  styleUrls: ['./cambio-password.component.scss']
})
export class CambioPasswordComponent implements OnInit {

  registerForm = new FormGroup({
    newPassword : new FormControl('', [Validators.required]),
    oldPassword : new FormControl('', Validators.required),
    });

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  cambiarPassword(){

    if (this.registerForm.value.newPassword === this.registerForm.value.oldPassword) {
      alert('las claves no pueden ser iguales');
      return;
    }

    this.userService.cambiarPassword(this.registerForm.value.newPassword,
      this.registerForm.value.oldPassword)
      .subscribe(
      resp => {
      console.log('res ->' , resp);
      alert('Cambio de contraseña exitoso.');
      },
      error => {
        if (error.error.text === 'Contraseña actualizada'){
          alert('Cambio de contraseña exitoso.');
        }else{
          alert('Cambio de contraseña fallido.');
        }});
        }

}

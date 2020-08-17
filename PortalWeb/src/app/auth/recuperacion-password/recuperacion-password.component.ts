import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-recuperacion-password',
  templateUrl: './recuperacion-password.component.html',
  styleUrls: ['./recuperacion-password.component.scss']
})
export class RecuperacionPasswordComponent implements OnInit {

  registerForm = new FormGroup({
    email : new FormControl('bastvai@gmail.com', [Validators.required, Validators.email]),
    });
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  recuperarPassword(){
    this.authService.recuperarPassword(this.registerForm.value.email)
      .subscribe(
      resp => {
      console.log('res ->' , resp);
      alert('Se le ha enviado una nueva contraseña a su correo. ');
      },
      error => {

        if (error.status === 200){
          alert('Se le ha enviado una nueva contraseña a su correo. ');
        }else{
          alert('Email incorrecto');
        }});
        }
  }


import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

import { AuthService } from '../../services/auth.service';
import { Routes, Router } from '@angular/router'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    username: new FormControl('Aron', [Validators.required]),
    password: new FormControl(123, [Validators.required, Validators.minLength(2)])
  });

  hasError: boolean;
  constructor(private authSrevice: AuthService,
              private router: Router) { }
// private token:string = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzNTM0NTQzNTQzNTQzNTM0NTMiLCJleHAiOjE1MDQ2OTkyNTZ9.zG-2FvGegujxoLWwIQfNB5IT46D-xC4e8dEDYwi6aRM';
  ngOnInit(): void {
    this.hasError = false;
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  async login(){
    console.log('Form -> ',this.loginForm.value);
    //localStorage.setItem('token', this.token);
    console.log(localStorage.getItem('token'));
    this.authSrevice.login(this.f.username.value,  this.f.password.value.toString())
    .subscribe(
      res => {
        console.log('RESPUESTA Value =>' , res.value);
        console.log('RESPUESTA token =>' , res.value.token);
        localStorage.setItem('token', res.value.token);
        this.router.navigate(['/home']);
      }
      ,err => {
        console.log('ERROR =>',err);
        this.hasError=true;
      }
    );
    console.log('de nuevo en el login');
  }

 /*  get email() {
    return this.loginForm.get('email'); 
  }
  get pass() {
    return this.loginForm.get('email'); 
  } */


  hideAlert(): void {
    this.hasError = false;
  }

}

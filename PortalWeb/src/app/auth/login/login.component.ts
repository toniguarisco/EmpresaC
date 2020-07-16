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
    email: new FormControl('',[Validators.email,Validators.required]),
    password: new FormControl('',[Validators.required, Validators.minLength(2)])
  })

  constructor(private authSrevice: AuthService,
              private router: Router) { }

  ngOnInit(): void {
  }

  login(){
    console.log('Form -> ',this.loginForm.value);
    console.log('Form -> ',this.loginForm.value.email);
    console.log('Form -> ',this.loginForm.value.password);
    /* this.authSrevice.login(this.loginForm)
    .subscribe(
      res => {
        console.log(res);
        //localStorage.setItem('token', res.token);
        this.router.navigate(['/home']);
      }
      ,err => {
        console.log(err);
      }
    ) */
  }

 /*  get email() {
    return this.loginForm.get('email'); 
  }
  get pass() {
    return this.loginForm.get('email'); 
  } */
}

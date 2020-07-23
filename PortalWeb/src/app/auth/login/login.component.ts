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

              private token:string = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzNTM0NTQzNTQzNTQzNTM0NTMiLCJleHAiOjE1MDQ2OTkyNTZ9.zG-2FvGegujxoLWwIQfNB5IT46D-xC4e8dEDYwi6aRM';
  ngOnInit(): void {
  }

  login(){
    console.log('Form -> ',this.loginForm.value);
    console.log('Form -> ',this.loginForm.value.email);
    console.log('Form -> ',this.loginForm.value.password);
    localStorage.setItem('token', 
                          this.token);
    console.log(localStorage.getItem('token'));
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
    this.router.navigate(["/home"]);
  }

 /*  get email() {
    return this.loginForm.get('email'); 
  }
  get pass() {
    return this.loginForm.get('email'); 
  } */
}

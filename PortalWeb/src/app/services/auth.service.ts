import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { LoginRoutingModule } from '../auth/login/login-routing.module';
import { Router } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url = URL;

  constructor( private http: HttpClient,
                private router: Router) { }

  login(user){

    return this.http.post<any>(this.url+ '/login', user);
  }

  logout(){
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  LoggedIn(): Boolean{
    return !!(localStorage.getItem('token'));
  }

  getToken(){
    return localStorage.getItem('token');
  }
  
}

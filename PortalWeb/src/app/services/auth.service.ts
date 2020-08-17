import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { LoginRoutingModule } from '../auth/login/login-routing.module';
import { Router } from "@angular/router";
import { Persona } from '../_model/persona';
import { Observable } from 'rxjs';
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url = environment.apiUrl;

  constructor( private http: HttpClient,
               private router: Router) { }


login(usuario, clave): Observable <any> {
  let resp;
  console.log('Estoy en el Servicio.login', usuario, ' ', clave);

  // con proxy server
  return this.http.post<any>('/api/App/login', { usuario, clave })

  /* console.log(`${this.url}/api/App/login`, { usuario, clave });
  return this.http.post<any>(`${this.url}/api/App/login`, { usuario, clave }) */
          ;


  /* try {
    resp = this.http.post<any>(`${this.url}`, { username, password });
  } catch (error) {
    console.log('ERROOOORR',error);
    return (error);
  }
  console.log('Sali del try catch');
  console.log(resp);
  return resp; */
  /*   let response;
    try{
      response = await this.http.post(`${URL}/login`,data).toPromise();

    }
    catch(err)  {
      console.log(err);
      console.log('catch error Login devuelve: ',this.ERR_TRANSMISION);
      return this.ERR_TRANSMISION;
    }; */
  
 /*  return this.http.post<Persona>(`${this.url}/users/authenticate`, { username, password })
    .pipe(map(user => {
    // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject.next(user);
        return user;
            })); */
    }

  logout(): void{
    console.log('estoy en logout');
    localStorage.removeItem('token');
    localStorage.removeItem('tipoUsuario');
    localStorage.removeItem('idUsuario');

    this.router.navigate(['/login']);
  }

  LoggedIn(): boolean{
    return !!(localStorage.getItem('token'));
  }

  getToken(){
    return localStorage.getItem('token');
  }

  recuperarPassword(email: string){
    return this.http.post<any>('/api/App/recuperarContaseña', { email });
  }
  // https://localhost:44361/api/App/recuperarContaseña
}

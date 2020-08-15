import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }


  getUserById(id: string): Observable <any>{
    return this.http.post<any>('/api/App/User/' + id, null);
  }

  actualizarDatosPersona(id: string,
                        nombre: string,
                        apellido: string,
                        fechaNac: string,
                        telefono: string,
                        correo: string){
    return this.http.put<any>('/api/App/UserUpdate/' + id, {nombre, apellido, fechaNac, telefono, correo}).
            subscribe(res => {});
  }


  getBalancePersona( id: string): Observable<any>{
    console.log( 'api/Monedero/Balance?usuarioId=' + id);
    return this.http.get<any>('api/Monedero/Balance?usuarioId=' + id);
  }
}

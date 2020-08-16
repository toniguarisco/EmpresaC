import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }


 /*  getUserById(id: string): Observable <any>{
    return this.http.post<any>('/api/App/User/' + id, null);
  } */

  actualizarDatosPersona(id: string,
                        nombre: string,
                        apellido: string,
                        fechaNac: string,
                        telefono: string,
                        correo: string){
    return this.http.put<any>('/api/App/UserUpdate/' + id, {nombre, apellido, fechaNac, telefono, correo}).
            subscribe(res => {});
  }


  getBalance( id: string): Observable<any>{
    console.log(`api/PortalWeb/Balance?usuarioId=${id}`);
    return this.http.get<any>(`api/PortalWeb/Balance?usuarioId=${id}`);

  }

  registrarCuenta(cuenta: string, banco: string, tipo: string): Observable <any> {

    var idUsuario = parseInt(localStorage.getItem('idUsuario'), 10);
    return this.http.post<any>('api/Monedero/CuentaNueva', {idUsuario, cuenta, banco, tipo});
  }

  getCuentas(id: string): Observable<any>{
    return this.http.get<any>(`api/Monedero/Cuentas?usuarioId=${id}`);
  }

  getInfoPersona(id: string): Observable<any>{
    return this.http.get<any>(`api/Monedero/InfoPersona?id=${id}`);
  }

  //https://localhost:44361/api/PortalWeb/UsuarioPorId?IdUser=0
  getUsuarioPorId(id: string): Observable<any>{
    return this.http.get<any>(`api/PortalWeb/UsuarioPorId?IdUser=${id}`);
  }

}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenInterceptorService } from './token-interceptor.service';


@Injectable({
  providedIn: 'root', 

})
export class UserService {



  constructor(private http: HttpClient) { }

  registrarPersona(usuario: string,
                  email: string,
                  contrasena: string,
                  nombre: string,
                  segundoNombre: string,
                  apelllido: string,
                  segundoApelllido: string,
                  fechaNacimiento: string,
                  telefono: string,
                  direccion: string,
                  fechaRegistro: string){

   let numIdentificacion = 0;

   return this.http.post<any>('api/App/CreatePersona', {usuario ,
                                                        fechaRegistro ,
                                                        numIdentificacion ,
                                                        email ,
                                                        telefono ,
                                                        direccion ,
                                                        nombre ,
                                                        segundoNombre ,
                                                        apelllido ,
                                                        segundoApelllido ,
                                                        fechaNacimiento ,
                                                        contrasena});
   // https://localhost:44361/api/App/CreatePersona
  }


  registrarComercio(usuario: string,
                  fechaRegistro: string,
                  email: string,
                  telefono: string,
                  direccion: string,
                  razon_social: string,
                  nombreRepresentante: string,
                  apellidoRepresentante: string,
                  contrasena: string){

   let numIdentificacion = 0;

   return this.http.post<any>('api/App/CreateComercio', {usuario ,
                                                        fechaRegistro ,
                                                        numIdentificacion ,
                                                        email ,
                                                        telefono ,
                                                        direccion ,
                                                        razon_social ,
                                                        nombreRepresentante ,
                                                        apellidoRepresentante ,
                                                        contrasena});
   // https://localhost:44361/api/App/CreatePersona
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

  getUsuarioPorId(id: string): Observable<any>{
    return this.http.get<any>(`api/PortalWeb/UsuarioPorId?IdUser=${id}`);
  }

  recargarSaldo(fecha: string, monto: string, cuenta: string){
    console.log('fecha -> ',fecha)
    var idUsuario = parseInt(localStorage.getItem('idUsuario'), 10);
    var hora: null;
    return this.http.post<any>('api/Monedero/AddSaldo', {fecha, hora , monto, idUsuario, cuenta});
    // https://localhost:44361/api/Monedero/AddSaldo
  }

}

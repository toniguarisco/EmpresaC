import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  
  getBalance( id: string): Observable<any>{
    return this.http.get<any>(`api/PortalWeb/Balance?usuarioId=405`);
  }
  // https://localhost:44361/api/PortalWeb/Balance?usuarioId=0


  getCantidadOperacion( ): Observable<any>{
    return this.http.get<any>(`api/PortalWeb/CantidadOperacion`);
  }

  // https://localhost:44361/api/PortalWeb/CantidadOperacion
/* 

  configuracionParametros(){}
  porcentajeComision(){}
  actualizarDatosUsuarios(){} //o se puede hacer por actualizar usuario de user.services

  // Reportes
  getCantidadOperaciones(){}
  getMontoRecaudadoPorComision(){}
  getOperacionesFallidas(){}
  getOperacionesDeCobroPendientes(){}
  getOperacionesDeRetiro(){} */
}

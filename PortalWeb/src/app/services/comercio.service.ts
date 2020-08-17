import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComercioService {

  constructor(private http:HttpClient) { }

  getComercioById(id: string): Observable <any>{
    return this.http.post<any>('/api/App/User/' + id, null);
  }

  actualizarDatosComercio(id: string,
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

  getCuentas(id: string): Observable<any>{
    return this.http.get<any>(`api/Monedero/Cuentas?usuarioId=${id}`);
  }

  retiroFondosCommerce(fecha: string, monto: number, cuenta: string){
    console.log('fecha -> ',fecha)
    var idUsuario = parseInt(localStorage.getItem('idUsuario'), 10);
    var hora: null;
    return this.http.post<any>('api/PortalWeb/RetiroFondosComercio', {fecha, hora , monto, idUsuario, cuenta});
  }

  }



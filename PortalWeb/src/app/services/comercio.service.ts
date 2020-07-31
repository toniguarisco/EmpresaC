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

}

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor() { }
  configuracionParametros(){}
  porcentajeComision(){}
  actualizarDatosUsuarios(){} //o se puede hacer por actualizar usuario de user.services

  // Reportes
  getCantidadOperaciones(){}
  getMontoRecaudadoPorComision(){}
  getOperacionesFallidas(){}
  getOperacionesDeCobroPendientes(){}
  getOperacionesDeRetiro(){}
}

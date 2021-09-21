import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cuenta, Movimiento } from '../const/interfaces';
import { GlobalConstantService } from '../const/_GlobalConstantService';

@Injectable({
  providedIn: 'root'
})
export class CuentaService {
  private baseUrl = '';

  constructor(
    private http: HttpClient,
    private _globaUrl: GlobalConstantService
 ) { }

 crearCuenta(cuenta: Cuenta): Observable<any>{
  let section = '/Cuenta/CrearCuenta';
  let body = JSON.stringify(cuenta);
  this.baseUrl = this._globaUrl.baseAppUrl + section;
  
  return this.http.post(this.baseUrl, body, this._globaUrl.httpOptions)
 }

 consignarCuenta(moviemiento: Movimiento):Observable<any> {
  let section = '/Cuenta/ConsignacionCuenta';
  let body = JSON.stringify(moviemiento);
  this.baseUrl = this._globaUrl.baseAppUrl + section;
  
  return this.http.post( this.baseUrl, body, this._globaUrl.httpOptions)
 }

 retirarCuenta(moviemiento: Movimiento):Observable<any> {
  let section = '/Cuenta/RetirarCuenta';
  let body = JSON.stringify(moviemiento);
  this.baseUrl = this._globaUrl.baseAppUrl + section;
  
  return this.http.post( this.baseUrl, body, this._globaUrl.httpOptions)
 }

 ListaMovimientoPorCuentaId(cuentaId: number):Observable<any> {
  let section = '/Cuenta/ListaMovimientoPorCuentaId?cuentaId='+ cuentaId;
  
  this.baseUrl = this._globaUrl.baseAppUrl + section;
  
  return this.http.get(this.baseUrl)
 }
 


}

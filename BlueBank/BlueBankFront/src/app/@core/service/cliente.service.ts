import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../const/interfaces';
import { GlobalConstantService } from '../const/_GlobalConstantService';


@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private baseUrl = '';
  constructor(private http: HttpClient,
    private _globaUrl: GlobalConstantService) { }

  
    public loginIn(Cliente:Cliente): Observable<any>{
      let section = '/Cliente/Login';
      let body = JSON.stringify(Cliente);
      this.baseUrl = this._globaUrl.baseAppUrl + section;
      
      return this.http.post( this.baseUrl, body, this._globaUrl.httpOptions)

    }

    public listarCuentasCliente(clienteId: number):Observable<any> {
      let section = '/Cliente/ListaCuentasClienteId?clienteId='+ clienteId;
      
      this.baseUrl = this._globaUrl.baseAppUrl + section;
      return this.http.get(this.baseUrl)
    }
}

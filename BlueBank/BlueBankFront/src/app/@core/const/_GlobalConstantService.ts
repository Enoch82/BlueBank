import { Injectable } from "@angular/core";
import { HttpHeaders } from '@angular/common/http';


@Injectable()
export class GlobalConstantService {
  public baseAppUrl: string = 'https://localhost:44353';
  public httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
}
import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { TipoMovimiento } from '../Interfaces/tipo-movimiento';

@Injectable({
  providedIn: 'root'
})
export class TipoMovimientoService {

  private urlApi: string= environment.endpoint + "TipoMovimiento/"

  constructor(
    private http:HttpClient
  ) { }

  listar():Observable<TipoMovimiento>{
    return this.http.get<any>(`${this.urlApi}Listar`);
  }


}

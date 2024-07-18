import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

import { Reporte } from '../Interfaces/reporte';
import { MovimientoXMes } from '../Interfaces/movimientosXMes';

@Injectable({
  providedIn: 'root'
})
export class ReporteService {

  private urlApi: string= environment.endpoint + "Reporte/";

  constructor(
    private http : HttpClient
  ) { }

  reporte(id : any):Observable<Reporte>{
    return this.http.get<any>(`${this.urlApi}Listar/${id}`);
  }
}

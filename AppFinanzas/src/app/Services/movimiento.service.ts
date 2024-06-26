import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Movimiento } from '../Interfaces/movimiento';

@Injectable({
  providedIn: 'root'
})
export class MovimientoService {

  private urlApi: string= environment.endpoint + "Movimiento/"

  constructor(
    private http:HttpClient
  ) { }

  listar(id : any):Observable<Movimiento>{
    return this.http.get<Movimiento>(`${this.urlApi}Listar/${id}`);
  }

  guardar(request:Movimiento):Observable<Movimiento>{
    return this.http.post<Movimiento>(`${this.urlApi}Crear`,request);
  }

  modificar(request:Movimiento):Observable<Movimiento>{
    return this.http.put<Movimiento>(`${this.urlApi}Modificar`,request);
  }


  Eliminar(id:any):Observable<boolean>{
  return this.http.delete<any>(`${this.urlApi}Eliminar/${id}`);
 }
}

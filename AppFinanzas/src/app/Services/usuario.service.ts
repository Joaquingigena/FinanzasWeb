import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Usuario } from '../Interfaces/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private urlApi: string= environment.endpoint + "Usuario/"

  constructor(
    private http:HttpClient
  ) { }

  listar():Observable<Usuario>{
    return this.http.get<Usuario>(`${this.urlApi}Listar`);
  }

  guardar(request:Usuario):Observable<Usuario>{
    return this.http.post<Usuario>(`${this.urlApi}Crear`,request);
  }

  modificar(request:Usuario):Observable<Usuario>{
    return this.http.put<Usuario>(`${this.urlApi}Modificar`,request);
  }

  //Habria que modificar la api
  // Eliminar(request:Movimiento):Observable<Movimiento>{
  //   return this.http.delete<Movimiento>(`${this.urlApi}Eliminar`,request);
  // }
}

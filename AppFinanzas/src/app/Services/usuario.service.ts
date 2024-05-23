import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Usuario } from '../Interfaces/usuario';
import { Login } from '../Interfaces/login';

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

  registrar(request:Usuario):Observable<Usuario>{
    return this.http.post<Usuario>(`${this.urlApi}Crear`,request);
  }

  modificar(request:Usuario):Observable<Usuario>{
    return this.http.put<Usuario>(`${this.urlApi}Modificar`,request);
  }

  loguear(request:Login):Observable<Usuario>{
    return this.http.post<Usuario>(`${this.urlApi}Loguear`,request);
  }
  //Habria que modificar la api
  // Eliminar(request:Movimiento):Observable<Movimiento>{
  //   return this.http.delete<Movimiento>(`${this.urlApi}Eliminar`,request);
  // }
}

import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Categoria } from '../Interfaces/categoria';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  private urlApi: string= environment.endpoint + "Categoria/"

  constructor(
    private http:HttpClient
  ) { }

  listar():Observable<Categoria>{
    return this.http.get<any>(`${this.urlApi}Listar`);
  }

  guardar(request:Categoria):Observable<Categoria>{
    return this.http.post<any>(`${this.urlApi}Agregar`,request);
  }
}

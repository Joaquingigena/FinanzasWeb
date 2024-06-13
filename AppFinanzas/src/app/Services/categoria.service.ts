import { Injectable } from '@angular/core';

import {HttpClient,HttpResponse} from '@angular/common/http'
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

  listar(id : any):Observable<Categoria>{
    return this.http.get<Categoria>(`${this.urlApi}Listar/${id}`);
  }

  guardar(request: Categoria): Observable<HttpResponse<Categoria>> {
    return this.http.post<Categoria>(`${this.urlApi}Agregar`, request, { observe: 'response' });
  }


  eliminar(id: any):Observable<any>{
    return this.http.delete<any>(`${this.urlApi}Eliminar/${id}`);
  }
}

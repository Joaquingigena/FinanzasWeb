import { Injectable } from '@angular/core';

import { MatSnackBar } from '@angular/material/snack-bar';
import { Usuario } from '../Interfaces/usuario';

@Injectable({
  providedIn: 'root'
})
export class UtilidadService {

  constructor(private _snackBar: MatSnackBar) { }

  mostrarAlerta(mensaje: string, tipo: string){

    this._snackBar.open	(mensaje,tipo,{
      verticalPosition:"top",
      horizontalPosition: "end",
      duration:3000
    })
  }

  guardarUsuario(usuario:Usuario){
    localStorage.setItem("usuario",JSON.stringify(usuario));
  }

  obtenerUsuario(){

    const dataCadena= localStorage.getItem("usuario");

    const usuario= JSON.parse(dataCadena!);

    return usuario;
  }

  eliminarSesionUsuario(){
    localStorage.removeItem("usuario");
  }
}

import { Component } from '@angular/core';

import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { UsuarioService } from 'src/app/Services/usuario.service';
import { Usuario } from 'src/app/Interfaces/usuario';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {

  formularioRegistro: FormGroup;
  ocultarContrasena:boolean=true;

  constructor(
    private fb: FormBuilder,
    private _usuarioService: UsuarioService
  ){
    this.formularioRegistro= fb.group({
      nombre:["",Validators.required],
      apellido:["",Validators.required],
      email:["",Validators.required],
      clave:["",Validators.required,Validators.minLength(6)]
    });
  }

  registrar(){

    const usuario: Usuario= {
      id: 0,
      nombre: this.formularioRegistro.value.nombre,
      apellido: this.formularioRegistro.value.apellido,
      email: this.formularioRegistro.value.email,
      clave: this.formularioRegistro.value.clave
    }

    this._usuarioService.registrar(usuario).subscribe({
      next:(data)=>{
        console.log("usuario creado exitosamente:" + data);
      },
      error:(e)=>{}
    });
  }
}

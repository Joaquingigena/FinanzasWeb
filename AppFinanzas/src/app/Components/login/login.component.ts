import { Component,OnDestroy } from '@angular/core';

import { Form, FormBuilder,FormGroup,Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { UsuarioService } from 'src/app/Services/usuario.service';
import { Login } from 'src/app/Interfaces/login';
import { Observable } from 'rxjs';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';
import { HttpResponse } from '@angular/common/http';
import { Usuario } from 'src/app/Interfaces/usuario';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {

  formularioLogin: FormGroup;
  ocultarContrasena: boolean=true;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private _usuarioService: UsuarioService,
    private _utilidadService: UtilidadService
  ){
    this.formularioLogin= fb.group({
      correo: ["",Validators.required],
      clave: ["",Validators.required]
    });
  }

  iniciarSesion(){

    console.log("lala");
    const login: Login = {
      
      correo: this.formularioLogin.value.correo,
      clave: this.formularioLogin.value.clave
    }

    this._usuarioService.loguear(login).subscribe({
      next:(data : any)=>{
        console.log("Aca llego")
        if(data ){
          console.log(data.body)
          this._utilidadService.guardarUsuario(data);
          this.router.navigate(["pages"]);
        }
      },
      error:(e)=>{
        console.log(e);

        if(e.error){
          this._utilidadService.mostrarAlerta(e.error,"Oops");
        }else{
          var error= "Error";
          this._utilidadService.mostrarAlerta(error,"Error inesperado");
        }
      }
    });
  }

 
}

import { Component } from '@angular/core';

import { Form, FormBuilder,FormGroup,Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { UsuarioService } from 'src/app/Services/usuario.service';
import { Login } from 'src/app/Interfaces/login';
import { Observable } from 'rxjs';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

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

    const login: Login = {
      
      correo: this.formularioLogin.value.correo,
      clave: this.formularioLogin.value.clave
    }

    console.log(login);
    this._usuarioService.loguear(login).subscribe({
      next:(data)=>{
          console.log(data);
          this._utilidadService.guardarUsuario(data);
          this.router.navigate(["pages"]);
      },
      error:(e)=>{
        console.log(e);
      }
    });
  }
}

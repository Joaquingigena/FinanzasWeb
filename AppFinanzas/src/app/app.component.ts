import { Component } from '@angular/core';
import { CategoriaService } from './Services/categoria.service';
import { Categoria } from './Interfaces/categoria';
import { Login } from './Interfaces/login';
import { UsuarioService } from './Services/usuario.service';
import { Usuario } from './Interfaces/usuario';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  //categorias: Categoria[];
  title = 'AppFinanzas';
  //cat: Categoria;
  //login: Login;

  constructor(
    _categoriaService: CategoriaService,
    _usuarioService: UsuarioService
  ){
    // this.login= {
    //   correo: "lalala",
    //   clave: "lala"
    // }

    // _usuarioService.loguear(this.login).subscribe({
    //   next:(data: Usuario)=>{
    //     console.log(data);
    //   },
    //   error:(e)=>{}
    // })

  }

  
    //Funcionan estas pruebas
  //   this.cat={
  //     id:0,
  //     nombre:"Cliente",
  //     tipoMovimientoId:1
  //   }

  //   _categoriaService.guardar(this.cat).subscribe({
  //     next:(data)=>{

  //       console.log(data);
  //     },
  //     error:(e)=>{
  //       console.log("Hubo un error")
  //     }
  //   })

  //   _categoriaService.listar().subscribe({
  //     next:(data)=>{
  //       console.log(data);
  //     },
  //     error:(e)=>{
  //       console.log(e);
  //     }
  //   })
  // }
}

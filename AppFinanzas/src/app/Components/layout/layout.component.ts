import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/Interfaces/usuario';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent  {

  usuario: Usuario;

  constructor(
    private _utilidadService: UtilidadService,
    private router: Router
  ){

    this.usuario= _utilidadService.obtenerUsuario();
  }


  
cerrarSesion(){
  this._utilidadService.eliminarSesionUsuario();
  this.router.navigate(['login']);
}
}

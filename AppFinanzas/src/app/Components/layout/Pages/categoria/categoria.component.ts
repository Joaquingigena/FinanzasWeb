import { Component,OnInit,AfterViewInit,ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { Usuario } from 'src/app/Interfaces/usuario';
import { Categoria } from 'src/app/Interfaces/categoria';
import { CategoriaService } from 'src/app/Services/categoria.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';
import Swal from 'sweetalert2';

import { FormBuilder,FormGroup,Validator, Validators } from '@angular/forms';

import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {

  usuario :Usuario;
  columnaTabla: string[] = ["Nombre","Tipo","Acciones"];
  dataInicio: Categoria[]=[];
  dataListaCategorias= new MatTableDataSource(this.dataInicio);
  @ViewChild(MatPaginator) paginacionTabla!:MatPaginator;
  formVisible:boolean=false;
  formularioCat:FormGroup

  constructor(
    private _categoriaService:CategoriaService,
    private _utilidadService: UtilidadService,
    private fb: FormBuilder
  ){
    this.usuario= _utilidadService.obtenerUsuario();

    this.formularioCat= fb.group({
      nombre: ["",Validators.required],
      tipoMovimientoId: ["",Validators.required]
    });
  }
  cambiarVisibilidad(){
    this.formVisible= !this.formVisible;
  }

  obtenerCategorias(){
    this._categoriaService.listar(this.usuario.id).subscribe({
      next: (data:any)=>{
        if(data != null){
          console.log(data);
          this.dataListaCategorias.data= data;

        }
        else{
          this._utilidadService.mostrarAlerta("No se encontraron categorias","Oops");
        }
      },
      error: (e)=>{}
    });
  }
  ngOnInit(): void {
    this.obtenerCategorias();
  }

  agregarCategoria(){
    

    const categoria: Categoria={
      nombre: this.formularioCat.value.nombre,
      tipoMovimientoId: this.formularioCat.value.tipoMovimientoId,
      usuarioId: this.usuario.id
    }

    this._categoriaService.guardar(categoria).subscribe({
      next:(response: HttpResponse<Categoria>)=>{
        console.log("status "+ response.status);
        if(response.status === 200){
          this.obtenerCategorias();
          this._utilidadService.mostrarAlerta("Categoria agregada exitosamente","Exito");
        }
        else{
          this._utilidadService.mostrarAlerta("No se puedo agregar la categoria","Oops")
        }
      },
      error: (e)=>{}
    });
  }
}

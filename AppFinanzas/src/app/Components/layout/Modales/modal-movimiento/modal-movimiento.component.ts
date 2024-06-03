import { Component,Inject,OnInit, inject } from '@angular/core';

import { FormBuilder,FormGroup,Validator, Validators } from '@angular/forms';
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Categoria } from 'src/app/Interfaces/categoria';
import { CategoriaService } from 'src/app/Services/categoria.service';
import { TipoMovimiento } from 'src/app/Interfaces/tipo-movimiento';
import { TipoMovimientoService } from 'src/app/Services/tipo-movimiento.service';
import { Movimiento } from 'src/app/Interfaces/movimiento';
import { MovimientoService } from 'src/app/Services/movimiento.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';

@Component({
  selector: 'app-modal-movimiento',
  templateUrl: './modal-movimiento.component.html',
  styleUrls: ['./modal-movimiento.component.css']
})
export class ModalMovimientoComponent {

  formularioMovimiento: FormGroup;
  tituloAccion: string= "Agregar";
  botonAccion: string = "Guardar";
  listaCategorias: Categoria[]= [];
  listaTipos: TipoMovimiento[]=[];

  constructor(
    private  modalActual: MatDialogRef<ModalMovimientoComponent>,
    @Inject(MAT_DIALOG_DATA) public datosMovimiento: Movimiento,
    private _categoriaService: CategoriaService,
    private _tipoMovService: TipoMovimientoService,
    private _movimientoService: MovimientoService,
    private _utilidadService: UtilidadService,
    private fb: FormBuilder
  ){
    this.formularioMovimiento=fb.group({
       idTipoMovimiento: ["",Validators.required],
       idCategoria: ["",Validators.required],
       descripcion:["",Validators.required],
       monto: ["",Validators.required],
       fecha:["",Validators.required]
    });

    //Si viene con datos se actualiza
    if(datosMovimiento!=null){
      this.tituloAccion="Editar";
      this.botonAccion="Actualizar";
    }

    _categoriaService.listar().subscribe({
      next:(data:any) =>{
          this.listaCategorias=data;
      },
      error: (e)=>{}
    })

    _tipoMovService.listar().subscribe({
      next:(data:any) =>{
          this.listaTipos=data;
      },
      error: (e)=>{}
    })

  }

 //Me quede aca

}

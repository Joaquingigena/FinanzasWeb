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
export class ModalMovimientoComponent implements OnInit {

  formularioMovimiento: FormGroup;
  tituloAccion: string= "Agregar";
  botonAccion: string = "Guardar";
  listaCategorias: Categoria[]= [];
  filtroListaCategorias: Categoria[]=[];
  listaTipos: TipoMovimiento[]=[];

  constructor(
    private  modalActual: MatDialogRef<ModalMovimientoComponent>,
    @Inject(MAT_DIALOG_DATA) public datosMovimiento: any,
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
       monto: ["",[Validators.required,Validators.pattern('^[0-9]*$')]],
       fecha:["",Validators.required]
    });

    //console.log(datosMovimiento.data.movimiento);
    console.log("id del usuario "+datosMovimiento.id);
    console.log("Movimiento "+datosMovimiento.movimiento);
   // console.log("categoria del mov " + datosMovimiento.movimiento.descripcionCategoria)
    //Si viene con datos se actualiza
    if(datosMovimiento.movimiento!=null){
      this.tituloAccion="Editar";
      this.botonAccion="Actualizar";
    }

    _categoriaService.listar(datosMovimiento.id).subscribe({
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

ngOnInit(): void {
  if(this.datosMovimiento.movimiento){
  this.formularioMovimiento.patchValue({
    idTipoMovimiento: this.datosMovimiento.movimiento.tipoMovimientoId,
    idCategoria: this.datosMovimiento.movimiento.categoriaId,
    descripcion: this.datosMovimiento.movimiento.descripcion,
    monto: this.datosMovimiento.movimiento.monto,
    fecha: new Date(this.datosMovimiento.movimiento.fecha)
  });
 
}

this.formularioMovimiento.get("idTipoMovimiento")?.valueChanges.subscribe(
  tipoIdSeleccionado => {
    this.filtroListaCategorias = this.listaCategorias.filter(cat => cat.tipoMovimientoId === tipoIdSeleccionado);
    this.formularioMovimiento.get("idCategoria")?.setValue("");
  }
)
}


guardarEditarMovimiento(){

  const movimiento: Movimiento= {
    id: this.datosMovimiento.movimiento== null? 0: this.datosMovimiento.movimiento.id,
    usuarioId: this.datosMovimiento.id,
    tipoMovimientoId: this.formularioMovimiento.value.idTipoMovimiento,
    categoriaId: this.formularioMovimiento.value.idCategoria,
    descripcion: this.formularioMovimiento.value.descripcion,
    monto: this.formularioMovimiento.value.monto,
    fecha: this.formularioMovimiento.value.fecha
  }

  console.log("Este es el movimiento " + movimiento);
  console.log(movimiento);
  if(movimiento.id === 0){

    console.log("Nuevo movimiento");
    this._movimientoService.guardar(movimiento).subscribe({
      next:(data)=>{
        if(data !=null){
          this._utilidadService.mostrarAlerta("Movimiento agrego exitosamente","Exito");
          this.modalActual.close("true");
        }
        else{
          this._utilidadService.mostrarAlerta("No se pudo agregar el movimiento","Error");
        }
      },
      error:(e)=>{console.log(e)}
    });
  }
  else{
    console.log("Editar movimiento");
    this._movimientoService.modificar(movimiento).subscribe({
      next:(data)=>{
        if(data !=null){
          this._utilidadService.mostrarAlerta("Movimiento modificado exitosamente","Exito");
          this.modalActual.close("true");
        }
        else{
          this._utilidadService.mostrarAlerta("No se pudo editar el movimiento","Error");
        }
      },
      error:(e)=>{console.log(e)}
    });
  }

}
}

import { Component,OnInit,AfterViewInit,ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { Movimiento } from 'src/app/Interfaces/movimiento';
import { MovimientoService } from 'src/app/Services/movimiento.service';
import Swal from 'sweetalert2';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';
import { Usuario } from 'src/app/Interfaces/usuario';
import { ModalMovimientoComponent } from '../../Modales/modal-movimiento/modal-movimiento.component';

@Component({
  selector: 'app-movimiento',
  templateUrl: './movimiento.component.html',
  styleUrls: ['./movimiento.component.css']
})
export class MovimientoComponent implements OnInit {

  usuario :Usuario;
  columnaTabla: string[] = ["Fecha","Tipo","Categoria","Descripcion","Monto"];
  dataInicio: Movimiento[]=[];
  dataListaMovimientos= new MatTableDataSource(this.dataInicio);
  @ViewChild(MatPaginator) paginacionTabla!:MatPaginator;


  constructor(
    private dialog:MatDialog,
    private _movimientoService: MovimientoService,
    private _utilidadService: UtilidadService
  ){
    this.usuario= _utilidadService.obtenerUsuario();
  }

  obtenerMovimientos(){
    this._movimientoService.listar(this.usuario.id).subscribe({
      next: (movimientos:any)=>{
        if(movimientos != null){
          this.dataListaMovimientos.data= movimientos;
          console.log(movimientos);
        }
        else{
          
          this._utilidadService.mostrarAlerta("No se encontraron movimientos","Oops");
        }
      },
      error:(e) =>{
        console.log(e);
      }
    });
  }

  ngOnInit(): void {
    this.obtenerMovimientos();
  }

  // ngAfterViewInit(): void {
  //   this.dataListaProductos.paginator= this.paginacionTabla;
  // }

  // aplicarFiltroTabla(event:Event){

  //   const filtroValue= (event.target as HTMLInputElement).value;
  
  //   this.dataListaProductos.filter= filtroValue.trim().toLocaleLowerCase();
  
  // }

  nuevoProducto(){
    var id= this.usuario.id;
    this.dialog.open(ModalMovimientoComponent,{
      disableClose: true,
      data: id
    }).afterClosed().subscribe(resultado =>{
      if(resultado === "true") this.obtenerMovimientos();
    });
  }

  editarProducto(movimiento:Movimiento){
    
    var id= this.usuario.id;
    this.dialog.open(ModalMovimientoComponent,{
      disableClose: true,
      data: {movimiento,id}
    }).afterClosed().subscribe(resultado =>{
      if(resultado === "true") this.obtenerMovimientos();
    });
  }
}




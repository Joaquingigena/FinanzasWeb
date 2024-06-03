import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { MovimientoComponent } from './Pages/movimiento/movimiento.component';
import { CategoriaComponent } from './Pages/categoria/categoria.component';
import { InformesComponent } from './Pages/informes/informes.component';
import { SharedModule } from 'src/app/Reutilizable/shared/shared.module';
import { ModalMovimientoComponent } from './Modales/modal-movimiento/modal-movimiento.component';


@NgModule({
  declarations: [
    MovimientoComponent,
    CategoriaComponent,
    InformesComponent,
    ModalMovimientoComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    SharedModule
  ]
})
export class LayoutModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovimientoComponent } from './Pages/movimiento/movimiento.component';
import { CategoriaComponent } from './Pages/categoria/categoria.component';
import { InformesComponent } from './Pages/informes/informes.component';
import { LayoutComponent } from './layout.component';

const routes: Routes = [{
  path:"",
  component: LayoutComponent,
  children:[
    {path:"movimiento",component:MovimientoComponent},
    {path:"categoria",component:CategoriaComponent},
    {path:"informes",component:InformesComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }

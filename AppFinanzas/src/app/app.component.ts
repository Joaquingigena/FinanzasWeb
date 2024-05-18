import { Component } from '@angular/core';
import { CategoriaService } from './Services/categoria.service';
import { Categoria } from './Interfaces/categoria';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  //categorias: Categoria[];
  title = 'AppFinanzas';

  constructor(
    _categoriaService: CategoriaService
  ){
    _categoriaService.listar().subscribe({
      next:(data)=>{
        console.log(data);
      },
      error:(e)=>{
        console.log(e);
      }
    })
  }
}

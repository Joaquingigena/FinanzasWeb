import { Component,OnInit,AfterViewInit,ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { Movimiento } from 'src/app/Interfaces/movimiento';
import { MovimientoService } from 'src/app/Services/movimiento.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-movimiento',
  templateUrl: './movimiento.component.html',
  styleUrls: ['./movimiento.component.css']
})
export class MovimientoComponent {

  columbaTabla: string[] = [""];

}

import { Component,OnInit } from '@angular/core';

import { Chart,registerables } from 'chart.js';
import { Reporte } from 'src/app/Interfaces/reporte';
import { Usuario } from 'src/app/Interfaces/usuario';
import { ReporteService } from 'src/app/Services/reporte.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';

Chart.register(...registerables);

@Component({
  selector: 'app-informes',
  templateUrl: './informes.component.html',
  styleUrls: ['./informes.component.css']
})
export class InformesComponent implements OnInit {
  
  private labell: string[]=[];
  private ingresos: any[]=[];
  private egresos: any[]=[];
  private balanceMensual: any[]=[];
  
  private categoriasIng: any[]=[];
  private categoriasEgr: any[]=[];
  private montoIng: any[]=[];
  private montoEgre: any[]=[];
  
  reporte? : Reporte;
  usuario: Usuario;

  constructor(
    private _reporteService: ReporteService,
    private utilidadService: UtilidadService
  ) {

    this.usuario= utilidadService.obtenerUsuario();

  }
  
  ngOnInit(): void {
    this._reporteService.reporte(this.usuario.id).subscribe({
      next:(data)=>{
        this.reporte= data;

        console.log(this.reporte);
        if(this.reporte && this.reporte.movimientosXMes){

        this.reporte.movimientosXMes.forEach((movimiento)=>{
          this.labell.push( this.nombreMes(movimiento.mes)),
          this.ingresos.push(movimiento.ingresos);
          this.egresos.push(movimiento.egresos);
          this.balanceMensual.push(movimiento.balanceMensual)
        });

        this.reporte.categoriasXMovimientos.forEach((categoria)=>{
          if(categoria.ingresos !="0"){
            this.montoIng.push(parseInt( categoria.ingresos));
            this.categoriasIng.push(categoria.nombre);
          }
          else{
            this.montoEgre.push(parseInt( categoria.egresos));
            this.categoriasEgr.push(categoria.nombre);
          }
        })
        
        this.renderizarGraficos();
      }
        else{
          console.log("movimientoxMes es undefined");
        }

      },
      error:(e)=>{}
    });

  }

  nombreMes(mes:number):string{
    var meses= ["Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"];

    return meses[mes-1];
  }
  renderizarGraficos(){
    const BarChart = new Chart("chart", {
      type: 'bar', // Gráfico de barras para ingresos y egresos
      data: {
        labels: this.labell,
        datasets: [
          {
            label: "Ingresos",
            data: this.ingresos,
            backgroundColor: "rgba(75, 192, 192, 0.2)",
            borderColor: "rgba(75, 192, 192, 1)",
            borderWidth: 1
          },
          {
            label: "Egresos",
            data: this.egresos,
            backgroundColor: "rgba(255, 99, 132, 0.2)",
            borderColor: "rgba(255, 99, 132, 1)",
            borderWidth: 1
          },
           {
             label: "Balance",
             type: 'line',
             data: this.balanceMensual,
             borderColor: "rgba(153, 102, 255, 1)",
             fill: false,
             tension: 0.01
           }
        ]
      },
      options: {
        maintainAspectRatio: false,
        responsive: true,
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });


    const chart = new Chart("categoriasChart", {
      type: 'doughnut',
      data: {
        labels: this.categoriasIng,
        datasets: [{
          data: this.montoIng,
          backgroundColor: [
            "rgba(75, 192, 192, 0.2)",
            "rgba(255, 206, 86, 0.2)",
            "rgba(54, 162, 235, 0.2)",
            "rgba(255, 99, 132, 0.2)",
          ],
          borderColor: [
            "rgba(75, 192, 192, 1)",
            "rgba(255, 206, 86, 1)",
            "rgba(54, 162, 235, 1)",
            "rgba(255, 99, 132, 1)"           
          ],
          borderWidth: 1
        }]
      },
      options: {
        maintainAspectRatio: false,
        responsive: true
      }
    });

    const chartGastos = new Chart("categoriasGastosChart", {
      type: 'doughnut',
      data: {
        labels: this.categoriasEgr,
        datasets: [{
          data: this.montoEgre,
          backgroundColor: [
            "rgba(255, 99, 132, 0.2)",
            "rgba(54, 162, 235, 0.2)",
            "rgba(255, 206, 86, 0.2)",
            "rgba(75, 192, 192, 0.2)"
          ],
          borderColor: [
            "rgba(255, 99, 132, 1)",
            "rgba(54, 162, 235, 1)",
            "rgba(255, 206, 86, 1)",
            "rgba(75, 192, 192, 1)"
          ],
          borderWidth: 1
        }]
      },
      options: {
        maintainAspectRatio: false,
        responsive: true
      }
    });
  
  }
  }

  



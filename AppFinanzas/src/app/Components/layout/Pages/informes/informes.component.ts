import { Component,OnInit } from '@angular/core';

import { Chart,registerables } from 'chart.js';

Chart.register(...registerables);

@Component({
  selector: 'app-informes',
  templateUrl: './informes.component.html',
  styleUrls: ['./informes.component.css']
})
export class InformesComponent implements OnInit {
  
  private labell: any[];
  private ingresos: any[];
  private egresos: any[];
  private balance: any[];
  private categorias: any[];
  private gastos: any[];
  
  constructor() {
    this.labell = ["Julio", "Agosto", "Septiembre", "Octubre"];
    this.ingresos = [5000, 6000, 7000, 8000];
    this.egresos = [2000, 2500, 3000, 3500];
    this.balance = this.ingresos.map((ingreso, index) => ingreso - this.egresos[index]);

    this.categorias = ["Alimentación", "Transporte", "Entretenimiento", "Salud"];
    this.gastos = [500, 300, 200, 100];
  }
  
  ngOnInit(): void {
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
            data: this.balance,
            borderColor: "rgba(153, 102, 255, 1)",
            fill: false,
            tension: 0.1
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
        labels: this.categorias,
        datasets: [{
          data: this.gastos,
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

  



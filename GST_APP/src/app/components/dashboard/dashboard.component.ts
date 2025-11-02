import { Component } from '@angular/core';
import { ChartConfiguration } from 'chart.js';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
metrics = {
    orders: 150,
    bounceRate: '53%',
    registrations: 44,
    visitors: 65
  };

  // Doughnut Chart
  doughnutChartData: ChartConfiguration<'doughnut'>['data'] = {
    labels: ['GSTR1A', 'GSTR3B', 'GSTR9C'],
    datasets: [{
      data: [45, 25, 30],
      backgroundColor: ['#2196f3', '#4caf50', '#ff9800']
    }]
  };

  doughnutChartOptions: ChartConfiguration<'doughnut'>['options'] = {
    responsive: true,
    plugins: {
      legend: { position: 'bottom' }
    }
  };

  // Bar Chart
  barChartData: ChartConfiguration<'bar'>['data'] = {
    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
    datasets: [
      {
        label: 'GSTR1A',
        data: [65, 59, 80, 81, 56, 55, 40],
        backgroundColor: '#2196f3'
      },
      {
        label: 'GSTR3B',
        data: [28, 48, 40, 19, 86, 27, 90],
        backgroundColor: '#4caf50'
      },
      {
        label: 'GSTR9C',
        data: [18, 38, 30, 29, 76, 37, 60],
        backgroundColor: '#ff9800'
      }
    ]
  };

  barChartOptions: ChartConfiguration<'bar'>['options'] = {
    responsive: true,
    plugins: {
      legend: { position: 'top' }
    }
  };
}

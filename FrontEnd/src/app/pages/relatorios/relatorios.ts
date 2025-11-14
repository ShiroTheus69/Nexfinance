import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PoChartModule, PoChartSerie, PoChartType } from '@po-ui/ng-components';

@Component({
  selector: 'app-relatorios',
  standalone: true,
  imports: [CommonModule, PoChartModule],
  templateUrl: './relatorios.html',
  styleUrls: ['./relatorios.css']
})
export class RelatoriosComponent {

  lastUpdate = new Date();

  categories = ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'];

  

  series: PoChartSerie[] = [
    { label: 'Receitas', data: [1200, 1500, 900, 1800, 2200, 2000] },
    { label: 'Despesas', data: [800, 1100, 700, 1200, 1500, 1300] }
  ];

   


}

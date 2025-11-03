import { Component } from '@angular/core';
import { PoPageModule, PoWidgetModule, PoInfoModule } from '@po-ui/ng-components';

@Component({
  selector: 'app-dashboard',
  imports: [
    PoPageModule,
    PoWidgetModule,
    PoInfoModule
  ],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class DashboardComponent {
  title = 'Dashboard Financeiro';
}

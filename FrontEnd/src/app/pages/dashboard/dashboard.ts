import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { PoModule, PoWidgetModule } from '@po-ui/ng-components';
import { DashboardService } from '../../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  standalone: true, 
  imports: [
    CommonModule,      
    PoWidgetModule,    
    PoModule        
  ],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css']
})
export class DashboardComponent implements OnInit {
  saldoTotal = 0;
  receitasMes = 0;
  despesasMes = 0;
  ultimasTransacoes: any[] = [];

  constructor(private dashboardService: DashboardService) {}

  ngOnInit(): void {
    this.carregarDashboard();
  }

  carregarDashboard(): void {
    this.dashboardService.getResumoGeral().subscribe({
      next: (data) => {
        this.saldoTotal = data.saldo;
        this.receitasMes = data.receitas;
        this.despesasMes = data.despesas;
        this.ultimasTransacoes = data.transacoes;
      },
      error: (err) => console.error('Erro ao carregar o dashboard', err)
    });
  }
}

import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard';
import { ReceitasComponent } from './pages/receitas/receitas';
import { DespesasComponent } from './pages/despesas/despesas';
import { InvestimentosComponent } from './pages/investimentos/investimentos';
import { RelatoriosComponent } from './pages/relatorios/relatorios';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'receitas', component: ReceitasComponent },
  { path: 'despesas', component: DespesasComponent },
  { path: 'investimentos', component: InvestimentosComponent },
  { path: 'relatorios', component: RelatoriosComponent }
];

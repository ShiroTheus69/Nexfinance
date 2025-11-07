import { Routes } from '@angular/router';
import { LoginComponent } from './login/login';
import { CadastroComponent } from './cadastro/cadastro';
import { DashboardComponent } from './pages/dashboard/dashboard';
import { ReceitasComponent } from './pages/receitas/receitas';
import { DespesasComponent } from './pages/despesas/despesas';
import { InvestimentosComponent } from './pages/investimentos/investimentos';
import { RelatoriosComponent } from './pages/relatorios/relatorios';

export const routes: Routes = [

  { path: 'login', component: LoginComponent },
  { path: 'cadastro', component: CadastroComponent },

  { path: '', redirectTo: '/login', pathMatch: 'full' },

  { path: 'dashboard', component: DashboardComponent },
  { path: 'receitas', component: ReceitasComponent },
  { path: 'despesas', component: DespesasComponent },
  { path: 'investimentos', component: InvestimentosComponent },
  { path: 'relatorios', component: RelatoriosComponent },

  { path: '**', redirectTo: '/login' }
];
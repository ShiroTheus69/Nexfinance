import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, forkJoin } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  private apiUrl = 'https://localhost:5001/api';

  constructor(private http: HttpClient) {}

  // Receitas do mês
  getReceitasMes(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/Lancamento/ReceitasMes`);
  }

  // Despesas do mês
  getDespesasMes(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/Lancamento/DespesasMes`);
  }

  // Saldo total
  getSaldoTotal(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/Conta/SaldoTotal`);
  }

  // Últimas transações
  getUltimasTransacoes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Lancamento/Ultimos`);
  }

  // Requisição combinada (opcional)
  getResumoGeral() {
    return forkJoin({
      saldo: this.getSaldoTotal(),
      receitas: this.getReceitasMes(),
      despesas: this.getDespesasMes(),
      transacoes: this.getUltimasTransacoes()
    });
  }
}

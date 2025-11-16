import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DespesasService {
  private apiUrl = 'https://localhost:5001/api';

  constructor(private http: HttpClient) {}

  listar(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/lancamento`);
  }

  criar(despesa: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/lancamento`, {
      usuarioId: 1, 
      categoriaId: despesa.categoriaId,
      contaId: 1, 
      tipo: 'Despesa',
      valor: despesa.valor,
      data: despesa.data,
      descricao: despesa.descricao
    });
  }

  listarCategorias(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/categoria`);
  }
}

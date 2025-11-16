import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedResult, LancamentoDto, CategoriaDto, ContaDto, CreateLancamentoDto } from './receitas';

@Injectable({ providedIn: 'root' })
export class ReceitasService {
  private baseUrl = 'http://localhost:3000';

  constructor(private http: HttpClient) {}

  /** Lista todas as contas do usuário */
  listContas(usuarioId: number): Observable<ContaDto[]> {
    return this.http.get<ContaDto[]>(`${this.baseUrl}/contas?usuarioId=${usuarioId}`);
  }

  /** Lista categorias do tipo 'Receita' */
  listCategoriasReceita(): Observable<CategoriaDto[]> {
    return this.http.get<CategoriaDto[]>(`${this.baseUrl}/categorias?tipo=Receita`);
  }

  /** Lista receitas com paginação */
  listReceitas(usuarioId: number, page: number, pageSize: number): Observable<PagedResult<LancamentoDto>> {
    return this.http.get<PagedResult<LancamentoDto>>(
      `${this.baseUrl}/receitas?usuarioId=${usuarioId}&page=${page}&pageSize=${pageSize}`
    );
  }

  /** Cria uma nova receita */
  criarReceita(dto: CreateLancamentoDto): Observable<any> {
    return this.http.post(`${this.baseUrl}/receitas`, dto);
  }
}

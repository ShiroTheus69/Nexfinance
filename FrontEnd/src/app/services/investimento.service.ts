import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvestimentosService {

  private apiUrl = 'http://localhost:5000/api/investimentos'; // Ajuste conforme seu backend

  constructor(private http: HttpClient) {}

  create(invest: any): Observable<any> {
    return this.http.post(this.apiUrl, invest);
  }

  list(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}

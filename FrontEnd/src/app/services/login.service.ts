import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'http://localhost:5163/api/usuarios/login'; // URL da sua API

  constructor(private http: HttpClient) {}

  login(cpf: string, senha: string): Observable<any> {
    return this.http.post(this.apiUrl, { cpf, senha }).pipe(
      tap((response: any) => {
        // Supondo que a API retorna um token
        if (response?.token) {
          localStorage.setItem('token', response.token);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
  }

  isLogged(): boolean {
    return !!localStorage.getItem('token');
  }
}

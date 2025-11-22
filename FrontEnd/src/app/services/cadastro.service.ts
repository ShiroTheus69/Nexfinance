import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface UsuarioCadastro {
  nome: string;
  cpf: string;
  email: string;
  senhaPlain: string; // conforme o Swagger
  idade: number;
}

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

  private apiUrl = 'https://localhost:5163/api/usuarios'; // seu endpoint

  constructor(private http: HttpClient) { }

  cadastrar(usuario: UsuarioCadastro): Observable<any> {
    return this.http.post(this.apiUrl, usuario);
  }

}

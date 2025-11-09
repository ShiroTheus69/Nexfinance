import { Component } from '@angular/core';
import { PoPageModule, PoButtonModule, PoFieldModule } from '@po-ui/ng-components';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [
    PoPageModule,
    PoButtonModule,
    PoFieldModule,
    RouterLink,
    FormsModule
  ],
  templateUrl: './cadastro.html',
  styleUrl: './cadastro.css'
})
export class CadastroComponent {
  nome: string = '';
  email: string = '';
  senha: string = '';
  cpf: string = '';
  confirmarSenha: string = '';

  cadastrar() {
    if (this.senha !== this.confirmarSenha) {
      alert('As senhas não conferem.');
      return;
    }
    const formData = {
      nome: this.nome,
      email: this.email,
      cpf: this.cpf,
      senha: this.senha
    };
    console.log('Dados de Cadastro:', formData);
    // Aqui será implementada a lógica de cadastro com o backend
    alert('Cadastro simulado. Implementar lógica de cadastro.');
  }
}
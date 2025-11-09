import { Component } from '@angular/core';
import { PoButtonModule, PoFieldModule } from '@po-ui/ng-components';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    PoButtonModule,
    PoFieldModule,
    FormsModule,
    RouterLink
  ],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {
  cpf: string = '';
  senha: string = '';
  lembrar: boolean = false;

  login() {
    const dadosLogin = {
      cpf: this.cpf,
      senha: this.senha,
      lembrar: this.lembrar
    };

    console.log('Dados de Login:', dadosLogin);
    alert('Login simulado. Implementar lógica de autenticação.');
  }
}

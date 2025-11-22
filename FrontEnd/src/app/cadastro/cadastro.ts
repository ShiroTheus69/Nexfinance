import { Component } from '@angular/core';
import { PoPageModule, PoButtonModule, PoFieldModule } from '@po-ui/ng-components';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CadastroService } from '../services/cadastro.service';

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

  nome = '';
  email = '';
  senha = '';
  cpf = '';
  confirmarSenha = '';

  constructor(
    private cadastroService: CadastroService,
    private router: Router
  ) {}

  cadastrar() {
    if (this.senha !== this.confirmarSenha) {
      alert('As senhas não conferem.');
      return;
    }

    const novoUsuario = {
      nome: this.nome,
      cpf: this.cpf,
      email: this.email,
      senhaPlain: this.senha,
      idade: 18
    };

    this.cadastroService.cadastrar(novoUsuario).subscribe({
      next: (res) => {
        alert('Usuário cadastrado com sucesso!');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error(err);
        alert('Erro ao cadastrar usuário.');
      }
    });
  }
}

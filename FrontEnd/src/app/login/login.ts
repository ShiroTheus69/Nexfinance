import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PoFieldModule, PoButtonModule, PoSwitchModule, PoNotificationService } from '@po-ui/ng-components';
import { AuthService } from '../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
    RouterModule,
    PoFieldModule,
    PoButtonModule,
    PoSwitchModule
  ],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class LoginComponent {

  cpf = '';
  senha = '';
  lembrar = false;

  constructor(
    private auth: AuthService,
    private notify: PoNotificationService,
    private router: Router
  ) {}

  login() {
    if (!this.cpf || !this.senha) {
      this.notify.warning('Preencha todos os campos!');
      return;
    }

    this.auth.login(this.cpf, this.senha).subscribe({
      next: () => {
        this.notify.success('Login realizado com sucesso!');
        this.router.navigate(['/pages/dashboard.html']);
      },
      error: () => {
        this.notify.error('CPF ou senha inválidos.');
      }
    });
  }
}

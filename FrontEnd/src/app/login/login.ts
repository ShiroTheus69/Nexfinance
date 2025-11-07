import { Component } from '@angular/core';
import { PoTemplatesModule } from '@po-ui/ng-templates';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    PoTemplatesModule,
    RouterLink
  ],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {
  readonly logo = 'assets/logo-nf.png';

  readonly secondaryAction = {
    label: 'Criar Conta',
    action: () => {
      console.log('Clique em Criar Conta');
    }
  };

  login(formData: any) {
    console.log('Dados de Login:', formData);
    alert('Login simulado. Implementar lógica de autenticação.');
  }
}

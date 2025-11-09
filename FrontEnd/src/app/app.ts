import { Component, inject } from '@angular/core';
import { RouterOutlet, Router, NavigationEnd } from '@angular/router';
import { PoMenuModule, PoPageModule, PoToolbarModule, PoIconModule } from '@po-ui/ng-components';
import { CommonModule } from '@angular/common';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    PoToolbarModule,
    PoMenuModule,
    PoPageModule,
    PoIconModule,
    CommonModule
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  title = 'NexFinance';
  nomeUsuario = 'Matheus Braga'; // exemplo, pode vir de um login futuramente
  router = inject(Router);
  showMenu = false;

  constructor() {
    this.router.events.pipe(
      filter((event) => event instanceof NavigationEnd)
    ).subscribe((event: any) => {
      const url = event.urlAfterRedirects;
      this.showMenu = !url.includes('/login') && !url.includes('/cadastro');
    });
  }
}

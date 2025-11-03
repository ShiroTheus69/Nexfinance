import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PoMenuModule, PoPageModule, PoToolbarModule } from '@po-ui/ng-components';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    PoToolbarModule,
    PoMenuModule,
    PoPageModule
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  title = 'NexFinance';
}

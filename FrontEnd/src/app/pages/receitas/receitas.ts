import { Component } from '@angular/core';
import { PoPageModule, PoTableModule, PoButtonModule } from '@po-ui/ng-components';

@Component({
  selector: 'app-receitas',
  imports: [
    PoPageModule,
    PoTableModule,
    PoButtonModule
  ],
  templateUrl: './receitas.html',
  styleUrl: './receitas.css'
})
export class ReceitasComponent {
  title = 'Receitas';
}

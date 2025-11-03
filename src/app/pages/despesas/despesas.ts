import { Component } from '@angular/core';
import { PoPageModule, PoTableModule, PoButtonModule } from '@po-ui/ng-components';

@Component({
  selector: 'app-despesas',
  imports: [
    PoPageModule,
    PoTableModule,
    PoButtonModule
  ],
  templateUrl: './despesas.html',
  styleUrl: './despesas.css'
})
export class DespesasComponent {
  title = 'Despesas';
}

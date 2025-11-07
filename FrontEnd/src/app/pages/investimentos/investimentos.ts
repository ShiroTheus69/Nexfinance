import { Component } from '@angular/core';
import { PoPageModule, PoTableModule, PoButtonModule } from '@po-ui/ng-components';

@Component({
  selector: 'app-investimentos',
  imports: [
    PoPageModule,
    PoTableModule,
    PoButtonModule
  ],
  templateUrl: './investimentos.html',
  styleUrl: './investimentos.css'
})
export class InvestimentosComponent {
  title = 'Investimentos';
}

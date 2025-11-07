import { Component } from '@angular/core';
import { PoPageModule, PoWidgetModule } from '@po-ui/ng-components';

@Component({
  selector: 'app-relatorios',
  imports: [
    PoPageModule,
    PoWidgetModule
  ],
  templateUrl: './relatorios.html',
  styleUrl: './relatorios.css'
})
export class RelatoriosComponent {
  title = 'Relatórios';
}

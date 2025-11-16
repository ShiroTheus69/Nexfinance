import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {
  PoModalModule,
  PoButtonModule,
  PoFieldModule,
  PoDatepickerModule,
  PoNotificationModule,
  PoModalComponent,
  PoNotificationService
} from '@po-ui/ng-components';

import { InvestimentosService } from '../../services/investimento.service';

@Component({
  selector: 'app-investimentos',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    PoModalModule,
    PoButtonModule,
    PoFieldModule,
    PoDatepickerModule,
    PoNotificationModule
  ],
  templateUrl: './investimentos.html',
  styleUrl: './investimentos.css'
})
export class InvestimentosComponent {

  @ViewChild('modalNovoInvestimento', { static: false })
  modalNovoInvestimento!: PoModalComponent;

  investimentos: any[] = [];

  tiposInvestimento = [
    { label: 'Ações', value: 'Acoes' },
    { label: 'Tesouro Direto', value: 'Tesouro' },
    { label: 'Fundos', value: 'Fundos' },
    { label: 'CDB / Renda Fixa', value: 'RendaFixa' }
  ];

  novoInvest = {
    descricao: '',
    valor: null as number | null,
    data: '',
    tipo: ''
  };

  constructor(
    private investimentosService: InvestimentosService,
    private poNotification: PoNotificationService
  ) {}

  abrirModal(): void {
    this.modalNovoInvestimento.open();
  }

  fecharModal(): void {
    this.modalNovoInvestimento.close();
  }

  salvarInvestimento(): void {

    if (!this.novoInvest.descricao || !this.novoInvest.valor || !this.novoInvest.tipo) {
      this.poNotification.error('Preencha os campos obrigatórios.');
      return;
    }

    this.investimentosService.create(this.novoInvest).subscribe({
      next: () => {
        this.poNotification.success('Investimento cadastrado!');
        this.fecharModal();
        this.limparFormulario();
      },
      error: err => {
        console.error(err);
        this.poNotification.error('Erro ao salvar investimento.');
      }
    });

  }

  limparFormulario(): void {
    this.novoInvest = {
      descricao: '',
      valor: 0,
      data: '',
      tipo: ''
    };
  }
}

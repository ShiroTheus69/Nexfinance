import { Component, ViewChild, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {
  PoModalComponent,
  PoModalModule,
  PoButtonModule,
  PoTableModule,
  PoFieldModule,           
  PoNotificationService,
  PoNotificationModule
} from '@po-ui/ng-components';

import { DespesasService } from '../../services/despesas.service';

@Component({
  selector: 'app-despesas',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    PoModalModule,
    PoButtonModule,
    PoTableModule,
    PoFieldModule,        // <-- importante: substitui PoNumberModule/PoSelectModule/etc
    PoNotificationModule
  ],
  templateUrl: './despesas.html',
  styleUrls: ['./despesas.css']
})
export class DespesasComponent implements OnInit {
  @ViewChild('modalNovaDespesa', { static: true }) modalNovaDespesa!: PoModalComponent;

  despesas: any[] = [];
  categorias: any[] = [];

  novaDespesa = {
    descricao: '',
    valor: null as number | null,
    data: new Date(),
    categoriaId: null as number | null
  };

  constructor(
    private despesasService: DespesasService,
    private poNotification: PoNotificationService
  ) {}

  ngOnInit(): void {
  }

  abrirModal(): void {
    this.modalNovaDespesa.open();
  }

  fecharModal(): void {
    this.modalNovaDespesa.close();
  }

  salvarDespesa(): void {
    if (!this.novaDespesa.descricao || !this.novaDespesa.valor || !this.novaDespesa.categoriaId) {
      this.poNotification.error('Preencha todos os campos obrigatórios.');
      return;
    }

    this.despesasService.criar(this.novaDespesa).subscribe({
      next: (res) => {
        this.poNotification.success('Despesa cadastrada.');
        this.fecharModal();
      },
      error: (err) => {
        console.error(err);
        this.poNotification.error('Erro ao salvar despesa.');
      }
    });
  }
}

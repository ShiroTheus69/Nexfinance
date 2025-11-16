import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import {
  PoModule,
  PoModalComponent,
  PoTableColumn,
  PoNotificationService,
  PoModalAction
} from '@po-ui/ng-components';
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { ReceitasService } from './receitas.service';




export interface PagedResult<T> { items: T[]; total: number; }
export interface LancamentoDto {
  id: number;
  usuarioId: number;
  categoriaId: number;
  contaId: number;
  tipo: string;
  valor: number;
  data: string;
  descricao?: string;
}
export interface CreateLancamentoDto {
  usuarioId: number;
  categoriaId: number;
  contaId: number;
  tipo: string;
  valor: number;
  data: string;
  descricao?: string;
}
export interface CategoriaDto { id: number; nome: string; tipo: string; descricao?: string; }
export interface ContaDto { id: number; nome: string; tipo: string; idUsuario: number; }


@Component({
  selector: 'app-receitas',
  standalone: true,
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule, PoModule],
  templateUrl: './receitas.html',
  styleUrls: ['./receitas.css']
})
export class ReceitasComponent {
  @ViewChild('modal') modal!: PoModalComponent;


 columns: PoTableColumn[] = [
    { property: 'data', label: 'Data', type: 'date', sortable: true },
    { property: 'descricao', label: 'Descrição', sortable: true },
    { property: 'valor', label: 'Valor', type: 'currency', sortable: true }
  ];

  items: LancamentoDto[] = [];
  contasOptions: Array<{ label: string; value: number }> = [];
  categoriasOptions: Array<{ label: string; value: number }> = [];
  form!: FormGroup;
  usuarioId = 1;
  loading = false;

  primaryAction: PoModalAction = {
    label: 'Salvar',
    action: () => this.save(),
    disabled: true
  };

  secondaryAction: PoModalAction = {
    label: 'Cancelar',
    action: () => this.modal.close()
  };

  constructor(
    private fb: FormBuilder,
    private api: ReceitasService,
    private notify: PoNotificationService
  ) {
    this.form = this.fb.group({
      contaId: [null, Validators.required],
      categoriaId: [null, Validators.required],
      valor: [null, [Validators.required, Validators.min(0.01)]],
      data: [new Date(), Validators.required],
      descricao: ['']
    });

    this.form.statusChanges.subscribe(() => {
      this.primaryAction.disabled = this.form.invalid;
    });
  }

  ngOnInit(): void {
    this.loadCombos();
    this.reload();
  }

  openNew(): void {
    this.form.reset({
      contaId: null,
      categoriaId: null,
      valor: null,
      data: new Date(),
      descricao: ''
    });
    this.modal.open();
  }

  save(): void {
    const v = this.form.value;
    const dto: CreateLancamentoDto = {
      usuarioId: this.usuarioId,
      contaId: Number(v.contaId),
      categoriaId: Number(v.categoriaId),
      tipo: 'Receita',
      valor: Number(v.valor),
      data: new Date(v.data as any).toISOString(),
      descricao: (v.descricao as string) || ''
    };

    this.api.criarReceita(dto).subscribe({
      next: () => {
        this.notify.success('Receita criada com sucesso!');
        this.modal.close();
        this.reload();
      },
      error: (err: any) =>
        this.notify.error(err?.error?.message || 'Erro ao criar receita')
    });
  }

  loadCombos(): void {
    this.api.listContas(this.usuarioId).subscribe((contas: ContaDto[]) => {
      this.contasOptions = contas.map(c => ({ label: c.nome, value: c.id }));
    });

    this.api.listCategoriasReceita().subscribe((cats: CategoriaDto[]) => {
      this.categoriasOptions = cats
        .filter(c => (c.tipo || '').toLowerCase() === 'receita')
        .map(c => ({ label: c.nome, value: c.id }));
    });
  }

    reload(): void {
      this.loading = true;
      this.api.listReceitas(this.usuarioId, 1, 10).subscribe({
        next: (res: PagedResult<LancamentoDto>) => {
          this.items = res.items;
          this.loading = true;
        },
      
    });
  }
}
			
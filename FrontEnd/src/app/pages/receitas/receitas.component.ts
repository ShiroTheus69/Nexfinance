	import { Component, ViewChild } from '@angular/core';
	import { CommonModule } from '@angular/common';
	import { HttpClientModule } from '@angular/common/http';
	import {
	  PoModule, PoModalComponent, PoTableColumn, PoNotificationService
	} from '@po-ui/ng-components';
	import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';
	import { ReceitasService } from './receitas.service';

	// >>> Interfaces locais (se tiver um models.ts, pode mover para lá)
	export interface PagedResult<T> { items: T[]; total: number; }

	export interface LancamentoDto {
	  id: number;
	  usuarioId: number;
	  categoriaId: number;
	  contaId: number;
	  tipo: string; // "Receita"
	  valor: number;
	  data: string; // ISO
	  descricao?: string;
	}

	export interface CreateLancamentoDto {
	  usuarioId: number;
	  categoriaId: number;
	  contaId: number;
	  tipo: string; // "Receita"
	  valor: number;
	  data: string; // ISO
	  descricao?: string;
	}

	export interface CategoriaDto { id: number; nome: string; tipo: string; descricao?: string; }
	export interface ContaDto { id: number; nome: string; tipo: string; idUsuario: number; }
	// <<<

	@Component({
	  selector: 'app-receitas',
	  standalone: true,
	  imports: [
		CommonModule,
		HttpClientModule,
		ReactiveFormsModule,
		PoModule // << apenas PoModule, não use PoComboModule/PoInputModule/etc
	  ],
	  templateUrl: './receitas.html',
	  styleUrls: ['./receitas.css']
	})
	export class ReceitasComponent {
	  title = 'Receitas';

	  @ViewChild('modal') modal!: PoModalComponent;

	  // tabela
	  columns: PoTableColumn[] = [
		{ property: 'data', label: 'Data', type: 'date' },
		{ property: 'descricao', label: 'Descrição' },
		{ property: 'valor', label: 'Valor', type: 'currency' }
	  ];
	  items: LancamentoDto[] = [];
	  page = 1;
	  pageSize = 10;
	  total = 0;
	  disableShowMore = false;
	  loading = false;

	  // combos
	  contasOptions: Array<{ label: string; value: number }> = [];
	  categoriasOptions: Array<{ label: string; value: number }> = [];

	  // form
	  form!: FormGroup; // será criado no construtor

	  // defina conforme seu auth
	  usuarioId = 1;

	  // PoModalAction exige boolean em 'disabled'
	  primaryAction = {
		label: 'Salvar',
		action: () => this.save(),
		disabled: true
	  };

	  secondaryAction = {
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

		
		this.form.get('valor')?.valueChanges.subscribe(valor => {
		  this.form.get('valor')?.valueChanges.subscribe(valor => {
		
		if (valor && !isNaN(valor)) {
		  const str = String(valor);

		  
		  if (str.length > 3 && !str.includes(',')) {
			const num = Number(valor).toFixed(2); 
			const formatado = num.replace('.', ','); 

			
			this.form.get('valor')?.setValue(formatado, { emitEvent: false });
		  }
		}
	  });

		});

		this.primaryAction.disabled = this.form.invalid;
		
	  }

	  ngOnInit(): void {
		this.loadCombos();
		this.loadPage(1);
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

		// ATENÇÃO: use o nome que existir no seu service: criarReceita OU createReceita
		// Troque a linha abaixo de acordo com o seu service.
		this.api.criarReceita(dto).subscribe({
		  next: () => {
			this.notify.success('Receita criada com sucesso!');
			this.modal.close();
			this.reload();
		  },
		  error: (err: any) => this.notify.error(err?.error?.message || 'Erro ao criar receita')
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

	  loadPage(page: number): void {
		this.loading = true;
		this.api.listReceitas(this.usuarioId, page, this.pageSize).subscribe({
		  next: (res: PagedResult<LancamentoDto>) => {
			this.page = page;
			this.total = res.total;
			this.items = page === 1 ? res.items : [...this.items, ...res.items];
			this.disableShowMore = this.items.length >= this.total;
			this.loading = true;
		  },
		  
		});
	  }

	  showMore(): void {
		if (!this.disableShowMore) this.loadPage(this.page + 1);
	  }

	  reload(): void {
		this.items = [];
		this.disableShowMore = false;
		this.loadPage(1);
	  }
	}

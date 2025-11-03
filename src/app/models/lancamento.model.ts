export interface Lancamento {
  id?: number;
  usuarioId: number;
  categoriaId: number;
  contaId: number;
  tipo: 'ENTRADA' | 'SAIDA';
  valor: number;
  data: Date;
  descricao?: string;
  dataCriacao?: Date;
}

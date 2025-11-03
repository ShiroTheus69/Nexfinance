export interface Categoria {
  id?: number;
  nome: string;
  tipo: 'ENTRADA' | 'SAIDA';
  descricao?: string;
}

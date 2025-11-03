export interface Conta {
  id?: number;
  nome: string;
  tipo: 'CARTEIRA' | 'BANCO' | 'CARTAO';
  saldoInicial: number;
  dataCriacao?: Date;
}

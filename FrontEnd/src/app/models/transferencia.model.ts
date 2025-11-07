export interface Transferencia {
  id?: number;
  usuarioId: number;
  contaOrigemId: number;
  contaDestinoId: number;
  valor: number;
  data: Date;
  descricao?: string;
  dataCriacao?: Date;
}

import { Mensalidade } from "./mensalidade";

export interface Atleta {
  atletaId: number;
  nome: string;
  apelido: string;
  camisa: number;
  posicao: number;
  comissao: boolean;
  whatsApp: string;
  dataNascimento: Date;
  imageUrl: string;
  dataCadastro: Date;
  mensalidades: Mensalidade[];
}

import { Categoria } from "./categoria";
import { Mensalidade } from "./mensalidade";

export interface Controle {
  controleId: number;
  nome: string;
  ehAtleta: boolean;
  categoriaId: number;
  status: number;
  categoria: Categoria;
  dataCadastro: Date;
  dataPagamento: Date;
  mensalidadeId: number;
  mensalidade: Mensalidade;
  preco: number;
}

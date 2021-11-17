import { Atleta } from "./atleta";
import { Controle } from "./controle";

export interface Mensalidade {
  mensalidadeId: number;
  vencimento: Date;
  dataCadastro: Date;
  valorPrincipal: number;
  valorPagamento: number;
  valorDesconto: number;
  valorSaldo: number;
  dataPagamento: Date;
  ehQuitada: boolean;
  atletaId: number;
  atleta: Atleta;
  controle: Controle[];
}

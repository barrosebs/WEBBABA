import { Atleta } from './../models/atleta';
import { AtletaService } from './../service/atleta.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-atletas',
  templateUrl: './atletas.component.html',
  styleUrls: ['./atletas.component.css']
})
export class AtletasComponent implements OnInit {

  _filtroLista = '';
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value;
    this.atletasFiltrados = this.filtroLista ? this.filtrarAtletas(this.filtroLista) : this.atletas;
  }

  atletasFiltrados: Atleta[];
  atletas: Atleta[];
  exibirImagem = false;
  imageLargura = 60;
  imageMargin = 5;

  constructor(private atletaService: AtletaService) {
    this.atletasFiltrados = [];
    this.atletas = [];
  }

  ngOnInit() {
    this.getAtletas()
  }

  getAtletas(){
    this.atletaService.getAllAtleta().subscribe(
      (_atleta: Atleta[]) => {
        this.atletas = _atleta;
        console.log(this.atletas);
       }, error => {
         console.log(error);
       }
    );
  }

  mostrarImagem(){
   this.exibirImagem = !this.exibirImagem
  }

  filtrarAtletas(filtrarPor: string): Atleta[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.atletas.filter(
      atleta => atleta.nome.toLocaleLowerCase()
    )

  }
}

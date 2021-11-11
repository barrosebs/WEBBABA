import { Atleta } from './../models/atleta';
import { AtletaService } from './../service/atleta.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-atletas',
  templateUrl: './atletas.component.html',
  styleUrls: ['./atletas.component.css']
})
export class AtletasComponent implements OnInit {

  atletasFiltrados: Atleta[];
  atletas: Atleta[];
  exibirImagem = false;
  modalRef?: BsModalRef;
  imageLargura = 60;
  imageMargin = 5;

    constructor
    (
      private atletaService: AtletaService
      , private modalService: BsModalService
    )
    {
      this.atletasFiltrados = [];
      this.atletas = [];

    }

  _filtroLista = '';
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value;
    this.atletasFiltrados = this.filtroLista ? this.filtrarAtletas(this.filtroLista) : this.atletas;
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
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

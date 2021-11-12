import { Atleta } from './../models/atleta';
import { AtletaService } from './../service/atleta.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-atletas',
  templateUrl: './atletas.component.html',
  styleUrls: ['./atletas.component.css']
})
export class AtletasComponent implements OnInit {

  atletasFiltrados: Atleta[];
  atletas: Atleta[];
  modalRef?: BsModalRef;
  registerForm!: FormGroup;
  exibirImagem = false;
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
    this.validation();
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

  validation(){
    this.registerForm = new FormGroup({
      nome: new FormControl('',[Validators.required, Validators.minLength(4), Validators.maxLength(100)]),
      apelido: new FormControl('',Validators.required),
      camisa: new FormControl('',Validators.required),
      posicao: new FormControl('',Validators.required),
      dataNascimento: new FormControl('',Validators.required),
      whatsApp: new FormControl('',Validators.required),
      comissao: new FormControl('',Validators.required),
      imageUrl: new FormControl('',Validators.required),
    })
    console.log(this.validation);
  }
  salvarAlteracao(){

  }
  filtrarAtletas(filtrarPor: string): Atleta[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.atletas.filter(
      atleta => atleta.nome.toLocaleLowerCase()
    )

  }
}

import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Atleta } from 'src/app/models/atleta';
import { AtletaService } from 'src/app/services/atleta.service';

@Component({
  selector: 'app-Lista',
  templateUrl: './atletaLista.component.html',
  styleUrls: ['./atletaLista.component.css']
})
export class AtletaListaComponent implements OnInit {


  public atletasFiltrados: Atleta[];
  public atletas: Atleta[];
  public modalRef?: BsModalRef;
  public registerForm!: FormGroup;
  public exibirImagem = false;
  public imageLargura = 60;
  public imageMargin = 5;

  message?: string;

    constructor
    (
      private atletaService: AtletaService
      , private modalService: BsModalService
      , private toastrService: ToastrService
      , private spinner: NgxSpinnerService
      , private router: Router
    )
    {
      this.atletasFiltrados = [];
      this.atletas = [];

    }

    public ngOnInit() {
      this.spinner.show();
      this.validation();
      this.getAtletas();
       /** spinner starts on init */

       setTimeout(() => {
         /** spinner ends after 5 seconds */
         this.spinner.hide();
       }, 1000);

    }


  _filtroLista = '';
  public get filtroLista(): string{
    return this._filtroLista;
  }
  public set filtroLista(value: string){
    this._filtroLista = value;
    this.atletasFiltrados = this.filtroLista ? this.filtrarAtletas(this.filtroLista) : this.atletas;
  }

  public openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public getAtletas(): void{
    this.atletaService.getAllAtleta().subscribe({
      next: (_atleta: Atleta[]) => {
        this.atletas = _atleta;
        this.atletasFiltrados = this.atletas;
      }, error: (error: any) => {
        this.spinner.show();
        this.toastrService.error('Erro ao tentar carregar os atletas.','ERRO!');
      },
         complete: () => this.spinner.show()
    });
  }

  public mostrarImagem(): void{
   this.exibirImagem = !this.exibirImagem
  }

  public validation(): void {
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
  }
  salvarAlteracao(){

  }
  public filtrarAtletas(filtrarPor: string): Atleta[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.atletas.filter(
      atleta => atleta.nome.toLocaleLowerCase()
    )

  }

  public confirm(): void {
    this.message = 'Confirmed!';
    this.toastrService.success('O atleta foi deletado com sucesso!','Deletado');
    this.modalRef?.hide();
  }

  public decline(): void {
    this.message = 'Declined!';
    this.modalRef?.hide();
  }
  public openDetalhes(id: number):void{
    this.router.navigate([`/atletas/detalhes/${id}`]);
    console.log(this.router);
  }

}

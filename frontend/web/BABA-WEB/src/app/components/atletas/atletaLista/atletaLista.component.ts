import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '@environments/environment';
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
  public exibirImagem = false;
  public imageLargura = 60;
  public imageMargin = 5;
  public atletaId = 0;
  public imageUrl = '';
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


  public getAtletas(): void{
    this.atletaService.getAllAtleta().subscribe({
      next: (_atleta: Atleta[]) => {
        this.atletas = _atleta;
        this.imageUrl = environment.apiUrl + 'resources/images' + _atleta;
        this.atletasFiltrados = this.atletas;
      }, error: (error: any) => {
        this.spinner.show();
        this.toastrService.error('Xiii deu ruim!!! Chama o pessoal de TI! Erro ao tentar carregar os atletas.','ERRO!');
      },
         complete: () => this.spinner.hide()
    });

    
  }


  public mostraImagem(imageUrl: string): string{
    return imageUrl !== '' 
    ? `${environment.apiUrl}resources/images/${imageUrl}`
    : 'assets/image/sem-imagem.png';
  }
  
  public mostrarImagem(): void{
   this.exibirImagem = !this.exibirImagem
  }


  public filtrarAtletas(filtrarPor: string): Atleta[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.atletas.filter(
      atleta => atleta.nome.toLocaleLowerCase()
    )

  }

public openModal(event:any, template: TemplateRef<any>, atletaId: number): void{
      this.atletaId = atletaId;
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }

public confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();
    this.atletaService.deleteAtleta(this.atletaId).subscribe(
      (result: boolean) => {
        console.log('resultado: '+ result);
        if(result === true){
          this.toastrService.success('O atleta foi deletado com sucesso!','Deletado');
          this.spinner.hide();
          this.getAtletas();
        }
      },
      (error: any) => {
        console.error(error);
        this.toastrService.error(`Erro ao tentar deletar o atleta código ${this.atletaId}`,'ERRO');
        this.spinner.hide();

      },
      () => {
        this.spinner.hide();
      }
    )
  }

  public decline(): void {
    this.message = 'Declined!';
    this.modalRef?.hide();
  }

  public openDetalhes(id: number):void{
    this.router.navigate([`/atletas/detalhes/${id}`]);
    console.log(this.router);
  }

  public salvarAlteracao(): void {
    this.spinner.show();
  }
}

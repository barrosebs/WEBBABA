import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Atleta } from '@app/models/atleta';
import { AtletaService } from '@app/services/atleta.service';
import { environment } from '@environments/environment';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-listaControle',
  templateUrl: './listaControle.component.html',
  styleUrls: ['./listaControle.component.css']
})
export class ListaControleComponent implements OnInit {

  public atletas?: Atleta[];
  public modalRef?: BsModalRef;
  public message?: string;
  public atletaId = 0;
  public imageUrl = '/backend/src/BABA.API/Resources/images/sem-imagem.png';

  public atletasFiltrados?: Atleta[];

  constructor(
    private atletaService: AtletaService
    ,  private modalService: BsModalService
    , private toastrService: ToastrService
    , private spinner: NgxSpinnerService
    , private router: Router
  ) { }

  ngOnInit() {
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
      console.log(this.atletas);
    
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
  public openModal(event:any, template: TemplateRef<any>): void{
    this.modalRef = this.modalService.show(template, {class: 'modal-dialog modal-dialog-centered modal-dialog-scrollable'});
  }

  public decline(): void {
    this.message = 'Declined!';
    this.modalRef?.hide();
  }

}

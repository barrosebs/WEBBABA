import { Component, OnInit, TemplateRef } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Categoria } from '@app/models/categoria';
import { Controle } from '@app/models/controle';
import { CategoriaService } from '@app/services/categoria.service';
import { ControleService } from '@app/services/controle.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-listaControle',
  templateUrl: './listaControle.component.html',
  styleUrls: ['./listaControle.component.css'],
})
export class ListaControleComponent implements OnInit {
  public controle = {} as Controle;
  //public controles: Controle[];
  public categorias: Categoria[];
  public modalRef?: BsModalRef;
  public message?: string;
  public controleId = 0;
  public form!: FormGroup;

  constructor(
    private categoriaService: CategoriaService,
    private controleService: ControleService,
    private modalService: BsModalService,
    private toastrService: ToastrService,
    private spinner: NgxSpinnerService,
    private fb: FormBuilder
  ) {
   // this.controles = [];
    this.categorias = [];
  }

  ngOnInit() {}


  public getCategorias(): void {
    this.categoriaService.getAllCategoria().subscribe({
      next: (_categoria: Categoria[]) => {
        this.categorias = _categoria;
        this.categorias;
      },
      error: (error: any) => {
        this.spinner.show();
        this.toastrService.error(
          'Xiii deu ruim!!! Chama o pessoal de TI! Erro ao tentar carregar os controles.',
          'ERRO!'
        );
      },
      complete: () => this.spinner.hide(),
    });
    console.log(this.categorias);
  }

  public getControles(): void {
    this.controleService.getAllControle().subscribe({
      next: (_controle: Controle[]) => {
        this.controle;
      },
      error: (error: any) => {
        this.spinner.show();
        this.toastrService.error(
          'Xiii deu ruim!!! Chama o pessoal de TI! Erro ao tentar carregar os controles.',
          'ERRO!'
        );
      },
      complete: () => this.spinner.hide(),
    });
    console.log(this.categorias);
  }

  public confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();
    this.controleService.deleteControle(this.controleId).subscribe(
      (result: boolean) => {
        console.log('resultado: ' + result);
        if (result === true) {
          this.toastrService.success(
            'O controle foi deletado com sucesso!',
            'Deletado'
          );
          this.spinner.hide();
          this.getControles();
        }
      },
      (error: any) => {
        console.error(error);
        this.toastrService.error(
          `Erro ao tentar deletar o controle código ${this.controleId}`,
          'ERRO'
        );
        this.spinner.hide();
      },
      () => {
        this.spinner.hide();
      }
    );
  }
  public openModal(event: any, template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {
      class: 'modal-dialog modal-dialog-centered modal-dialog-scrollable',
    });
  }

  public decline(): void {
    this.message = 'Declined!';
    this.modalRef?.hide();
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm?.errors && campoForm?.touched };
  }
  get f(): any {
    return this.form.controls;
  }

  public validation(): void {
    this.form = this.fb.group({
      nome:   ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      vencimento:  ['', Validators.required]
  
    })
     console.log(this.form)
  }
}

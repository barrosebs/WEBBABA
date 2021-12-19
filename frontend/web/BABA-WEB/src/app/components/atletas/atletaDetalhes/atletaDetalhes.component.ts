import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { AtletaService } from './../../../services/atleta.service';
import { Atleta } from '@app/models/atleta';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { environment } from '@environments/environment';

@Component({
  selector: 'app-atletaDetalhes',
  templateUrl: './atletaDetalhes.component.html',
  styleUrls: ['./atletaDetalhes.component.css']
})
export class AtletaDetalhesComponent implements OnInit {

  public atleta = {} as Atleta;
  public registerForm!: FormGroup;
  public modalRef?: BsModalRef;
  public datePickerConfig: Partial<BsDatepickerConfig>;
  public estadoSalvar = 'post';
  public imageUrl = 'assets/image/upload.png';

  constructor(
    private modalService: BsModalService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
    , private router: ActivatedRoute
    , private atletaService: AtletaService
    , private spinner: NgxSpinnerService
    , private toastr : ToastrService
    
    ) {
      this.localeService.use('pt-br');
      this.datePickerConfig = Object.assign({}, {containerClass: 'theme-default'})
   }

  ngOnInit(): void {
    this.carregarAtleta();
    this.validation();
  }

  get modoEditar(): boolean{
    return this.estadoSalvar === 'put';
  }
  get f():any{
    return this.registerForm.controls;
  }
  public validation(): void {
    this.registerForm = this.fb.group({
      nome:   ['',[Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      apelido:  ['',Validators.required],
      camisa:   ['',Validators.required],
      posicao:  ['',Validators.required],
      dataNascimento:   ['',Validators.required],
      whatsApp:   ['',Validators.required],
      comissao:   ['',Validators.required],
    })
  }
  public carregarAtleta(): void{
    const atletaIdParam = this.router.snapshot.paramMap.get('id');
    if(atletaIdParam !== null){
      this.spinner.show();

      this.estadoSalvar = 'put';

      this.atletaService.getAtletaById(+atletaIdParam).subscribe(

        (atleta: Atleta) => {
          this.atleta = {... atleta};
          this.registerForm.patchValue(this.atleta);
          if(this.atleta.imageUrl !== ''){
            this.imageUrl = environment.apiUrl + 'resources/images/' + this.atleta.imageUrl;
          }
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao tentar EDITAR o ATLETA!','ERROR')
          console.error(error);
        },
        () => { this.spinner.hide()}
      );
    }
  }
  public openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public salvarAlteracao(): void{
    this.spinner.show();
    if(this.registerForm.valid){

      if(this.estadoSalvar === 'post'){
        this.atleta = {...this.registerForm.value}
        this.atletaService['post'](this.atleta).subscribe(
          () => this.toastr.success('Atleta salvo com sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Error ao salvar atleta', 'Error');
          },
          () => this.spinner.hide()
        );
      }else{
       this.atleta = {atletaId: this.atleta.atletaId,...this.registerForm.value};
        this.atletaService['put'](this.atleta).subscribe(
          () => this.toastr.success('Atleta salvo com sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Error ao salvar atleta', 'Error');
          },
          () => this.spinner.hide()
        );
      }
    };
  };

  public resertForm(): void{
    this.registerForm.reset();
  }

  public cssValidation(campoForm: FormControl): any{
    return {
      'is-invalid': campoForm?.errors && campoForm?.touched
    }
  }

  get bsConfig(): any{
    var c = {
      colorTheme: 'theme-default',
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      //containerClass: 'theme-default',
      showWeekNumbers: false
    };
    return {
     // colorTheme: 'theme-default',
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
     // containerClass: 'theme-default',
      showWeekNumbers: false
    };

  }
  public onFileChange(evt: any):void{
    console.log(evt);
    const selectFiles = <FileList>evt.srcElement.files;
    const reader = new FileReader();
    reader.onload = (event: any) => this.imageUrl = event.target.result;
    reader.readAsDataURL(selectFiles[0]);

    this.uploadImagem(this.atleta.atletaId, selectFiles);
  }

  public uploadImagem(atletaId: number, eve:any ):void{
    this.spinner.show();
    this.atletaService.postUpload(atletaId, eve ).subscribe(
      () => {
        this.carregarAtleta();
        this.toastr.success('Imagem atualizada com sucesso!', 'Sucesso!');
      },
      (error: any) => {
        this.toastr.error('Erro ao tentar carregar imagem!', 'Error!');
        console.log(error);
        
      }
    ).add(() => this.spinner.hide())
  }

}

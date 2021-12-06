import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { AtletaService } from './../../../services/atleta.service';
import { Atleta } from '@app/models/atleta';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

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
      imageUrl:   ['',Validators.required],
    })
  }

  public openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public salvarAlteracao(): void{

  }

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
  public carregarAtleta(): void{
    const atletaIdParam = this.router.snapshot.paramMap.get('id');

    if(atletaIdParam !== null){
      this.spinner.show();
      var a = this.atletaService.getAtletaById(+atletaIdParam).subscribe(
        
        (atleta: Atleta) => {
          this.atleta = {... atleta};
          this.registerForm.patchValue(this.atleta);
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

}

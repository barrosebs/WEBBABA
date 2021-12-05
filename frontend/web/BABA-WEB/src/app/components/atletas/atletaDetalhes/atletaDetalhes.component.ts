import { AtletaService } from './../../../services/atleta.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Atleta } from '@app/models/atleta';

@Component({
  selector: 'app-atletaDetalhes',
  templateUrl: './atletaDetalhes.component.html',
  styleUrls: ['./atletaDetalhes.component.css']
})
export class AtletaDetalhesComponent implements OnInit {

  public atleta = {} as Atleta;
  public registerForm!: FormGroup;
  public modalRef?: BsModalRef;

  constructor(
    private modalService: BsModalService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
    , private router: ActivatedRoute
    , private atletaService: AtletaService
  ) {
    this.localeService.use('pt-br');
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
    return {
      colorTheme: 'theme-green',
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-default',
      showWeekNumbers: false
    };
  }
  public carregarAtleta(): void{
    const atletaIdParam = this.router.snapshot.paramMap.get('id');

    if(atletaIdParam !== null){
      var a = this.atletaService.getAtletaById(+atletaIdParam).subscribe(
        
        (atleta: Atleta) => {
          this.atleta = {... atleta};
          console.log(atleta);
          this.registerForm.patchValue(this.atleta);
        },
        (error: any) => {
          console.error(error);
        },
        () => {}
      );
    }
  }

}

import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-atletaDetalhes',
  templateUrl: './atletaDetalhes.component.html',
  styleUrls: ['./atletaDetalhes.component.css']
})
export class AtletaDetalhesComponent implements OnInit {

  public registerForm!: FormGroup;
  public modalRef?: BsModalRef;
  constructor(
    private modalService: BsModalService
    , private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.validation();
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

  salvarAlteracao(){

  }
}

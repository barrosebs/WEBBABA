import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
  ) { }

  ngOnInit(): void {
    this.validation();
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

  public openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  salvarAlteracao(){

  }
}

import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-button-voltar',
  templateUrl: './button-voltar.component.html',
  styleUrls: ['./button-voltar.component.css']
})
export class ButtonVoltarComponent implements OnInit {
  @Input() titulo = '';
  @Input() botaoListar = false;
  @Input() iconClass = 'fa fa-trash-o';
  @Input() subtitulo = '';
  @Input() classStyle = '';
  constructor(private router: Router) { }

  ngOnInit() {
  }

  
  listar(): void{
    this.router.navigate([
      `/${this.titulo.toLocaleLowerCase()}/${this.subtitulo}`
    ]);
    console.log(this.titulo);
  }

}

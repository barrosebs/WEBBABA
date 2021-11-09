import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-atletas',
  templateUrl: './atletas.component.html',
  styleUrls: ['./atletas.component.css']
})
export class AtletasComponent implements OnInit {
  atletas: any = [];
  exibirImagem = false;
  imageLargura = 60;
  imageMargin = 5;
  filtroLista = '';
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getAtletas()
  }
  getAtletas(){
    this.http.get('https://localhost:44344/api/atleta').subscribe(
      response => { 
        this.atletas = response;
       }, error => {
         console.log(error);
       }      
    );
  }
  mostrarImagem(){
   this.exibirImagem = !this.exibirImagem
  }
}

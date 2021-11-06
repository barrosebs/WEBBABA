import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-atletas',
  templateUrl: './atletas.component.html',
  styleUrls: ['./atletas.component.css']
})
export class AtletasComponent implements OnInit {
  atletas: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getAtletas()
  }
  getAtletas(){
    this.http.get('https://localhost:44344/api/atleta').subscribe(
      response => { 
        this.atletas = response;
        console.log(this.atletas);
       }, error => {
         console.log(error);
       }
      
    );
  }
}

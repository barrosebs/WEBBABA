import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Atleta } from '../models/atleta';

  @Injectable({
    providedIn: 'root'
  })

export class AtletaService {

  baseUrl = 'https://localhost:5001/api/atleta';

constructor(private http: HttpClient) { }

getAllAtleta(): Observable<Atleta[]>{
    return this.http.get<Atleta[]>(this.baseUrl);
  }
  getAtletaByTema(tema: string): Observable<Atleta[]>{
    return this.http.get<Atleta[]>('$ {this.baseUrl}/getByTema/${tema} ');
  }
  getAtletaById(id: number): Observable<Atleta[]>{
    return this.http.get<Atleta[]>('$ {this.baseUrl}/${id} ');
  }
}

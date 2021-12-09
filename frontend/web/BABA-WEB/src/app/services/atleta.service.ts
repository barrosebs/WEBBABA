import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Atleta } from '../models/atleta';
import { take } from 'rxjs/operators';
  @Injectable({ //chamada direto do app.module/providers
    providedIn: 'root'
  })

export class AtletaService {

  baseUrl = 'https://localhost:5001/api/Atleta';

constructor(private http: HttpClient) { }

public getAllAtleta(): Observable<Atleta[]>{
    return this.http
    .get<Atleta[]>(this.baseUrl)
    .pipe(take(1));
  }
public getAtletaByTema(tema: string): Observable<Atleta[]>{
    return this.http
    .get<Atleta[]>(`${this.baseUrl}/getByTema/${tema}/tema`)
    .pipe(take(1));
  }
public  getAtletaById(id: number): Observable<Atleta>{
    return this.http.get<Atleta>(`${this.baseUrl}/${id}`);
  }
  public post(atleta: Atleta): Observable<Atleta>{
    return this.http
    .post<Atleta>(this.baseUrl, atleta)
    .pipe(take(1));
  }

 public put(atleta: Atleta): Observable<Atleta>{
    return this.http
    .put<Atleta>(`${this.baseUrl}/${atleta.atletaId}`, atleta)
    .pipe(take(1));
  }

 public deleteAtleta(id: number): Observable<boolean>{
    return this.http
    .delete<boolean>(`${this.baseUrl}/${id}`)
    .pipe(take(1));
  }
}

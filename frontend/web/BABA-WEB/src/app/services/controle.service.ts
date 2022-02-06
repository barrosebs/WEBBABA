import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Controle } from '@app/models/controle';
import { environment } from '@environments/environment';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ControleService {
  baseUrl = environment.apiUrl + 'api/Controle';

  constructor(private http: HttpClient) {}

  public getAllControle(): Observable<Controle[]> {
    return this.http.get<Controle[]>(this.baseUrl).pipe(take(1));
  }

  public getControleById(id: number): Observable<Controle> {
    return this.http.get<Controle>(`${this.baseUrl}/${id}`);
  }
  public post(controle: Controle): Observable<Controle> {
    return this.http.post<Controle>(this.baseUrl, controle).pipe(take(1));
  }

  public put(controle: Controle): Observable<Controle> {
    return this.http
      .put<Controle>(`${this.baseUrl}/${controle.controleId}`, controle)
      .pipe(take(1));
  }

  public deleteControle(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}/${id}`).pipe(take(1));
  }
}

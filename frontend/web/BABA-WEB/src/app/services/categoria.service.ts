import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categoria } from '@app/models/categoria';
import { environment } from '@environments/environment';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class CategoriaService {
  baseUrl = environment.apiUrl + 'api/Categoria';
  constructor(private http: HttpClient) {}

  public getAllCategoria(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.baseUrl).pipe(take(1));
  }

  public getCategoriaById(id: number): Observable<Categoria> {
    return this.http.get<Categoria>(`${this.baseUrl}/${id}`);
  }
  public post(categoria: Categoria): Observable<Categoria> {
    return this.http.post<Categoria>(this.baseUrl, categoria).pipe(take(1));
  }

  public put(categoria: Categoria): Observable<Categoria> {
    return this.http
      .put<Categoria>(`${this.baseUrl}/${categoria.categoriaId}`, categoria)
      .pipe(take(1));
  }

  public deleteCategoria(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}/${id}`).pipe(take(1));
  }
}

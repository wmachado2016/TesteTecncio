
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from './models/usuario';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  public baseUrl = environment.apiEndpoint;

  constructor(private http: HttpClient) { }

  public buscarUsuarios(): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.baseUrl}/api/Usuarios`);
  }

  public buscarUsuariosPorId(id: string): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.baseUrl}/api/Usuarios/${id}`);
  }

  public Adicionar(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.baseUrl}/api/Usuarios`, { body: usuario });
  }

  public Atualizar(usuario: Usuario): Observable<Usuario> {
    return this.http.put<Usuario>(`${this.baseUrl}/api/Usuarios`, { body: usuario });
  }

  public Remover(id: string) {
    return this.http.delete(`${this.baseUrl}/api/Usuarios/${id}`);
  }
}

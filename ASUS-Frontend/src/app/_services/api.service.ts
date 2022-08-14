import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Kupac } from '../_model/kupac';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  vratiKupce(): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Kupac');
  }

  getById(id:number) : Observable<Kupac>{
    return this.http.get<Kupac>(this.baseUrl + id);
  }

  vratiDrzave(): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Drzava');
  }

  vratiGradove(idDrzave:number): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Grad/' + idDrzave);
  }

  unesiKupca(kupac:Kupac): Observable<any>{
    return this.http.post<any>(this.baseUrl + 'Kupac/', kupac);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Karakteristika } from '../_model/karakteristika';
import { Kupac } from '../_model/kupac';
import { Proizvod } from '../_model/proizvod';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = environment.apiUrl;
  vrednost:number = 3423;
  nazivKarakteristike:string = "lala";

  constructor(private http: HttpClient) { }

  getVrednost():number{
    return this.vrednost;
  }

  getNazivKarakteristike():string{
    return this.nazivKarakteristike;
  }

  setVrednost(vrednost:number){
    this.vrednost = vrednost;
  }

  setNaziv(naziv:string){
    this.nazivKarakteristike = naziv;
  }

  vratiKupce(): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Kupac');
  }

  getById(id:number) : Observable<Kupac>{
    return this.http.get<Kupac>(this.baseUrl + id);
  }

  vratiDrzave(): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Drzava');
  }

  vratiDrzavu(id:number): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Drzava/' + id);
  
  }

  vratiGradove(idDrzave:number): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Grad/' + idDrzave);
  }

  unesiKupca(kupac:Kupac): Observable<any>{
    return this.http.post<any>(this.baseUrl + 'Kupac/', kupac);
  }

  izmeniKupca(kupac:Kupac, id:number): Observable<any>{
    return this.http.put<any>(this.baseUrl + 'Kupac/' + id, kupac);
  }

  obrisiKupca(id:number):Observable<any>{
    return this.http.delete<any>(this.baseUrl + 'Kupac/' + id);
  }

  unesiProizvod(proizvod:Proizvod): Observable<any>{
    return this.http.post<any>(this.baseUrl + 'Proizvod/', proizvod);
  }
}

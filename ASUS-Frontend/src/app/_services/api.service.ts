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
  Vrednost:number = 0;
  NazivKarakteristike:string = "";

  constructor(private http: HttpClient) { }

  getVrednost():number{
    return this.Vrednost;
  }

  getNazivKarakteristike():string{
    return this.NazivKarakteristike;
  }

  setVrednost(Vrednost:number){
    this.Vrednost = Vrednost;
  }

  setNaziv(naziv:string){
    this.NazivKarakteristike = naziv;
  }

  vratiKupce(): Observable<any>{
    console.log(this.baseUrl + 'Kupac');
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

  vratiGradove(IDDrzave:number): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Grad/' + IDDrzave);
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

  vratiProizvode() :Observable<any>{
    return this.http.get<any>(this.baseUrl + 'Proizvod');
  }

  izmeniProizvod(proizvod:Proizvod) : Observable<any>{
    return this.http.put<any>(this.baseUrl + 'Proizvod', proizvod);
  }

  obrisiProizvod(id:number):Observable<any>{
    console.log(this.baseUrl + 'Proizvod/' + id);
    return this.http.delete<any>(this.baseUrl + 'Proizvod/' + id);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly baseUrl = "https://localhost:44372/api/Authentication";



  constructor(
    private http: HttpClient,
    private router: Router
    ) { }

  getToken(): string {
    return localStorage.getItem('token') || '';
  }


  login(params: { username: string, password: string }): Observable<{token:string}> {
    const url = this.baseUrl;
    return this.http.post<{token:string}>(url, params);
  }

  loggedIn(): boolean {
    console.log(!!localStorage.getItem('token'));
    return !!localStorage.getItem('token');
    //return false;
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/auth']);
  }
}
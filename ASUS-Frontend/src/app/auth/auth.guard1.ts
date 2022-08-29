import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard1 implements CanActivate {

  constructor(private authService: AuthService,
              private router: Router) {
  }

  canActivate(): boolean {
     if (this.authService.loggedIn()) {
        this.router.navigate(['/home']);
        return false;
    }
    else {
        return true;
    }
  }
}
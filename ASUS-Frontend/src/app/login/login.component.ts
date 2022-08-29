import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  LoginForm !: FormGroup;

  constructor(private formBuilder:FormBuilder, private authService:AuthService, private router:Router) { }

  ngOnInit(): void {
    this.LoginForm = this.formBuilder.group({
      username:['', Validators.required],
      password:['', Validators.required]
    });
  }

  get username() { return this.LoginForm.get('username'); };

  get password() { return this.LoginForm.get('password'); };

  authenticate(): void {
    const params = {
      username: this.username?.value,
      password: this.password?.value
    }
    this.authService.login(params).subscribe({
      next:(response) => {
        console.log(response)
        console.log(response.token);
        if (response) {
          alert('Uspesno ste se prijavili!')
            const url = "/home";            
            localStorage.setItem('token', response.token);
            this.router.navigate([url]);
        }
      },
      error:(err)=>{
        console.log(err.status);
        console.log(typeof(err.status));
        if(err.status == 401){
          alert('Pogresno korisnicko ime i/ili lozinka. Pokusajte ponovo.');
        }else{
          alert('Greska prilikom povezivanja na server');
        }
        
    }
    });

    /*this.authService.login(params).subscribe(
      (response) => {
        console.log(response.token);
        if (response) {
         const url = "/home";            
         localStorage.setItem('token', response.token);
         this.router.navigate([url]);
        }
      });*/

    }

}

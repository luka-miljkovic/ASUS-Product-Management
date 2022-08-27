import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "./auth/auth.guard";
import { HomeComponent } from "./home/home.component";
import { KupciComponent } from "./kupci/kupci.component";
import { LoginComponent } from "./login/login.component";
import { ProizvodiComponent } from "./proizvodi/proizvodi.component";

export const appRoutes: Routes = [
    {path:'', component: HomeComponent},

    {
    path: 'auth',
    component: LoginComponent
    },
  {
    path: 'kupci',
    component: KupciComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'proizvodi',
    component: ProizvodiComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: '/home'
  }

  
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
import { Component, OnInit } from '@angular/core';
import { Drzava } from '../_model/drzava';
import { Kupac } from '../_model/kupac';
import { ApiService } from '../_services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  kupci!:Kupac[];

  drzave!: Drzava[];

  constructor(private kupacService:ApiService) { }

  ngOnInit(): void {
    this.kupacService.vratiKupce().subscribe((response) =>{
      console.log(response);
      this.kupci = response;
    }, error => {
      console.log("greska!");
    });

    this.kupacService.vratiDrzave().subscribe((response) =>{
      console.log(response);
      this.drzave = response;
    }, error => {
      console.log("greska!");
    });
  }

}

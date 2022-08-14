import { Component, OnInit } from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Drzava } from 'src/app/_model/drzava';
import { ApiService } from 'src/app/_services/api.service';
import { KupciUnosComponent } from '../kupci-unos/kupci-unos.component';

interface Food {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-kupci-prikaz',
  templateUrl: './kupci-prikaz.component.html',
  styleUrls: ['./kupci-prikaz.component.css']
})
export class KupciPrikazComponent implements OnInit {

  foods: Food[] = [
    {value: 'steak-0', viewValue: 'Steak'},
    {value: 'pizza-1', viewValue: 'Pizza'},
    {value: 'tacos-2', viewValue: 'Tacos'},
  ];

  drzave!: Drzava[];

  constructor(private dialog:MatDialog, private apiService:ApiService) { }

  openDialog() {
    this.dialog.open(KupciUnosComponent, {
      width:'30%'
    });

    this.apiService.vratiDrzave().subscribe((response) =>{
      console.log(response);
      this.drzave = response;
    }, error => {
      console.log("greska!");
    });
  }


  ngOnInit(): void {
  }

}

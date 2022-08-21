import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProizvodiUnosComponent } from './proizvodi-unos/proizvodi-unos.component';

@Component({
  selector: 'app-proizvodi',
  templateUrl: './proizvodi.component.html',
  styleUrls: ['./proizvodi.component.css']
})
export class ProizvodiComponent implements OnInit {

  constructor(private dialog:MatDialog) { }

  ngOnInit(): void {
  }

  openDialog(){
    this.dialog.open(ProizvodiUnosComponent, {
      width:'100%'
    });

  }



}

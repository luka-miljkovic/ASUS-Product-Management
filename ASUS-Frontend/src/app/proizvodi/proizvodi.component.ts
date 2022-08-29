import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProizvodiUnosComponent } from './proizvodi-unos/proizvodi-unos.component';


import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { ApiService } from '../_services/api.service';

@Component({
  selector: 'app-proizvodi',
  templateUrl: './proizvodi.component.html',
  styleUrls: ['./proizvodi.component.css']
})
export class ProizvodiComponent implements OnInit {

  displayedColumns: string[] = ['SifraProizvoda', 'NazivModela','action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private dialog:MatDialog, private apiService:ApiService) { }

  ngOnInit(): void {
    this.vratiProizvode();
  }

  openDialog(){
    this.dialog.open(ProizvodiUnosComponent, {
      width:'100%'
    }).afterClosed().subscribe(val =>{
      if(val === 'save'){
        this.vratiProizvode();
      }
    });

  }

  vratiProizvode(){

    this.apiService.vratiProizvode()
    .subscribe({
      next:(response) =>{
        this.dataSource = new MatTableDataSource(response);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error:(err)=>{
        alert("Greska prilikom ucitavanja!");
      }
    })

  }

  izmeniProizvod(row:any){
    console.log(row);
    this.dialog.open(ProizvodiUnosComponent, {
      width:'70%',
      data:row
    }).afterClosed().subscribe(res =>{
      if(res === 'update'){
        this.vratiProizvode();
      }
    })

  }

  obrisiProizvod(id:number){
    console.log(id);
    this.apiService.obrisiProizvod(id)
    .subscribe({
      next:(resp)=>{
        alert("Proizvod je uspesno obrisan!");
        this.vratiProizvode();
      },
      error:()=>{
        alert("Greska prilikom brisanja proizvoda");
      }
    })

  }



  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }



}

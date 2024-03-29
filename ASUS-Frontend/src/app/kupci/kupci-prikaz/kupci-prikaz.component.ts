import { Component, OnInit, ViewChild } from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Drzava } from 'src/app/_model/drzava';
import { Grad } from 'src/app/_model/grad';
import { ApiService } from 'src/app/_services/api.service';
import { KupciUnosComponent } from '../kupci-unos/kupci-unos.component';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { GranularSanityChecks } from '@angular/material/core';


@Component({
  selector: 'app-kupci-prikaz',
  templateUrl: './kupci-prikaz.component.html',
  styleUrls: ['./kupci-prikaz.component.css']
})
export class KupciPrikazComponent implements OnInit {

  displayedColumns: string[] = ['PIB', 'NazivKupca', 'UlicaBroj', 'Drzava', 'Grad', 'action'];
  dataSource!: MatTableDataSource<any>;
  Gradovi!:Grad[];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;


  constructor(private dialog:MatDialog, private apiService:ApiService) { }

  openDialog() {
    this.dialog.open(KupciUnosComponent, {
      width:'30%'
    }).afterClosed().subscribe(val =>{
      if(val === 'save'){
        this.vratiKupce();
      }
    });
  }


  ngOnInit(): void {
    this.vratiKupce();
    console.log("hej");
    console.log(this.dataSource);
  }

  vratiKupce(){
    this.apiService.vratiKupce()
    .subscribe({
      next:(response) =>{
        console.log(response.length);
        this.dataSource = new MatTableDataSource(response);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        /*if(response.length > 0){
          
        }*/
        

      },
      error:(err)=>{
        alert("Greska prilikom ucitavanja!");
      }
    })
  }

  vratiDrzavu(id:number){
      this.apiService.vratiDrzavu(id)
      .subscribe({
        next:(response) =>{
          return response as Drzava;
        }
      })
  }

  
  izmeniKupca(row:any){
    this.dialog.open(KupciUnosComponent,{
      width:'30%',
      data:row
    }).afterClosed().subscribe(val =>{
      if(val === 'update'){
        this.vratiKupce();
      }
    });
  }

  obrisiKupca(id:number){
    this.apiService.obrisiKupca(id)
    .subscribe({
      next:(response)=>{
        alert("Kupac je uspesno izbrisan");
        this.vratiKupce();
      },
      error:()=>{
        alert("Greska prilikom brisanja kupca");
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

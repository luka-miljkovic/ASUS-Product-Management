import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Karakteristika } from 'src/app/_model/karakteristika';
import { Proizvod } from 'src/app/_model/proizvod';
import { ApiService } from 'src/app/_services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { KarakteristikaComponent } from 'src/app/karakteristika/karakteristika.component';

@Component({
  selector: 'app-proizvodi-unos',
  templateUrl: './proizvodi-unos.component.html',
  styleUrls: ['./proizvodi-unos.component.css']
})
export class ProizvodiUnosComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private apiService:ApiService, 
    private dialog : MatDialog) { }

  proizvodiForm !: FormGroup;
  karakteristikeForm !: FormGroup;
  activateKarakteristikaComponent:Boolean = false;

  displayedColumns:string[] = ['redniBroj', 'sifraProizvoda', 'nazivKarakteristike', 'vrednost', 'action'];
  dataSource!:MatTableDataSource<Karakteristika>

  karakteristike : Karakteristika[] = [];
  karakteristika:Karakteristika = {
    idKarakteristike:0,
    sifraProizvoda:0,
    vrednost:0,
    nazivKarakteristike:""

  };

  proizvod:Proizvod = {
    sifraProizvoda:0,
    nazivModela:"",
    karakteristike : this.karakteristike
  };

  brojac:number = 1;

  ngOnInit(): void {

    this.proizvodiForm = this.formBuilder.group({
      sifraProizvoda:['', Validators.required],
      nazivModela:['', Validators.required],
      nazivKarakteristike:['', Validators.required],
      vrednost:['', Validators.required]
    });

    //this.dataSource = new MatTableDataSource(this.karakteristike);

    
  }

  dodajKarakteristiku(){
    console.log("hej usao sam ovde");
    let karakteristika : Karakteristika = {
      idKarakteristike:this.brojac,
      sifraProizvoda: this.proizvodiForm.value['sifraProizvoda'],
      nazivKarakteristike: this.proizvodiForm.value['nazivKarakteristike'],
      vrednost : this.proizvodiForm.value['vrednost']
    }

    this.karakteristike.push(karakteristika);
    this.brojac++;
    //console.log(this.brojac);
    this.dataSource = new MatTableDataSource(this.karakteristike);

  }

  sacuvajProizvod(){
    this.proizvod.sifraProizvoda = this.proizvodiForm.value['sifraProizvoda'];
    this.proizvod.nazivModela = this.proizvodiForm.value['nazivModela'];
    this.proizvod.karakteristike = this.karakteristike;

    console.log(this.proizvod);

    this.apiService.unesiProizvod(this.proizvod)
    .subscribe({
      next:(response) =>{
        alert('Proizvod je uspesno sacuvan!');
        this.proizvodiForm.reset();
      },
      error:()=>{
        alert('Greska prilikom cuvanja proizvoda');
      }
    })
  }

  obrisiKarakteristiku(element:any){
    console.log(element);
    
    for(var i = 0; i<this.karakteristike.length; i++){
      if(this.karakteristike[i].idKarakteristike === element.idKarakteristike && this.karakteristike[i].sifraProizvoda === element.sifraProizvoda){
        console.log('usao sam');
        this.azurirajListu(i);
        this.karakteristike.splice(i,1);
        this.dataSource = new MatTableDataSource(this.karakteristike);
        return;
      }
    }
    
  }

  azurirajListu(redniBroj:number){
    for(var i = redniBroj + 1; i < this.karakteristike.length; i++){
      this.karakteristike[i].idKarakteristike--;
    }
    this.brojac--;
  }

  izmeniKarakteristiku(element:any){
      this.apiService.setVrednost(element.vrednost);
      this.apiService.setNaziv(element.nazivKarakteristike);
    this.dialog.open(KarakteristikaComponent, {
      width:'30%',
      data:element
    }).afterClosed().subscribe(res =>{

      console.log(this.apiService.getNazivKarakteristike());
    console.log(this.apiService.getVrednost());

    for(var i = 0; i<this.karakteristike.length; i++){
      if(this.karakteristike[i].idKarakteristike === element.idKarakteristike && this.karakteristike[i].sifraProizvoda === element.sifraProizvoda){
        this.karakteristike[i].nazivKarakteristike = this.apiService.getNazivKarakteristike();
        this.karakteristike[i].vrednost = this.apiService.getVrednost();
        return;
      }
    }

    });

    

  }

}

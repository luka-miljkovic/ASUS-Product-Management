import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Karakteristika } from 'src/app/_model/karakteristika';
import { Proizvod } from 'src/app/_model/proizvod';
import { ApiService } from 'src/app/_services/api.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { KarakteristikaComponent } from 'src/app/karakteristika/karakteristika.component';

@Component({
  selector: 'app-proizvodi-unos',
  templateUrl: './proizvodi-unos.component.html',
  styleUrls: ['./proizvodi-unos.component.css']
})
export class ProizvodiUnosComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private apiService:ApiService, 
              private dialog : MatDialog,
              @Inject(MAT_DIALOG_DATA) public editData:any,
              private dialogRef:MatDialogRef<ProizvodiUnosComponent>) { }

  proizvodiForm !: FormGroup;
  KarakteristikeForm !: FormGroup;
  actionBtn:string = "Sacuvaj"

  displayedColumns:string[] = ['redniBroj', 'SifraProizvoda', 'NazivKarakteristike', 'Vrednost', 'action'];
  dataSource!:MatTableDataSource<Karakteristika>

  Karakteristike : Karakteristika[] = [];
  karakteristika:Karakteristika = {
    IDKarakteristike:0,
    SifraProizvoda:0,
    Vrednost:0,
    NazivKarakteristike:""

  };

  proizvod:Proizvod = {
    SifraProizvoda:0,
    NazivModela:"",
    Karakteristike : this.Karakteristike
  };

  izmena:boolean = false;

  brojac:number = 1;

  ngOnInit(): void {

    this.proizvodiForm = this.formBuilder.group({
      SifraProizvoda:['', Validators.required],
      NazivModela:['', Validators.required]
    });

    if(this.editData){

      this.izmena = true;

      this.actionBtn = "Izmeni";

      this.proizvodiForm.controls["SifraProizvoda"].setValue(this.editData.SifraProizvoda);
      this.proizvodiForm.controls["NazivModela"].setValue(this.editData.NazivModela);
      this.Karakteristike = this.editData.Karakteristike;
      this.dataSource = new MatTableDataSource(this.Karakteristike);
    }


    
  }

  dodajKarakteristiku(){
    this.brojac = this.Karakteristike.length + 1;

    this.dialog.open(KarakteristikaComponent,{
      width:'30%',
    }).afterClosed().subscribe(res =>{
      if(res === 'save'){
        console.log("hej usao sam ovde");
      let karakteristika : Karakteristika = {
      IDKarakteristike:this.brojac,
      SifraProizvoda: this.proizvodiForm.value['SifraProizvoda'],
      NazivKarakteristike: this.apiService.getNazivKarakteristike(),
      Vrednost : this.apiService.getVrednost()
    }

      this.Karakteristike.push(karakteristika);
      this.brojac++;
      //console.log(this.brojac);
      this.dataSource = new MatTableDataSource(this.Karakteristike);

      }
      

    });

    

  }

  sacuvajProizvod(){
    this.proizvod.SifraProizvoda = this.proizvodiForm.value['SifraProizvoda'];
    this.proizvod.NazivModela = this.proizvodiForm.value['NazivModela'];
    this.proizvod.Karakteristike = this.Karakteristike;

    //console.log(this.proizvod);

    if(!this.editData){
      this.apiService.unesiProizvod(this.proizvod)
      .subscribe({
        next:(response) =>{
          alert('Proizvod je uspesno sacuvan!');
          this.proizvodiForm.reset();
          this.Karakteristike = [];
          this.dataSource = new MatTableDataSource(this.Karakteristike);
        },
        error:()=>{
          alert('Greska prilikom cuvanja proizvoda');
      }
      });
    }else{
      console.log(this.proizvod);
      this.apiService.izmeniProizvod(this.proizvod)
      .subscribe({
        next:(response) =>{
          alert('Proizvod je uspesno izmenjen!');
          this.proizvodiForm.reset();
          this.dialogRef.close('update');
        },
        error:()=>{
          alert('Greska prilikom izmene proizvoda');
      }
    });
    }

    
  }

  obrisiKarakteristiku(element:any){
    console.log(element);
    
    for(var i = 0; i<this.Karakteristike.length; i++){
      if(this.Karakteristike[i].IDKarakteristike === element.IDKarakteristike && this.Karakteristike[i].SifraProizvoda === element.SifraProizvoda){
        console.log('usao sam');
        this.azurirajListu(i);
        this.Karakteristike.splice(i,1);
        this.dataSource = new MatTableDataSource(this.Karakteristike);
        return;
      }
    }
    
  }

  azurirajListu(redniBroj:number){
    for(var i = redniBroj + 1; i < this.Karakteristike.length; i++){
      this.Karakteristike[i].IDKarakteristike--;
    }
    this.brojac--;
  }

  izmeniKarakteristiku(element:any){
      this.apiService.setVrednost(element.Vrednost);
      this.apiService.setNaziv(element.NazivKarakteristike);
    this.dialog.open(KarakteristikaComponent, {
      width:'30%',
      data:element
    }).afterClosed().subscribe(res =>{
      if(res === 'save'){
        console.log(this.apiService.getNazivKarakteristike());
        console.log(this.apiService.getVrednost());

        for(var i = 0; i<this.Karakteristike.length; i++){
          if(this.Karakteristike[i].IDKarakteristike === element.IDKarakteristike && this.Karakteristike[i].SifraProizvoda === element.SifraProizvoda){
          this.Karakteristike[i].NazivKarakteristike = this.apiService.getNazivKarakteristike();
          this.Karakteristike[i].Vrednost = this.apiService.getVrednost();
          return;
        }
      }

    }
    });

    

  }

}

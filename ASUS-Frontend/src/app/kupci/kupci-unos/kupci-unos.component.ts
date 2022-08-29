import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Drzava } from 'src/app/_model/drzava';
import { Grad } from 'src/app/_model/grad';
import { Kupac } from 'src/app/_model/kupac';
import { ApiService } from 'src/app/_services/api.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-kupci-unos',
  templateUrl: './kupci-unos.component.html',
  styleUrls: ['./kupci-unos.component.css']
})
export class KupciUnosComponent implements OnInit {

  drzave!:Drzava[];
  test!:boolean;
  selectedValueDrzava!:Drzava['IDDrzave'];
  selectedValueGrad!:Grad['NazivGrada'];
  Gradovi!:Grad[];
  GradoviFront!:Grad[];
  kupciForm!:FormGroup;
  kupac:Kupac = {
    PIB:0,
    NazivKupca:"",
    UlicaBroj:"",
    IDDrzave:0,
    PostanskiBroj:0,
    Grad: {PostanskiBroj:0, IDDrzave:0, NazivGrada:""},
    Drzava: {IDDrzave:0, NazivDrzave:"", Gradovi:this.Gradovi}
  };

  actionBtn: string = "Sacuvaj";
  izmena:boolean = false;
  naslov:string = "Unos novog kupca";

  testDrzava:Drzava = {
    IDDrzave:0,
    NazivDrzave:"kjsdf",
    Gradovi:this.Gradovi
  }
  

  constructor(private apiService:ApiService, private formBuilder:FormBuilder, private dialogRef:MatDialogRef<KupciUnosComponent>, 
              @Inject(MAT_DIALOG_DATA) public editData : any) { }

  ngOnInit(): void {
    this.apiService.vratiDrzave().subscribe(response =>{
      //console.log(response);
      this.drzave = response;
      console.log(this.drzave);
    });

    //console.log(this.drzave);
    
    this.kupciForm = this.formBuilder.group({
      PIB : ['', Validators.required],
      NazivKupca : ['', Validators.required],
      Drzava : ['', Validators.required],
      Grad : ['', Validators.required],
      adresa : ['', Validators.required]
    });

    //console.log(this.editData);
    
    if(this.editData){
      console.log(this.editData);
      this.izmena = true;
      this.actionBtn = "Izmeni";
      this.naslov = "Izmena kupca";
      this.selectedValueDrzava = this.editData.Drzava.IDDrzave;
      this.vratiGradove();
      this.kupciForm.controls["PIB"].setValue(this.editData.PIB);
      this.kupciForm.controls["NazivKupca"].setValue(this.editData.NazivKupca);
      this.kupciForm.controls["adresa"].setValue(this.editData.UlicaBroj);
      this.kupciForm.controls["Drzava"].setValue(this.editData.Drzava.IDDrzave);
      this.kupciForm.controls["Grad"].setValue(this.editData.Grad.NazivGrada);
      this.kupciForm.controls["PIB"].setValue(this.editData.PIB);
    }
    
  }

  vratiGradove(){
    console.log("ulazim");
    console.log(this.selectedValueDrzava);
    this.apiService.vratiGradove(this.selectedValueDrzava).subscribe(response =>{
       this.Gradovi = response;
       console.log(this.Gradovi);
    })
    //this.Gradovi = this.selectedValueDrzava.Gradovi;
  }

  ispisi(){
    console.log(this.selectedValueGrad);
  }

  sacuvajKupca(){

    if(this.kupciForm.value["PIB"] === '' || this.kupciForm.value["PIB"] == null 
        || this.kupciForm.value["NazivKupca"] ==='' 
        || this.kupciForm.value["adresa"] === ''
        || this.kupciForm.value["Drzava"] === ''
        || this.kupciForm.value["Grad"] === ''){
          alert("Morate popuniti sva obavezna polja!")
          return;
        }
    
        if(this.kupciForm.value["PIB"] <= 0){
          alert("PIB mora biti pozitivan!");
          return;
         }

        console.log(this.kupciForm.value["Grad"] === '');
        console.log(this.kupciForm.value["Drzava"] === '');

      this.kupac.PIB = this.kupciForm.value["PIB"];
      this.kupac.NazivKupca = this.kupciForm.value["NazivKupca"];
      this.kupac.Grad = this.Gradovi.filter(Grad => Grad.NazivGrada === this.kupciForm.value["Grad"])[0];
      this.kupac.Drzava = this.drzave.filter(Drzava => Drzava.IDDrzave === this.kupciForm.value["Drzava"])[0];
      //this.kupac.Grad.Drzava.Gradovi = nu;
      this.kupac.IDDrzave = this.kupac.Grad.IDDrzave;
      this.kupac.PostanskiBroj = this.kupac.Grad.PostanskiBroj;
      this.kupac.UlicaBroj = this.kupciForm.value["adresa"];
  
      console.log(this.kupac);

    if(!this.editData){
      if(this.kupciForm.valid){
        this.apiService.unesiKupca(this.kupac)
        .subscribe({
          next:(result)=>{
            alert("Kupac je uspesno unesen!");
            this.kupciForm.reset();
            this.dialogRef.close('save');
          },
          error:(err)=>{
            console.log(err.error);
            alert(err.error);
          }
        })
      }
    }else{
      this.apiService.izmeniKupca(this.kupac, this.kupac.PIB)
      .subscribe({
        next:(result)=>{
          alert("Kupac je uspesno izmenjen!");
          this.kupciForm.reset();
          this.dialogRef.close('update');
        },
        error:(err)=>{
          
          alert("Greska prilikom izmene kupca!");
        }
      })
    }
    
  }

  

}

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
  selectedValueDrzava!:Drzava;
  selectedValueGrad!:Grad;
  gradovi!:Grad[];
  gradoviFront!:Grad[];
  kupciForm!:FormGroup;
  kupac:Kupac = {
    pib:0,
    nazivKupca:"",
    ulicaBroj:"",
    idDrzave:0,
    postanskiBroj:0,
    grad: {postanskiBroj:0, idDrzave:0, nazivGrada:""},
    drzava: {idDrzave:0, nazivDrzave:"", gradovi:this.gradovi}
  };
  actionBtn: string = "Sacuvaj";
  

  constructor(private apiService:ApiService, private formBuilder:FormBuilder, private dialogRef:MatDialogRef<KupciUnosComponent>, 
              @Inject(MAT_DIALOG_DATA) public editData : any) { }

  ngOnInit(): void {
    this.apiService.vratiDrzave().subscribe(response =>{
      this.drzave = response;
    });
    
    this.kupciForm = this.formBuilder.group({
      pib : ['', Validators.required],
      nazivKupca : ['', Validators.required],
      drzava : ['', Validators.required],
      grad : ['', Validators.required],
      adresa : ['', Validators.required]
    });

    //console.log(this.editData);

    if(this.editData){
      console.log(this.editData);
      this.actionBtn = "Izmeni";
      this.kupciForm.controls["pib"].setValue(this.editData.pib);
      this.kupciForm.controls["nazivKupca"].setValue(this.editData.nazivKupca);
      this.kupciForm.controls["adresa"].setValue(this.editData.ulicaBroj);
      this.kupciForm.controls["drzava"].setValue(this.editData.drzava);
      this.selectedValueDrzava = this.editData.drzava;
      this.kupciForm.controls["grad"].setValue(this.editData.grad);
      this.kupciForm.controls["pib"].setValue(this.editData.pib);
    }
    
  }

  vratiGradove(){
    console.log("ulazim");
    console.log(this.selectedValueDrzava);
    this.apiService.vratiGradove(this.selectedValueDrzava.idDrzave).subscribe(response =>{
       this.gradovi = response;
    })
    //this.gradovi = this.selectedValueDrzava.gradovi;
  }

  ispisi(){
    console.log(this.selectedValueGrad);
  }

  sacuvajKupca(){

    this.kupac.pib = this.kupciForm.value["pib"];
      this.kupac.nazivKupca = this.kupciForm.value["nazivKupca"];
      this.kupac.grad = this.kupciForm.value["grad"];
      this.kupac.drzava = this.kupciForm.value["drzava"];
      //this.kupac.grad.drzava.gradovi = nu;
      this.kupac.idDrzave = this.kupac.grad.idDrzave;
      this.kupac.postanskiBroj = this.kupac.grad.postanskiBroj;
      this.kupac.ulicaBroj = this.kupciForm.value["adresa"];
  
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
          error:()=>{
            alert("Greska prilikom unosa kupca!");
          }
        })
      }
    }else{
      this.apiService.izmeniKupca(this.kupac, this.kupac.pib)
      .subscribe({
        next:(result)=>{
          alert("Kupac je uspesno izmenjen!");
          this.kupciForm.reset();
          this.dialogRef.close('update');
        },
        error:()=>{
          alert("Greska prilikom izmene kupca!");
        }
      })
    }
    
  }

  

}

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Drzava } from 'src/app/_model/drzava';
import { Grad } from 'src/app/_model/grad';
import { Kupac } from 'src/app/_model/kupac';
import { ApiService } from 'src/app/_services/api.service';
import { MatDialogRef } from '@angular/material/dialog';

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
    ulicaIBroj:"",
    idDrzave:0,
    postanskiBroj:0,
    grad: {postanskiBroj:0, idDrzave:0, nazivGrada:"", drzava:{idDrzave:0, nazivDrzave:""}}
  };
  

  constructor(private apiService:ApiService, private formBuilder:FormBuilder, private dialogRef:MatDialogRef<KupciUnosComponent>) { }

  ngOnInit(): void {
    this.kupciForm = this.formBuilder.group({
      pib : ['', Validators.required],
      nazivKupca : ['', Validators.required],
      drzava : ['', Validators.required],
      grad : ['', Validators.required],
      adresa : ['', Validators.required]
    })
    this.apiService.vratiDrzave().subscribe(response =>{
      this.drzave = response;
    });
  }

  vratiGradove(){
    console.log("ulazim");
    console.log(this.selectedValueDrzava);
    this.apiService.vratiGradove(this.selectedValueDrzava.idDrzave).subscribe(response =>{
       this.gradovi = response;
    })
  }

  ispisi(){
    console.log(this.selectedValueGrad);
  }

  sacuvajKupca(){
    console.log(typeof(this.kupciForm.value["pib"]));
    
    this.kupac.pib = this.kupciForm.value["pib"];
    this.kupac.nazivKupca = this.kupciForm.value["nazivKupca"];
    this.kupac.grad = this.kupciForm.value["grad"];
    //this.kupac.grad.drzava = this.kupciForm.value["drzava"];
    this.kupac.grad.drzava = {idDrzave:1, nazivDrzave:"Srbija"}
    this.kupac.idDrzave = this.kupac.grad.idDrzave;
    this.kupac.postanskiBroj = this.kupac.grad.postanskiBroj;

    console.log(this.kupac);

    //moj nacin
    /*this.apiService.unesiKupca(this.kupac).subscribe(response =>{
      console.log("Uspesno");
    },
      (error) => {
        console.log("neuspesno");
    });*/

    //nov nacin
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

  }

}

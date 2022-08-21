import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Karakteristika } from '../_model/karakteristika';
import { ApiService } from '../_services/api.service';

@Component({
  selector: 'app-karakteristika',
  templateUrl: './karakteristika.component.html',
  styleUrls: ['./karakteristika.component.css']
})
export class KarakteristikaComponent implements OnInit {

  @Input() karakteristika:Karakteristika = {
    idKarakteristike:0,
    sifraProizvoda:0,
    vrednost:0,
    nazivKarakteristike:""
  };

  karakteristikaForm!:FormGroup;

  constructor(private dialogRef : MatDialogRef<KarakteristikaComponent>, 
    @Inject(MAT_DIALOG_DATA) public editData:any,
    private formBuilder:FormBuilder,
    private apiService:ApiService) { }


  ngOnInit(): void {

    this.karakteristikaForm = this.formBuilder.group({
      nazivKarakteristike:['', Validators.required],
      vrednost:['', Validators.required]
    });

    if(this.editData){

      this.karakteristikaForm.controls["nazivKarakteristike"].setValue(this.editData.nazivKarakteristike);
      this.karakteristikaForm.controls["vrednost"].setValue(this.editData.vrednost);

      this.karakteristika.idKarakteristike = this.editData.idKarakteristike;
      this.karakteristika.sifraProizvoda = this.editData.sifraProizvoda;
      this.karakteristika.nazivKarakteristike = this.editData.nazivKarakteristike;
      this.karakteristika.vrednost = this.editData.vrednost;
    }
  }

  izmeniKarakteristiku(){
    this.apiService.setVrednost(this.karakteristikaForm.value["vrednost"]);
    this.apiService.setNaziv(this.karakteristikaForm.value["nazivKarakteristike"]);

    this.dialogRef.close();

  }

}

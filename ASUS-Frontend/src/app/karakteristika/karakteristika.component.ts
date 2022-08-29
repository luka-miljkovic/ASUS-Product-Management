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
    IDKarakteristike:0,
    SifraProizvoda:0,
    Vrednost:0,
    NazivKarakteristike:""
  };

  karakteristikaForm!:FormGroup;
  naslov:string = "Unos nove karakteristike"

  constructor(private dialogRef : MatDialogRef<KarakteristikaComponent>, 
    @Inject(MAT_DIALOG_DATA) public editData:any,
    private formBuilder:FormBuilder,
    private apiService:ApiService) { }


  ngOnInit(): void {

    this.karakteristikaForm = this.formBuilder.group({
      NazivKarakteristike:['', Validators.required],
      Vrednost:['', Validators.required]
    });

    if(this.editData){
      this.naslov = "Izmena karakteristike"

      this.karakteristikaForm.controls["NazivKarakteristike"].setValue(this.editData.NazivKarakteristike);
      this.karakteristikaForm.controls["Vrednost"].setValue(this.editData.Vrednost);

      this.karakteristika.IDKarakteristike = this.editData.IDKarakteristike;
      this.karakteristika.SifraProizvoda = this.editData.SifraProizvoda;
      this.karakteristika.NazivKarakteristike = this.editData.NazivKarakteristike;
      this.karakteristika.Vrednost = this.editData.Vrednost;
    }
  }

  izmeniKarakteristiku(){
    if(this.karakteristikaForm.value["Vrednost"] === '' || this.karakteristikaForm.value["Vrednost"] === null
     || this.karakteristikaForm.value["NazivKarakteristike"] === ''){
      alert("Morate popuniti sva obavezna polja!");
      return;
     }
     if(this.karakteristikaForm.value["Vrednost"] < 0){
      alert("Vrednost karakteristike mora biti pozitivna!");
      return;
     }
    this.apiService.setVrednost(this.karakteristikaForm.value["Vrednost"]);
    this.apiService.setNaziv(this.karakteristikaForm.value["NazivKarakteristike"]);

    this.dialogRef.close('save');

  }

  zatvoriDialog(){
    this.dialogRef.close('cancel');
  }

}

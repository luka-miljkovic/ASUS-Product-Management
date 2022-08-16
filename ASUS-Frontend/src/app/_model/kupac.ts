import { Drzava } from "./drzava";
import { Grad } from "./grad";

export interface Kupac {
    pib:number,
    nazivKupca:string,
    ulicaBroj:string,
    idDrzave:number,
    postanskiBroj:number,
    grad:Grad,
    drzava: Drzava
}

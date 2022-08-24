import { Drzava } from "./drzava";
import { Grad } from "./grad";

export interface Kupac {
    PIB:number,
    NazivKupca:string,
    UlicaBroj:string,
    IDDrzave:number,
    PostanskiBroj:number,
    Grad:Grad,
    Drzava: Drzava
}

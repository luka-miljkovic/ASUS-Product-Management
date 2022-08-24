import { Karakteristika } from "./karakteristika";

export interface Proizvod {
    SifraProizvoda:number,
    NazivModela:string,
    Karakteristike:Karakteristika[]
}

using AutoMapper;
using Model.DataTransferObject;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AsusMapper : Profile
    {
        public AsusMapper()
        {
            CreateMap<Kupac, KupacDTO>();
            CreateMap<Proizvod, ProizvodDTO>().ForMember(dest => dest.Karakteristike, opt => opt.MapFrom(MapProizvodKarakteristika)).ReverseMap();
            CreateMap<Drzava, DrzavaDTO>().ForMember(dest => dest.Gradovi, opt => opt.MapFrom(MapDrzavaGrad)).ReverseMap();
            CreateMap<Grad, GradDTO>().ReverseMap();
            CreateMap<Kupac, KupacDTO>().ForMember(dest => dest.Grad, opt => opt.MapFrom(MapKupacGrad));
            CreateMap<Karakteristika, KarakteristikaDTO>().ReverseMap();
            //CreateMap<Grad, GradDTO>().ForMember(dest=>dest.Kupci, opt=>opt.MapFrom(src=>src.Kupci.Select(x=>new GradDTO
            //{
            //    PostanskiBroj = x.Grad.PostanskiBroj,
            //    IDDrzave = x.Grad.IDDrzave
            //}))).ReverseMap();
        }

        private List<GradDTO> MapDrzavaGrad(Drzava drzava, DrzavaDTO drzavaDTO)
        {
            var result = new List<GradDTO>();
            if(drzava.Gradovi != null)
            {
                foreach(var grad in drzava.Gradovi)
                {
                    result.Add(new GradDTO
                    {
                        PostanskiBroj = grad.PostanskiBroj,
                        IDDrzave = drzava.IDDrzave,
                        NazivGrada = grad.NazivGrada,
                        //Drzava = new DrzavaDTO
                        //{
                        //    IDDrzave = drzava.IDDrzave,
                        //    NazivDrzave = drzava.NazivDrzave
                        //}
                    });
                }
            }
            return result;
        }

        private GradDTO MapKupacGrad(Kupac kupac, KupacDTO kupacDTO)
        {
            GradDTO result = null;
            if(kupac.Grad != null)
            {
                result = new GradDTO
                {
                    PostanskiBroj = kupac.Grad.PostanskiBroj,
                    IDDrzave = kupac.Grad.IDDrzave,
                    NazivGrada = kupac.Grad.NazivGrada
                };
            }
            return result;
        }

        private List<KarakteristikaDTO> MapProizvodKarakteristika(Proizvod proizvod, ProizvodDTO proizvodDTO)
        {
            var result = new List<KarakteristikaDTO>();
            foreach(var item in proizvod.Karakteristike)
            {
                KarakteristikaDTO karakteristika = new KarakteristikaDTO
                {
                    IDKarakteristike = item.IDKarakteristike,
                    SifraProizvoda = item.SifraProizvoda,
                    NazivKarakteristike = item.NazivKarakteristike,
                    Vrednost = item.Vrednost
                };
                result.Add(karakteristika);
            }

            return result;
        }


    }
}

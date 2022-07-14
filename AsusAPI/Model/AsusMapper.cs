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
            CreateMap<Proizvod, ProizvodDTO>();
            CreateMap<Drzava, DrzavaDTO>().ForMember(dest => dest.Gradovi, opt => opt.MapFrom(MapDrzavaGrad));
            CreateMap<Grad, GradDTO>().ReverseMap();
            CreateMap<Kupac, KupacDTO>().ForMember(dest => dest.Grad, opt => opt.MapFrom(MapKupacGrad));
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
                        NazivGrada = grad.NazivGrada
                    });
                }
            }
            return result;
        }

        private GradDTO MapKupacGrad(Kupac kupac, KupacDTO kupacDTp)
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

    }
}

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
        }

    }
}

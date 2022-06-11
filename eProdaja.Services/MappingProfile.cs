using AutoMapper;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnici, Model.Korisnici>();

            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>();
            CreateMap<Database.Uloge, Model.Uloge>();

            CreateMap<KorisniciInsertRequest, Database.Korisnici>();
            CreateMap<KorisniciUpdateRequest, Database.Korisnici>();

            CreateMap<Database.Proizvodi, Model.Proizvodi>();
            CreateMap<Database.JediniceMjere, Model.JediniceMjere>();

            CreateMap<JediniceMjereUpsertRequest, Database.JediniceMjere>();

            CreateMap<ProizvodiInsertRequest, Database.Proizvodi>();
            CreateMap<ProizvodiUpdateRequest, Database.Proizvodi>();


            CreateMap<Database.VrsteProizvodum, Model.VrsteProizvodum>();
            CreateMap<VrsteProizvodumUpsertRequest, Database.VrsteProizvodum>();


            CreateMap<Database.Narudzbe, Model.Narudzbe>();
            CreateMap<NarudzbaInsertRequest, Database.Narudzbe>();
            CreateMap<NarudzbaUpdateRequest, Database.Narudzbe>();
        }
    }
}

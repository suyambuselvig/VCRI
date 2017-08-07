using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;


// For Mapping
namespace VCRI.Mappers
{
    public class VCRIAutomapperProfile : Profile
    {
        public VCRIAutomapperProfile()
        {
           CreateMap<VCR_DAL.Transaction, Models.Transaction>()
                .ForMember(dos => dos.uname, map => map.MapFrom(name => name.Login.username))
                .ForMember(dos => dos.drugname, map => map.MapFrom(name => name.Drug.Drug_Name))
                .ReverseMap();


            CreateMap<VCR_DAL.Drug, Models.Drug>().ReverseMap();

            CreateMap<Models.Transaction, VCR_DAL.Transaction>();

        }
    }
}

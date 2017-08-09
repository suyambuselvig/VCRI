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
            //For Transaction
           CreateMap<VCRI_DAL.Transaction, Models.Transaction>()
                .ForMember(dos => dos.uname, map => map.MapFrom(name => name.ULogin.user_Name))
                .ForMember(dos => dos.drugname, map => map.MapFrom(name => name.Drug.drug_Name))
                .ReverseMap();


            CreateMap<VCRI_DAL.Drug, Models.Drug>().ReverseMap();

            CreateMap<VCRI_DAL.ULogin, Models.ULogin>();


        }
    }
}

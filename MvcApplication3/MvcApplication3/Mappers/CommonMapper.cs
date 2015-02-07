using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MvcApplication3.Models;
using MvcApplication3.Models.ModelViews;


namespace MvcApplication3.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<MvcApplication3.Models.User, UserView>()
                      .ForMember(dest => dest.BirthdateDay, opt => opt.MapFrom(src => src.Birthdate.Day))
                      .ForMember(dest => dest.BirthdateMonth, opt => opt.MapFrom(src => src.Birthdate.Month))
                      .ForMember(dest => dest.BirthdateYear, opt => opt.MapFrom(src => src.Birthdate.Year));
            Mapper.CreateMap<UserView, MvcApplication3.Models.User>()
                    .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => new DateTime(src.BirthdateYear, src.BirthdateMonth, src.BirthdateDay)));
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
           // try
           // {
                return Mapper.Map(source, sourceType, destinationType);
           /* }
            catch (AutoMapper.AutoMapperMappingException e)
            {

                return Mapper.Map(source, sourceType, destinationType);    //очень стыдно за такое.
            }*/
        }
    }
}
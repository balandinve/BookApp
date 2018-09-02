
using AutoMapper;
using BookApp.Models.Domain;
using BookApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg => {
                // domain -> dto
                cfg.CreateMap<Book, BookDto>();
                cfg.CreateMap<Person, PersonDto>();
                cfg.CreateMap<PersonBook, PersonBookDto>();

                // dto -> domain
                cfg.CreateMap<BookDto, Book>();
                cfg.CreateMap<PersonDto, Person>();
                cfg.CreateMap<PersonBookDto, PersonBook>();
            });
        }
    }
}

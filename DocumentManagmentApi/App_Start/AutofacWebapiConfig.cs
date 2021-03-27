﻿using Autofac;
using Autofac.Integration.WebApi;
using DocumentManagementBLL;
using DocumentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace DocumentManagmentApi
{
  public class AutofacWebapiConfig
  {
    public static IContainer Container;

    public static void Initialize(HttpConfiguration config)
    {
      Initialize(config, RegisterServices(new ContainerBuilder()));
    }


    public static void Initialize(HttpConfiguration config, IContainer container)
    {
      config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }

    private static IContainer RegisterServices(ContainerBuilder builder)
    {
      //Register your Web API controllers.  
      builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

      builder.RegisterType<UserRepository>().As<IUserRepository>();
      builder.RegisterType<UserService>().As<IUserService>();
      builder.RegisterType<DocumentService>().As<IDocumentService>();
      builder.RegisterType<DocumentRepository>().As<IDocumentRepository>();
      //Set the dependency resolver to be Autofac.  
      Container = builder.Build();

      return Container;
    }

  }
}
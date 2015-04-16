using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Framework;
using EPiServer.ServiceLocation;
using System.Web.Mvc;
using EPiServer.Framework.Initialization;

namespace EPiCenterBaseProject.Business.AppStart
{
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    [InitializableModule]
    public class StructureMapConfiguration : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(
              component =>
              {

              });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.Container));
        }

        public void Initialize(InitializationEngine context) { }
        public void Preload(string[] parameters) { }
        public void Uninitialize(InitializationEngine context) { }
    }
}
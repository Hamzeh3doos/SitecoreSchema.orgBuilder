#region GlassMapperSc generated code
/*************************************

DO NOT CHANGE THIS FILE - UPDATE GlassMapperScCustom.cs

**************************************/

using Glass.Mapper.Maps;
using Glass.Mapper.Sc.Configuration.Fluent;
using Glass.Mapper.Sc.IoC;
using Glass.Mapper.Sc.Pipelines.GetChromeData;
using Sitecore.Pipelines;
using System.Linq;
using GM = Glass.Mapper;

// WebActivator has been removed. If you wish to continue using WebActivator uncomment the line below
// and delete the Glass.Mapper.Sc.CastleWindsor.config file from the Sitecore Config Include folder.
// [assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Common.Foundation.Glass.App_Start.GlassMapperSc), "Start")]

namespace Common.Foundation.Glass.App_Start
{
    public class GlassMapperSc
    {
        public void Process(PipelineArgs args)
        {
            GlassMapperSc.Start();
        }

        public static void Start()
        {
            //install the custom services
            var resolver = GlassMapperScCustom.CreateResolver();

            //create a context
            var context = GM.Context.Create(resolver);

            GlassMapperScCustom.RegisterCustomDataHandlers(resolver);
            LoadConfigurationMaps(resolver, context);

            context.Load(
                GlassMapperScCustom.GlassLoaders()
                );

            GlassMapperScCustom.PostLoad();

            //EditFrameBuilder.EditFrameItemPrefix = "Glass-";
        }

        public static void LoadConfigurationMaps(IDependencyResolver resolver, GM.Context context)
        {
            var dependencyResolver = resolver as DependencyResolver;
            if (dependencyResolver == null)
            {
                return;
            }

            if (dependencyResolver.ConfigurationMapFactory is ConfigurationMapConfigFactory)
            {
                GlassMapperScCustom.AddMaps(dependencyResolver.ConfigurationMapFactory);
            }

            IConfigurationMap configurationMap = new ConfigurationMap(dependencyResolver);
            SitecoreFluentConfigurationLoader configurationLoader = configurationMap.GetConfigurationLoader<SitecoreFluentConfigurationLoader>();
            context.Load(configurationLoader);
        }

    }
}
#endregion
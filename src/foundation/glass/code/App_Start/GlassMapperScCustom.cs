#region GlassMapperScCustom generated code
using Glass.Mapper.Configuration;
using Glass.Mapper.Configuration.Attributes;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc.IoC;
using System.Collections.Generic;
using System.Linq;
using GM = Glass.Mapper;
using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

namespace Common.Foundation.Glass.App_Start
{
    public static class GlassMapperScCustom
    {
        public static IDependencyResolver CreateResolver()
        {
            var config = new GM.Sc.Config();

            var dependencyResolver = new DependencyResolver(config);
            // add any changes to the standard resolver here
            return dependencyResolver;
        }

        public static IConfigurationLoader[] GlassLoaders()
        {

            /* USE THIS AREA TO ADD FLUENT CONFIGURATION LOADERS
             * 
             * If you are using Attribute Configuration or automapping/on-demand mapping you don't need to do anything!
             * 
             */
            var loader = IncludeAllModulesViaConfigs() ?? new IConfigurationLoader[] { };

            return loader;
        }
        public static void PostLoad()
        {
            //Remove the comments to activate CodeFist
            /* CODE FIRST START
            var dbs = Sitecore.Configuration.Factory.GetDatabases();
            foreach (var db in dbs)
            {
                var provider = db.GetDataProviders().FirstOrDefault(x => x is GlassDataProvider) as GlassDataProvider;
                if (provider != null)
                {
                    using (new SecurityDisabler())
                    {
                        provider.Initialise(db);
                    }
                }
            }
             * CODE FIRST END
             */
        }
        public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
        {
            // Add maps here
            // mapsConfigFactory.Add(() => new SeoMap());
        }

        // #######################################################################################################
        //// CUSTOM ADDITIONS TO AGGREGATE MODULES
        // #######################################################################################################

        /// <summary>
        /// Register dlls from glass modules via XML to aggregate here
        /// </summary>
        /// <returns></returns>
        public static IConfigurationLoader[] IncludeAllModulesViaConfigs()
        {

            /* USE THIS AREA TO ADD FLUENT CONFIGURATION LOADERS
             * 
             * If you are using Attribute Configuration or automapping/on-demand mapping you don't need to do anything!
             * 
             */

            var attributes = new List<AttributeConfigurationLoader>();

            Sitecore.Diagnostics.Log.Info(string.Format("Common.Foundation.Glass: Processing {0} dlls...", Configuration.Glass.Dlls.Count), "Common.Foundation.Glass");
            // Handle config patched glass mappings
            foreach (var dll in Configuration.Glass.Dlls)
            {
                Sitecore.Diagnostics.Log.Info(string.Format("Common.Foundation.Glass: Registering {0}", dll), "Common.Foundation.Glass");
                attributes.Add(new AttributeConfigurationLoader(dll));
            }

            return attributes.Cast<IConfigurationLoader>().ToArray();
        }

        /// <summary>
        /// Register Custom Glass Field Handlers
        /// </summary>
        /// <param name="resolver"></param>
        public static void RegisterCustomDataHandlers(IDependencyResolver resolver)
        {

            if (!Configuration.GlassField.Handlers.Any())
            {
                Sitecore.Diagnostics.Log.Info("Common.Foundation.Glass: Field handlers skipped (none registered)",
                    "Common.Foundation.Glass");
            }
            else
            {
                Sitecore.Diagnostics.Log.Info(
                    string.Format("Common.Foundation.Glass: Processing {0} field handlers...",
                        Configuration.GlassField.Handlers.Count), "Common.Foundation.Glass");

                foreach (var handler in Configuration.GlassField.Handlers)
                {
                    Sitecore.Diagnostics.Log.Info(string.Format("Common.Foundation.Glass: Registering {0}", handler.ToString()),
                        "Common.Foundation.Glass");

                    var handler1 = handler;
                    resolver.DataMapperFactory.Insert(0, () => handler1);

                }
            }
        }
    }
}
#endregion
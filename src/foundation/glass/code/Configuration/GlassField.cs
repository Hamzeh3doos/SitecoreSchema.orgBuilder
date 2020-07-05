using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.DataMappers;
using Common.Foundation.Utilities.Configuration;

namespace Common.Foundation.Glass.Configuration
{
    public static class GlassField
    {
        // Thread safe, lazy loaded
        private static readonly Lazy<List<AbstractSitecoreFieldMapper>> handlers
              = new Lazy<List<AbstractSitecoreFieldMapper>>(
                 () => Utility.ParseListOfType<AbstractSitecoreFieldMapper>("foundation/glassHandlers", "type")
              );

        public static List<AbstractSitecoreFieldMapper> Handlers { get { return handlers.Value; } }
    }
}
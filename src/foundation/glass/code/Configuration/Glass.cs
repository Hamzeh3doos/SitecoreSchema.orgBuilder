using System;
using System.Collections.Generic;
using Common.Foundation.Utilities.Configuration;

namespace Common.Foundation.Glass.Configuration
{
    public static class Glass
    {
        // Thread safe, lazy loaded
        private static readonly Lazy<List<String>> dlls
              = new Lazy<List<String>>(
                 () => Utility.ParseList("foundation/glass", "dll")
              );

        public static List<String> Dlls { get { return dlls.Value; } }
    }
}
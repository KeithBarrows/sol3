﻿//using Microsoft.AspNetCore.Mvc.Razor;
//using System.Collections.Generic;

// /*
//  * https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/
//  */

//namespace Sol3.Framework.Infrastructure.FeatureFolders
//{
//    public class FeatureLocationExpander : IViewLocationExpander
//    {
//        public void PopulateValues(ViewLocationExpanderContext context)
//        {
//            // Don't need anything here, but required by the interface
//        }

//        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
//        {
//            // The old locations are /Views/{1}/{0}.cshtml and /Views/Shared/{0}.cshtml where {1} is the controller and {0} is the name of the View
//            // Replace /Views with /Features
//            return new string[] { "/Features/{1}/{0}.cshtml", "/Features/Shared/{0}.cshtml" };
//        }
//    }
//}

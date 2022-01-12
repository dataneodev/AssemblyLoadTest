using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string libVersion = null;
        public App()
        {
            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            }
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            => Assembly.LoadFrom(Path.Combine("dll", GetLibVersion(), "LibTest.dll"));

        private static string GetLibVersion()
        {
            if (libVersion is null)
            {
                libVersion = GetLibVersionFromUser();
            }

            return libVersion;
        }

        private static string GetLibVersionFromUser()
        {
            AppDomain resolverDomain = AppDomain.CreateDomain("resolverDomain");
            var typ = typeof(VersionResolver);

            var remoteWorker = (VersionResolver)resolverDomain.CreateInstanceAndUnwrap(
                typ.Assembly.FullName,
                typ.FullName);

            return remoteWorker.GetLibVersion();
        }
    }
}

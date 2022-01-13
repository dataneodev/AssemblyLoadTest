using System;
using System.IO;
using System.Reflection;
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
        {
            if (args.Name.StartsWith("LibTest"))
                return Assembly.LoadFrom(Path.Combine("dll", GetLibVersion(), "LibTest.dll"));

            if (args.Name.StartsWith("Tekla"))
            {
                string shortName = new AssemblyName(args.Name).Name;

                var dllPath = Path.Combine("dll", GetLibVersion(), $"{shortName}.dll");
                if (File.Exists(dllPath))
                    return Assembly.LoadFrom(dllPath);
            }
            return null;

        }

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

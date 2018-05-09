namespace CertifCooker.Helpers
{
    using System.Reflection;

    internal static class AssemblyHelper
    {
        public static string GetExecutingAssembly(int length)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version;

            return version.ToString().Substring(0, length);
        }
    }
}
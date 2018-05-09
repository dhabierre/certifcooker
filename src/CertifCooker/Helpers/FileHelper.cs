namespace CertifCooker.Helpers
{
    using System;
    using System.IO;

    internal static class FileHelper
    {
        public static void TryDelete(string path, bool throwsException = false)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception)
            {
                if (throwsException)
                {
                    throw;
                }
            }
        }
    }
}
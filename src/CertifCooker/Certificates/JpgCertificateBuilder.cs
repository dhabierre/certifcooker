namespace CertifCooker.Certificates
{
    using System;
    using System.IO;
    using CertifCooker.Helpers;
    using CertifCooker.Models;

    internal class JpgCertificateBuilder : ICertificateBuilder
    {
        public string Build(CertificateData data)
        {
            var userPath = GetUserPath();

            var filePath = Path.Combine(
                userPath,
                $"Certificate-{data.Fullname.Replace(' ', '-')}-{DateTime.Now.ToString("yyyyMMddss")}.{FileFormat.Jpg}");

            CertificateHelper.CreateCertificate(data, filePath);

            return filePath;
        }

        private static string GetUserPath()
        {
            var userPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"CertifCooker\Certificates");

            if (!Directory.Exists(userPath))
            {
                Directory.CreateDirectory(userPath);
            }

            return userPath;
        }
    }
}
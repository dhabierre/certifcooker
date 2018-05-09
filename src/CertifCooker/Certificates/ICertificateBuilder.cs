namespace CertifCooker.Certificates
{
    using CertifCooker.Models;

    internal interface ICertificateBuilder
    {
        string Build(CertificateData data);
    }
}
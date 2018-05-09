namespace CertifCooker.Certificates
{
    internal static class CertificateBuilderFactory
    {
        public static ICertificateBuilder CreateJpg() => new JpgCertificateBuilder();

        public static ICertificateBuilder CreatePdf() => new PdfCertificateBuilder(new JpgCertificateBuilder());
    }
}
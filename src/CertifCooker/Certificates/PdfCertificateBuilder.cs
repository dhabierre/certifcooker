namespace CertifCooker.Certificates
{
    using System;
    using System.IO;
    using CertifCooker.Helpers;
    using CertifCooker.Models;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;

    internal class PdfCertificateBuilder : ICertificateBuilder
    {
        private readonly JpgCertificateBuilder jpgCertificateBuilder;

        public PdfCertificateBuilder(JpgCertificateBuilder jpgCertificateBuilder)
        {
            this.jpgCertificateBuilder = jpgCertificateBuilder ?? throw new ArgumentNullException(nameof(jpgCertificateBuilder));
        }

        public string Build(CertificateData data)
        {
            var jpgPath = this.jpgCertificateBuilder.Build(data);
            var pdfPath = BuildPdf(jpgPath);

            return pdfPath;
        }

        public static string BuildPdf(string imageSource)
        {
            var pdfDestination = Path.Combine(
                Path.GetDirectoryName(imageSource),
                Path.ChangeExtension(imageSource, FileFormat.Pdf));

            var dimension = new ImageDimension(imageSource);

            using (var doc = new PdfDocument())
            {
                doc.Pages.Add(new PdfPage { Height = dimension.Height, Width = dimension.Width });

                using (var xGraphics = XGraphics.FromPdfPage(doc.Pages[0]))
                using (var xImage = XImage.FromFile(imageSource))
                {
                    xGraphics.DrawImage(xImage, 0, 0, dimension.Width, dimension.Height);
                    doc.Save(pdfDestination);
                }
            }

            FileHelper.TryDelete(imageSource);

            return pdfDestination;
        }
    }
}
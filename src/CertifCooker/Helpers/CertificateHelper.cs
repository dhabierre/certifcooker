namespace CertifCooker.Helpers
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using CertifCooker.Configuration;
    using CertifCooker.Models;

    internal static class CertificateHelper
    {
        private static readonly string CertificatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data");

        #region [ Public Methods ]

        public static void CreateCertificate(CertificateData certificateData, string outputFilePath)
        {
            var certificates = ConfigurationManager.GetCertificates();
            var certificate = certificates.ElementAt(new Random().Next(0, certificates.Count()) % certificates.Count());
            var certificatePath = Path.Combine(CertificatePath, certificate.Name);

            using (var image = new Bitmap(certificatePath))
            using (var graphics = Graphics.FromImage(image))
            {
                var creationDate = string.Format(certificate.DateText.Value, certificateData.CreationDate.ToString("dddd d MMMM yyyy"));
                var content = string.Format(certificate.ContentText.Value, certificateData.Fullname, (certificateData.IsFemale) ? "e" : null, certificateData.Birthday, certificateData.Activity);

                // Poor quality is voluntary (to degrade the text)

                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.Low;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                graphics.DrawString(
                    creationDate,
                    new Font(certificate.FontFamilyName, certificate.FontSizeEm),
                    Brushes.Black,
                    new RectangleF(
                        certificate.DateText.CoordX,
                        certificate.DateText.CoordY,
                        certificate.DateText.Width,
                        certificate.DateText.Height));

                graphics.DrawString(
                    content,
                    new Font(certificate.FontFamilyName, certificate.FontSizeEm),
                    Brushes.Black,
                    new RectangleF(
                        certificate.ContentText.CoordX,
                        certificate.ContentText.CoordY,
                        certificate.ContentText.Width,
                        certificate.ContentText.Height));

                var rand = new Random();

                var factor = (rand.Next(0, 2) % 2 == 0) ? 1 : -1;
                var rotateAngle = (certificate.RotateAngle - (float)rand.Next(0, 5) / 10) * factor;

                RotateImage(image, graphics, rotateAngle);
                DegradeImage(image);

                SaveCertificate(image, outputFilePath);
            }
        }

        #endregion [ Public Methods ]

        #region [ Private Methods ]

        private static void RotateImage(Bitmap image, Graphics graphics, float angle)
        {
            graphics.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
            graphics.RotateTransform(angle);

            graphics.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
            graphics.DrawImage(image, new Point(0, 0));
        }

        private static void DegradeImage(Bitmap image)
        {
            unchecked
            {
                var rand = new Random();

                for (int w = 0; w < image.Width; w += (w == image.Width - 1) ? 1 : rand.Next(0, 64))
                {
                    for (int h = 0; h < image.Height; h += (h == image.Height - 1) ? 1 : rand.Next(0, 64))
                    {
                        image.SetPixel(w, h, Color.LightGray);
                    }
                }
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            foreach (var codec in ImageCodecInfo.GetImageDecoders())
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }

        private static void SaveCertificate(Bitmap certifImage, string outputFilePath)
        {
            var encoder = GetEncoder(ImageFormat.Jpeg);

            var parameters = new EncoderParameters(1);
            var parameter = new EncoderParameter(Encoder.Quality, 5L); // low quality to simulate document scan

            parameters.Param[0] = parameter;

            certifImage.Save(outputFilePath, encoder, parameters);
        }

        #endregion [ Private Methods ]
    }
}
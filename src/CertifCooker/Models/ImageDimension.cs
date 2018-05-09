namespace CertifCooker.Models
{
    using System.Drawing;

    internal class ImageDimension
    {
        public ImageDimension(string imagePath)
        {
            using (var bitmap = new Bitmap(imagePath))
            {
                this.Height = bitmap.Height;
                this.Width = bitmap.Width;
            }
        }

        public int Height { get; }

        public int Width { get; }
    }
}
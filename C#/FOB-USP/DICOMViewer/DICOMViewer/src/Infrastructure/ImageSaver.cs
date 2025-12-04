using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DICOMViewer.Infrastructure
{
    public class ImageSaver
    {
        public Task SaveAsync(
            System.Collections.Generic.List<Bitmap> images,
            string path,
            int resolution,
            Action<int>? progress,
            CancellationToken token)
        {
            if (images == null || images.Count == 0)
                return Task.CompletedTask;

            return Task.Run(() =>
            {
                var codec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(c => c.FormatID == ImageFormat.Tiff.Guid);
                var encParams = new EncoderParameters(1);
                encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);

                for (int i = 0; i < images.Count; i++)
                {
                    token.ThrowIfCancellationRequested();

                    string filePath = Path.Combine(path, $"Corte_{i + 1:D4}.tif");

                    using var bmp = images[i];
                    bmp.SetResolution(resolution, resolution);

                    if (codec != null)
                        bmp.Save(filePath, codec, encParams);
                    else
                        bmp.Save(filePath, ImageFormat.Tiff);

                    progress?.Invoke(i + 1);
                }
            }, token);
        }
    }
}

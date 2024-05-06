using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Buffers.Text;
using System.IO;
using ZXing;

namespace H.Saas.Tools
{
    public static class ImageHelper
    {
        public static string ToQrCode(this string value, int width = 500, int height = 500)
        {
            var writer = new ZXing.ImageSharp.BarcodeWriter<Rgba32>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = width,
                    Height = height,
                    Margin = 1
                }
            };
            var image = writer.WriteAsImageSharp<Rgba32>(value);
            var ms = new MemoryStream();
            image.Save(ms, new PngEncoder());
            byte[] imageBytes = ms.ToArray();
            var base64String = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public static string SaveImg(string base64Str, string fileName)
        {
            base64Str = base64Str.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "").Replace("data:image/jpng;base64,", "");
            var imageBytes = Convert.FromBase64String(base64Str);
            string path = Directory.GetCurrentDirectory() + "\\file\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filePath = path + fileName;

            using (var image = Image.Load(imageBytes))
            {

                image.Save(filePath);
            }
            return filePath;
        }


        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string sFile, string outPath, int width, int height, string mode)
        {

            var w = width;
            var h = height;
            using (Image image = Image.Load(sFile))
            {
                if (mode.ToLower() == "w")
                {
                    if (w > image.Width)
                    {
                        h = width / image.Width * image.Height;
                        image.Mutate(x => x.Resize(w, h));
                        image.Save(outPath);
                    }
                }
                if (mode.ToLower() == "h")
                {
                    if (h > image.Height)
                    {
                        w = height / image.Height * image.Width;
                        image.Mutate(x => x.Resize(w, h));
                        image.Save(outPath);
                    }
                }
            }

        }
    }
}

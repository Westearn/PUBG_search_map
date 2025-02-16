using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.IO;
using Tesseract;


namespace pubgforms
{
    public class Tesseract
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Делает изображение экрана необходимых габаритов по координатам
        /// </summary>
        /// <param name="x">
        /// Координата X
        /// </param>
        /// <param name="y">
        /// Координата Y</param>
        /// <param name="size_x">
        /// Ширина изображения</param>
        /// <param name="size_y">
        /// Высота изображения</param>
        /// <param name="Thresh">
        /// Порог для чёрно-белого фильтра</param>
        public void TakeImage(int x, int y, int size_x, int size_y, byte Thresh)
        {
            var BM = new Bitmap(size_x, size_y);
            var GH = Graphics.FromImage(BM as Image);
            GH.CopyFromScreen(x, y, 0, 0, BM.Size);
            var img = BitmapConverter.ToMat(BM);

            Cv2.MedianBlur(img, img, 3);
            Cv2.CvtColor(img, img, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(img, img, Thresh, 255, ThresholdTypes.Binary);

            BM = BitmapConverter.ToBitmap(img);
            BM.Save(Path.Combine(path, @"test.jpg"));
            BM.Dispose();
            GH.Dispose();
            img.Dispose();
        }

        /// <summary>
        /// Делает изображение экрана необходимых габаритов по координатам и масштабирует его
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="size_x">Ширина изображения</param>
        /// <param name="size_y">Высота изображения</param>
        /// <param name="resized_x">Ширина измененного изображения</param>
        /// <param name="resized_y">Высота измененного изображения</param>
        /// <param name="Thresh">Порог для чёрно-белого фильтра</param>
        public void TakeImage(int x, int y, int size_x, int size_y, int resized_x, int resized_y, byte Thresh)
        {
            var BM = new Bitmap(size_x, size_y);
            var GH = Graphics.FromImage(BM as Image);
            GH.CopyFromScreen(x, y, 0, 0, BM.Size);
            Bitmap BM_resized = new Bitmap(BM, new System.Drawing.Size(resized_x, resized_y));
            var img = BitmapConverter.ToMat(BM_resized);

            Cv2.MedianBlur(img, img, 3);
            Cv2.CvtColor(img, img, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(img, img, Thresh, 255, ThresholdTypes.Binary);

            BM = BitmapConverter.ToBitmap(img);
            BM.Save(Path.Combine(path, @"test.jpg"));
            BM.Dispose();
            BM_resized.Dispose();
            GH.Dispose();
            img.Dispose();
        }

        /// <summary>
        /// Метод для распознавания текста по заранее подготовленной картинке
        /// </summary>
        /// <param name="language">Язык распознавания текста</param>
        /// <param name="CharList">Белый лист символов</param>
        /// <returns>Распознанный текст</returns>
        public string TesseractText(string language, string CharList)
        {
            var ocr = new TesseractEngine(Path.Combine(path), language, EngineMode.Default);
            ocr.SetVariable("tessedit_char_whitelist", CharList);
            var Input = Pix.LoadFromFile(Path.Combine(path, @"test.jpg"));
            var Read = ocr.Process(Input, PageSegMode.SingleLine);
            var alltext = Read.GetText().Trim();
            ocr.Dispose();
            return alltext;
        }
    }
}

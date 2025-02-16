using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;
using System.Collections.Generic;

namespace pubgforms
{
    public class defsearch
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        public static void DoMouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public static void RightClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }

        static string[] spisok_kart = { "ТАЭГО", "КАРАКИН", "ПАРАМО", "ДЕСТОН", "ЭРАНГЕЛЬ", "МИРАМАР", "ВИКЕНДИ", "САНОК", "РОНДО" };

        static System.Drawing.Size resolution = Screen.PrimaryScreen.Bounds.Size;
        static int ScreenWidth = resolution.Width;
        static int ScreenHeight = resolution.Height;

        const byte ColorDeviation = 2;

        static int center_ready_x = (int)Math.Round(346 / 2560f * ScreenWidth);
        static int center_ready_y = (int)Math.Round(1273 / 1440f * ScreenHeight); // координаты центра кнопки "Готов"

        static int esc1_x = (int)Math.Round(316 / 2560f * ScreenWidth);
        static int esc1_y = (int)Math.Round(633 / 1440f * ScreenHeight); // координаты кнопки "Покинуть игру" в "esc"

        static int esc2_x = (int)Math.Round(1131 / 2560f * ScreenWidth);
        static int esc2_y = (int)Math.Round(880 / 1440f * ScreenHeight); // координаты кнопки "Подтвердить" в "esc"

        static int error1_x = (int)Math.Round(1198 / 2560f * ScreenWidth);
        static int error1_y = (int)Math.Round(544 / 1440f * ScreenHeight); // координаты надписи "ОШИБКА 1"
        static Color error1_color = Color.FromArgb(238, 238, 241); // цвет пикселя надписи "ОШИБКА 1"

        static int error2_x = (int)Math.Round(1336 / 2560f * ScreenWidth);
        static int error2_y = (int)Math.Round(552 / 1440f * ScreenHeight); // координаты надписи "ОШИБКА 2"
        static Color error2_color = Color.FromArgb(237, 237, 242); // цвет пикселя надписи "ОШИБКА 2"

        static int reconnect1_x = (int)Math.Round(1275 / 2560f * ScreenWidth);
        static int reconnect1_y = (int)Math.Round(911 / 1440f * ScreenHeight); // координаты центра кнопки "Переподключиться"
        static int reconnect2_x = (int)Math.Round(1271 / 2560f * ScreenWidth);
        static int reconnect2_y = (int)Math.Round(880 / 1440f * ScreenHeight); // координаты центра кнопки "Переподключиться"

        static string ready_txt;
        static int r1 = (int)Math.Round(225 / 2560f * ScreenWidth);
        static int r2 = (int)Math.Round(1265 / 1440f * ScreenHeight); // координаты левого верхнего угла кнопки "Готов"
        static int r3 = (int)Math.Round(165 * ScreenWidth / 2560f);
        static int r4 = (int)Math.Round(45 * ScreenHeight / 1440f); // ширина и высота кнопки "Готов"

        static string map_target_txt;
        static int mt1 = (int)Math.Round(800 / 2560f * ScreenWidth);
        static int mt2 = (int)Math.Round(75 / 1440f * ScreenHeight); // координаты левого верхнего компаса
        static int mt3 = (int)Math.Round(980 * ScreenWidth / 2560f);
        static int mt4 = (int)Math.Round(24 * ScreenHeight / 1440f); // ширина и высота компаса

        static string name_map_txt;
        static int m1 = (int)Math.Round(30 / 2560f * ScreenWidth);
        static int m2 = (int)Math.Round(33 / 1440f * ScreenHeight); // координаты левого верхнего угла области определения названия карты
        static int m3 = (int)Math.Round(245 * ScreenWidth / 2560f);
        static int m4 = (int)Math.Round(70 * ScreenHeight / 1440f);  // ширина и высота области названия карты

        static string number_txt;
        static int n1 = (int)Math.Round(1200 / 2560f * ScreenWidth);
        static int n2 = (int)Math.Round(810 / 1440f * ScreenHeight); // координаты левого верхнего угла области времени до начала
        static int n3 = (int)Math.Round(150 * ScreenWidth / 2560f);
        static int n4 = (int)Math.Round(100 * ScreenHeight / 1440f);  // ширина и высота области времени до начала
        static int n3_r = (int)Math.Round(75 * ScreenWidth / 2560f);
        static int n4_r = (int)Math.Round(50 * ScreenHeight / 1440f);  // ширина и высота области времени до начала после изменения ширины и высоты
        
        /// <summary>
        /// Основной метод для поиска карты
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        async public static Task<Telegram.Bot.Types.Message> MMapSearch(TelegramBotClient botClient, CancellationToken cancellationToken)
        {
            Tesseract tesseract = new Tesseract();
            int q = 1;
            while (q > 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
                tesseract.TakeImage(r1, r2, r3, r4, 220);
                ready_txt = tesseract.TesseractText("rus", "ГОТВИРА");
                if (ready_txt == "ГОТОВ" || 
                    ready_txt == "ИГРА")
                {
                    await Task.Delay(1000);
                    int w = 1;
                    tesseract.TakeImage(r1, r2, r3, r4, 220);
                    ready_txt = tesseract.TesseractText("rus", "ГОТВИРА");
                    while ((ready_txt == "ГОТОВ" || ready_txt == "ИГРА") && w <= 7)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        Cursor.Position = new System.Drawing.Point(center_ready_x, center_ready_y);
                        DoMouseClick();
                        w++;
                        await Task.Delay(1000);
                        tesseract.TakeImage(r1, r2, r3, r4, 220);
                        ready_txt = tesseract.TesseractText("rus", "ГОТВИРА");
                    }
                    if (w >= 7)
                    {
                        Form1.button_Go.BringToFront();
                        return await botClient.SendMessage(
                            chatId: variables.tg_id,
                            text: "Поиск забагался");
                    }
                    int i = 1;
                    while (i > 0)
                    {
                        tesseract.TakeImage(mt1, mt2, mt3, mt4, 220);
                        map_target_txt = tesseract.TesseractText("eng", "EWS");
                        cancellationToken.ThrowIfCancellationRequested();
                        if (map_target_txt.Contains("E") ||
                            map_target_txt.Contains("W") ||
                            map_target_txt.Contains("S"))
                        {
                            await Task.Delay(1000);
                            SendKeys.Send("m");
                            await Task.Delay(1500);
                            int u = 0;
                            bool brek = false;
                            while (u <= 9)
                            {
                                cancellationToken.ThrowIfCancellationRequested();
                                int idp = 0;
                                tesseract.TakeImage(m1, m2, m3, m4, 150);
                                name_map_txt = tesseract.TesseractText("rus", "ТАЕГОКРИНПМДСЭЛЬВ");
                                while (idp <= 8)
                                {
                                    cancellationToken.ThrowIfCancellationRequested();
                                    if (name_map_txt == spisok_kart[idp])
                                    {
                                        if (variables.maps[idp])
                                        {
                                            variables.mapping = spisok_kart[idp];
                                            if (variables.Follow_Check) await ved();
                                            if (variables.Line_Check) await linesearch();
                                            if (variables.Box_30)
                                            {
                                                await botClient.SendMessage(
                                                    chatId: variables.tg_id,
                                                    text: $"Найдена карта {spisok_kart[idp]}");
                                                int g = 1;
                                                while (g > 0)
                                                {
                                                    cancellationToken.ThrowIfCancellationRequested();
                                                    tesseract.TakeImage(n1, n2, n3, n4, n3_r, n4_r, 220);
                                                    number_txt = tesseract.TesseractText("rus", "0123456789");
                                                    try
                                                    {
                                                        if (number_txt != null && number_txt.Length > 0)
                                                        if (Convert.ToInt16(number_txt.Substring(0, 1)) == 2)
                                                        {
                                                            Form1.button_Go.BringToFront();
                                                            return await botClient.SendMessage(
                                                                chatId: variables.tg_id,
                                                                text: $"До начала игры осталось менее 30 секунд!");
                                                        }
                                                    }
                                                    catch (FormatException) { }
                                                    if (g > 180) return await botClient.SendMessage(chatId: variables.tg_id, text: $"Не удалось обнаружить счётчик времени");
                                                    await Task.Delay(1000);
                                                    g++;
                                                }
                                            }
                                            Form1.button_Go.BringToFront();
                                            return await botClient.SendMessage(
                                                    chatId: variables.tg_id,
                                                    text: $"Найдена карта {spisok_kart[idp]}");
                                        }
                                        brek = true;
                                        break;
                                    }
                                    idp++;
                                }
                                if (brek)
                                {
                                    break;
                                }
                                await Task.Delay(1000);
                                SendKeys.Send("m");
                                await Task.Delay(100);
                                SendKeys.Send("ь");
                                await Task.Delay(1500);
                                u++;
                            }
                            if (u >= 9)
                            {
                                Form1.button_Go.BringToFront();
                                return await botClient.SendMessage(
                                    chatId: variables.tg_id,
                                    text: "Не получилось открыть карту");
                            }
                            SendKeys.Send("{ESC}");
                            await Task.Delay(500);
                            SendKeys.Send("{ESC}");
                            await Task.Delay(500);
                            Cursor.Position = new System.Drawing.Point(esc1_x, esc1_y);
                            await Task.Delay(300);
                            DoMouseClick();
                            await Task.Delay(500);
                            Cursor.Position = new System.Drawing.Point(esc2_x, esc2_y);
                            await Task.Delay(300);
                            DoMouseClick();
                            i = 0;
                        }
                        else
                        {
                            i++;
                            await Task.Delay(1000);
                            if (i == 150)
                            {
                                await botClient.SendMessage(
                                        chatId: variables.tg_id,
                                        text: "Долго ищет, возможно, сломался поиск");
                            }
                        }
                    }
                }
                else
                {
                    q++;
                    await Task.Delay(1000);
                    if (ColorMathing(GetColorAt(error1_x, error1_y), error1_color))
                    {
                        Cursor.Position = new System.Drawing.Point(reconnect1_x, reconnect1_y);
                        await Task.Delay(300);
                        DoMouseClick();
                    }
                    else if (ColorMathing(GetColorAt(error2_x, error2_y), error2_color))
                    {
                        Cursor.Position = new System.Drawing.Point(reconnect2_x, reconnect2_y);
                        await Task.Delay(300);
                        DoMouseClick();
                    }
                }
            }
            Form1.button_Go.BringToFront();
            return await botClient.SendMessage(
                chatId: variables.tg_id,
                text: "Поиск сломался");
        }

        /// <summary>
        /// Метод для определения цвета пикселя на экране
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Color GetColorAt(int x, int y)
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }

        /// <summary>
        /// Метод для сравнения цветов с фиксированной погрешностью
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool ColorMathing(Color x, Color y)
        {
            bool ColorM = (Math.Abs(x.R - y.R) <= defsearch.ColorDeviation)
                && (Math.Abs(x.G - y.G) <= defsearch.ColorDeviation)
                && (Math.Abs(x.B - y.B) <= defsearch.ColorDeviation);
            return ColorM;
        }

        /// <summary>
        /// Метод для нажатия кнопки привязывания
        /// </summary>
        /// <returns></returns>
        async public static Task ved()
        {
            Cursor.Position = new System.Drawing.Point((int)Math.Round(385 / 2560f * ScreenWidth),
                                                                    (int)Math.Round((1384 - 54 * (variables.Follow_Box - 1)) / 1440f * ScreenHeight));
            await Task.Delay(200);
            DoMouseClick();
        }

        /// <summary>
        /// Методя для определения линии самолета
        /// </summary>
        /// <returns></returns>
        async public static Task linesearch()
        {
            try
            {
                Bitmap BM = new Bitmap(ScreenWidth, ScreenHeight);
                Graphics GH = Graphics.FromImage(BM as Image);
                GH.Clear(Color.Black);

                Rectangle captureArea = new Rectangle(650 * ScreenWidth / 2560, 100 * ScreenHeight / 1440,
                                                        1250 * ScreenWidth / 2560, 1250 * ScreenHeight / 1440);

                Bitmap BM_screen = new Bitmap(captureArea.Width, captureArea.Height);
                Graphics GH_screen = Graphics.FromImage(BM_screen as Image);
                GH_screen.CopyFromScreen(captureArea.Location, System.Drawing.Point.Empty, captureArea.Size);
                GH.DrawImage(BM_screen, captureArea.Location);

                Mat img = BitmapConverter.ToMat(BM);
                Cv2.CvtColor(img, img, ColorConversionCodes.BGR2HSV);

                Scalar lowerRed1 = new Scalar(0, 50, 50);
                Scalar upperRed1 = new Scalar(10, 255, 255);
                Scalar lowerRed2 = new Scalar(170, 50, 50);
                Scalar upperRed2 = new Scalar(180, 255, 255);

                Cv2.BitwiseOr(img.InRange(lowerRed1, upperRed1), img.InRange(lowerRed2, upperRed2), img);
                Cv2.MedianBlur(img, img, 5);
                Cv2.Canny(img, img, 50, 150);

                LineSegmentPoint[] lines = img.HoughLinesP(1, 3.1416 / 180, 100, 800, 140);
                int[,] coord = new int[lines.Length * 2, 2];
                int i = 0;
                foreach (var line in lines)
                {
                    coord[i, 0] = line.P1.X;
                    coord[i, 1] = line.P1.Y;
                    coord[i + 1, 0] = line.P2.X;
                    coord[i + 1, 1] = line.P2.Y;
                    i += 2;
                }
                int coord_max_x = coord[0, 0];
                int coord_max_y = coord[0, 1];
                int coord_min_x = coord[0, 0];
                int coord_min_y = coord[0, 1];
                for (int j = 0; j <= coord.GetLength(0) - 1; j++)
                {
                    if (coord[j, 0] > coord_max_x)
                    {
                        coord_max_x = coord[j, 0];
                        coord_max_y = coord[j, 1];
                    }
                    if (coord[j, 0] < coord_min_x)
                    {
                        coord_min_x = coord[j, 0];
                        coord_min_y = coord[j, 1];
                    }
                }
                Cursor.Position = new System.Drawing.Point((int)Math.Round(coord_min_x / 2560f * ScreenWidth),
                                                                        (int)Math.Round(coord_min_y / 1440f * ScreenHeight));
                await Task.Delay(100);
                InputSimulator sim = new InputSimulator();
                sim.Keyboard.KeyDown(VirtualKeyCode.LMENU);
                await Task.Delay(100);
                RightClick();
                await Task.Delay(100);
                Cursor.Position = new System.Drawing.Point((int)Math.Round(coord_max_x / 2560f * ScreenWidth),
                                                                        (int)Math.Round(coord_max_y / 1440f * ScreenHeight));
                await Task.Delay(100);
                RightClick();
                await Task.Delay(100);
                sim.Keyboard.KeyUp(VirtualKeyCode.LMENU);
                BM.Dispose();
                GH.Dispose();
                BM_screen.Dispose();
                GH_screen.Dispose();
                img.Dispose();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Метод для отображения ближайших секретных комнат
        /// </summary>
        /// <param name="podzemka"></param>
        /// <returns></returns>
        async public static Task podzemka(List<(float x, float y, float length)> podzemka)
        {
            for (int k = 0; k < 1500; k++)
            {
                await Task.Delay(10);
                if (Control.ModifierKeys == Keys.Control)
                {
                    k = 1500;
                    int CursorX = Cursor.Position.X;
                    int CursorY = Cursor.Position.Y;

                    for (int j = 0; j <= podzemka.Count - 1; j++)
                    {
                        var length = (float)Math.Sqrt(Math.Pow((podzemka[j].x - CursorX), 2) + Math.Pow((podzemka[j].y - CursorY), 2));
                        podzemka[j] = (podzemka[j].x, podzemka[j].y, length);
                    }

                    podzemka.Sort((x, y) => x.length.CompareTo(y.length));
                    await Task.Delay(500);
                    InputSimulator sim = new InputSimulator();
                    sim.Keyboard.KeyDown(VirtualKeyCode.LMENU);
                    for (int n = 0; n < 3; n++)
                    {
                        await Task.Delay(300);
                        Cursor.Position = new System.Drawing.Point((int)Math.Round(podzemka[n].x), (int)Math.Round(podzemka[n].y));
                        await Task.Delay(300);
                        RightClick();
                    }
                    await Task.Delay(300);
                    sim.Keyboard.KeyUp(VirtualKeyCode.LMENU);
                    break;
                }
            }
            Form1.button1.Enabled = true;
        }
    }
}

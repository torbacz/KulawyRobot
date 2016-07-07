using AionBot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

//Wypieprza sie na szukaniu pin buttonów, nie znajduje ich
//Ulepszyć system czekania to znaczy czekać aż znajdzie przycisk zamiast wprost usypiać wątek

namespace AionBot.Control
{
    public static class AutoLogIn
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("user32.dll")] private static extern int SetForegroundWindow(IntPtr hWnd); private const int SW_RESTORE = 9;

        [DllImport("user32.dll")] private static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")] private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        [DllImport("user32.dll", SetLastError = true)] private static extern bool SetCursorPos(int X, int Y);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        private static AionBot.View.IMain view { get; set; }

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public static void setView(View.IMain pView)
        {
            view = pView;
        }

        private struct pinButton
        {
            public int number;
            public int x;
            public int y;
        }

        private static List<pinButton> listaPin;

        public static void startGame(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch
            {
                view.setLog("Failed to start AION", true);
                return;
            }
        }


        public static void inputLoginInfo(string login, string password, int char_position, string pin, IntPtr pHwnd)
        {
            Rectangle location = Rectangle.Empty;
            Bitmap bitmapMain = getWindowSS("AION Client");
            System.Threading.Thread.Sleep(1000);
            bitmapMain = getWindowSS("AION Client");



            Rect window = new Rect();
            GetWindowRect(pHwnd, ref window);

            int ok_button_x;
            int ok_button_y;
            int acc_text_x;
            int acc_text_y;
            int psw_text_x;
            int psw_text_y;

            Bitmap bitmap_cur = (Bitmap)Image.FromFile("img\\login_ok.png");
            location = autoSearchBitmap(bitmap_cur, bitmapMain);
            ok_button_x = (location.X + location.Width / 2)  +window.left;
            ok_button_y = (location.Y + location.Height / 2) + window.top;
            bitmapMain.Dispose();

            acc_text_x = ok_button_x - 50;
            acc_text_y = ok_button_y - 7;
            psw_text_x = ok_button_x - 50;
            psw_text_y = ok_button_y + 7;

            SetForegroundWindow(pHwnd);

            mouseClick(acc_text_x, acc_text_y);
            mouseClick(acc_text_x, acc_text_y);
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait(login);
            //imput acc
            mouseClick(psw_text_x, psw_text_y);
            mouseClick(psw_text_x, psw_text_y);
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait(password);
            //input psw
            mouseClick(ok_button_x, ok_button_y);

            //Kliknij accept button
            System.Threading.Thread.Sleep(1000);
            bitmapMain = getWindowSS("AION Client");
            bitmap_cur = (Bitmap)Image.FromFile("img\\accept._lic.png");
            location = autoSearchBitmap(bitmap_cur, bitmapMain);
            ok_button_x = (location.X + location.Width / 2) + window.left;
            ok_button_y = (location.Y + location.Height / 2) + window.top;
            bitmapMain.Dispose();
            mouseClick(ok_button_x, ok_button_y); //Accept button

            //Kliknij postać
            System.Threading.Thread.Sleep(5000);
            mouseClick(window.left + 660, window.top + 190);
            //kliknij start
            System.Threading.Thread.Sleep(1000);
            bitmapMain = getWindowSS("AION Client");
            bitmap_cur = (Bitmap)Image.FromFile("img\\start_png.png");
            location = autoSearchBitmap(bitmap_cur, bitmapMain);
            ok_button_x = (location.X + location.Width / 2) + window.left;
            ok_button_y = (location.Y + location.Height / 2) + window.top;
            bitmapMain.Dispose();
            mouseClick(ok_button_x, ok_button_y); // start button

            //INPUT PIN
            inputPin(pin);
            //OK
            bitmapMain = getWindowSS("AION Client");
            bitmap_cur = (Bitmap)Image.FromFile("img\\pin_ok.png");
            location = autoSearchBitmap(bitmap_cur, bitmapMain);
            ok_button_x = (location.X + location.Width / 2) + window.left;
            ok_button_y = (location.Y + location.Height / 2) + window.top;
            bitmapMain.Dispose();
            mouseClick(ok_button_x, ok_button_y); // start button
        }
        public static void inputPin (string pin)
        {
            searchForPinButtons();
            foreach (char cur in pin)
            {
                if (cur == '0') mouseClick(listaPin[0].x, listaPin[0].y);
                if (cur == '1') mouseClick(listaPin[1].x, listaPin[1].y);
                if (cur == '2') mouseClick(listaPin[2].x, listaPin[2].y);
                if (cur == '3') mouseClick(listaPin[3].x, listaPin[3].y);
                if (cur == '4') mouseClick(listaPin[4].x, listaPin[4].y);
                if (cur == '5') mouseClick(listaPin[5].x, listaPin[5].y);
                if (cur == '6') mouseClick(listaPin[6].x, listaPin[6].y);
                if (cur == '7') mouseClick(listaPin[7].x, listaPin[7].y);
                if (cur == '8') mouseClick(listaPin[8].x, listaPin[8].y);
                if (cur == '9') mouseClick(listaPin[9].x, listaPin[9].y);
            }
        }
        private static Bitmap getWindowSS(string procName)
        {
            Process proc = new Process();
            bool stopTrying = false;
            // Cater for cases when the process can't be located.
            while (!stopTrying)
            {
                foreach (Process pList in Process.GetProcesses())
                {
                    if (pList.MainWindowTitle.Contains(procName))
                    {
                        proc = pList;
                        stopTrying = true;
                    }
                }
            }
            // You need to focus on the application
            SetForegroundWindow(proc.MainWindowHandle);
            ShowWindow(proc.MainWindowHandle, SW_RESTORE);

            // You need some amount of delay, but 1 second may be overkill
            Thread.Sleep(1000);

            Rect rect = new Rect();
            IntPtr error = GetWindowRect(proc.MainWindowHandle, ref rect);

            // sometimes it gives error.
            while (error == (IntPtr)0)
            {
                error = GetWindowRect(proc.MainWindowHandle, ref rect);
            }

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics.FromImage(bmp).CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);


            return bmp;
        }
        private static void searchForPinButtons()
        {
            String[] sciezka = new String[40];
            sciezka[0] = "img\\0_w.bmp";
            sciezka[1] = "img\\0_y.bmp";

            sciezka[2] = "img\\1_w.bmp";
            sciezka[3] = "img\\1_y.bmp";

            sciezka[4] = "img\\2_w.bmp";
            sciezka[5] = "img\\2_y.bmp";

            sciezka[6] = "img\\3_w.bmp";
            sciezka[7] = "img\\3_y.bmp";

            sciezka[8] = "img\\4_w.bmp";
            sciezka[9] = "img\\4_y.bmp";

            sciezka[10] = "img\\5_w.bmp";
            sciezka[11] = "img\\5_y.bmp";

            sciezka[12] = "img\\6_w.bmp";
            sciezka[13] = "img\\6_y.bmp";

            sciezka[14] = "img\\7_w.bmp";
            sciezka[15] = "img\\7_y.bmp";

            sciezka[16] = "img\\8_w.bmp";
            sciezka[17] = "img\\8_y.bmp";

            sciezka[18] = "img\\9_w.bmp";
            sciezka[19] = "img\\9_y.bmp";

            Bitmap bitmapMain = getWindowSS("AION Client");


            Rectangle location = Rectangle.Empty;

            int foundNumber = 0;
            listaPin = new List<pinButton>();

            for (int i = 0; i <= 19; i++)
            {
                Bitmap bitmap_cur = (Bitmap)Image.FromFile(sciezka[i]);
                location = autoSearchBitmap(bitmap_cur, bitmapMain);
                if (location.X != 0 && location.Y != 0)
                {
                    pinButton cur_but = new pinButton();
                    cur_but.number = foundNumber;
                    cur_but.x = location.X + location.Width / 2;
                    cur_but.y = location.Y + location.Height / 2;
                    listaPin.Add(cur_but);
                    foundNumber++;
                }
                bitmap_cur.Dispose();
            }
            bitmapMain.Dispose();
        }
        private static Rectangle autoSearchBitmap(Bitmap bitmap1, Bitmap bitmap2)
        {
            Rectangle location = Rectangle.Empty;
            for (int i = 0; i <= 2; i++)
            {

                double tolerance = Convert.ToDouble(i) / 100.0;

                location = searchBitmap(bitmap1, bitmap2, tolerance);

                if (location.Width != 0)
                    break;
            }
            return location;
        }
        private static Rectangle searchBitmap(Bitmap smallBmp, Bitmap bigBmp, double tolerance)
        {
            BitmapData smallData =
              smallBmp.LockBits(new Rectangle(0, 0, smallBmp.Width, smallBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bigData =
              bigBmp.LockBits(new Rectangle(0, 0, bigBmp.Width, bigBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int smallStride = smallData.Stride;
            int bigStride = bigData.Stride;

            int bigWidth = bigBmp.Width;
            int bigHeight = bigBmp.Height - smallBmp.Height + 1;
            int smallWidth = smallBmp.Width * 3;
            int smallHeight = smallBmp.Height;

            Rectangle location = Rectangle.Empty;
            int margin = Convert.ToInt32(255.0 * tolerance);

            unsafe
            {
                byte* pSmall = (byte*)(void*)smallData.Scan0;
                byte* pBig = (byte*)(void*)bigData.Scan0;

                int smallOffset = smallStride - smallBmp.Width * 3;
                int bigOffset = bigStride - bigBmp.Width * 3;

                bool matchFound = true;

                for (int y = 0; y < bigHeight; y++)
                {
                    for (int x = 0; x < bigWidth; x++)
                    {
                        byte* pBigBackup = pBig;
                        byte* pSmallBackup = pSmall;

                        //Look for the small picture.
                        for (int i = 0; i < smallHeight; i++)
                        {
                            int j = 0;
                            matchFound = true;
                            for (j = 0; j < smallWidth; j++)
                            {
                                //With tolerance: pSmall value should be between margins.
                                int inf = pBig[0] - margin;
                                int sup = pBig[0] + margin;
                                if (sup < pSmall[0] || inf > pSmall[0])
                                {
                                    matchFound = false;
                                    break;
                                }

                                pBig++;
                                pSmall++;
                            }

                            if (!matchFound) break;

                            //We restore the pointers.
                            pSmall = pSmallBackup;
                            pBig = pBigBackup;

                            //Next rows of the small and big pictures.
                            pSmall += smallStride * (1 + i);
                            pBig += bigStride * (1 + i);
                        }

                        //If match found, we return.
                        if (matchFound)
                        {
                            location.X = x;
                            location.Y = y;
                            location.Width = smallBmp.Width;
                            location.Height = smallBmp.Height;
                            break;
                        }
                        //If no match found, we restore the pointers and continue.
                        else
                        {
                            pBig = pBigBackup;
                            pSmall = pSmallBackup;
                            pBig += 3;
                        }
                    }

                    if (matchFound) break;

                    pBig += bigOffset;
                }
            }

            bigBmp.UnlockBits(bigData);
            smallBmp.UnlockBits(smallData);

            return location;
        }
        private static void mouseClick(int x,int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}

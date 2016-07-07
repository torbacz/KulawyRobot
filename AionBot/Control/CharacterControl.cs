using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Nie działa wszystko

namespace AionBot.Control
{
    public static class CharacterControl
    {
        [DllImport("user32.dll")]
        static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        public static bool rotateCharacterToZero(float currentAngle)
        {
            if(currentAngle == 0)
            {
                return true;
            }
            else
            {
                if (currentAngle < 0)
                {
                    return false;
                }
                else
                {

                    return false;
                }
            }
        }
        public static bool rotateChracterToAngle()
        {
            return false;
        }
        public static float findRotationAngle()
        {
            return 0;
        }
        public static void goForward()
        {
            keybd_event((byte)0x57, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((byte)0x57, 0, 0x0002, 0);
            System.Windows.Forms.Application.DoEvents();
        }
        
    }
}

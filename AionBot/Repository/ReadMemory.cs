using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AionBot.Repository
{
    public sealed class ReadMemory
    {
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        private static ReadMemory GetInstance = null;
        public static ReadMemory Instance
        {
            get
            {
                if (GetInstance == null)
                {
                    GetInstance = new ReadMemory();
                }
                return GetInstance;
            }

        }

        public static int baseAdress;

        int hp_max_adress = baseAdress + 0x13A4A0C;
        int hp_cur_adress = baseAdress + 0x13A4A10;
        int mp_max_adress = baseAdress + 0x13A4A14;
        int mp_cur_adress = baseAdress + 0x13A4A18;
        int dp_cur_adress = baseAdress + 0x13A4A1E;
        int ft_max_adress = baseAdress + 0x13A4A20;
        int ft_cur_adress = baseAdress + 0x13A4A24;

        int charName_adress = baseAdress + 0x139A05C;
        int charClass_adress = baseAdress + 0x1427F60;
        int charLvl_adress = baseAdress + 0x13A49E8;

        int x_adress = baseAdress + 0x1399C34;
        int y_adress = baseAdress + 0x1399C38;
        int z_adress = baseAdress + 0x1399C3C;
        int rotation_adress = baseAdress + 0x13997E0;

        public int hp_max(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];
            ReadProcessMemory((int)openedProcessHandle, hp_max_adress, buffer, buffer.Length, ref bytesRead);
            int valueToReturn = BitConverter.ToInt32(buffer, 0);
            return valueToReturn;
        }
        public int hp_cur(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4]; 
            ReadProcessMemory((int)openedProcessHandle, hp_cur_adress, buffer, buffer.Length, ref bytesRead);
            int valueToReturn = BitConverter.ToInt32(buffer, 0);
            return valueToReturn;
        }
        public int mp_max(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];
            ReadProcessMemory((int)openedProcessHandle, mp_max_adress, buffer, buffer.Length, ref bytesRead);
            int valueToReturn = BitConverter.ToInt32(buffer, 0);
            return valueToReturn;
        }
        public int mp_cur(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];
            ReadProcessMemory((int)openedProcessHandle, mp_cur_adress, buffer, buffer.Length, ref bytesRead);
            int valueToReturn = BitConverter.ToInt32(buffer, 0);
            return valueToReturn;
        }
        public int dp_max(IntPtr openedProcessHandle)
        {
            return 4000;
        }
        public int dp_cur(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[2];
            ReadProcessMemory((int)openedProcessHandle, dp_cur_adress, buffer, buffer.Length, ref bytesRead);
            int valueToReturn = BitConverter.ToInt16(buffer, 0);
            return valueToReturn;
        }
        public int ft_max(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];
            ReadProcessMemory((int)openedProcessHandle, ft_max_adress, buffer, buffer.Length, ref bytesRead);
            int valueToReturn = BitConverter.ToInt32(buffer, 0);
            return valueToReturn/1000;
        }
        public int ft_cur(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];
            ReadProcessMemory((int)openedProcessHandle, ft_cur_adress, buffer, buffer.Length, ref bytesRead);
            int valueToReturn = BitConverter.ToInt32(buffer, 0);
            return valueToReturn/1000;
        }
        public string charName(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[25];
            ReadProcessMemory((int)openedProcessHandle, charName_adress, buffer, buffer.Length, ref bytesRead);
            return Encoding.Unicode.GetString(buffer); ;
        }
        public string charClass(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[25];
            ReadProcessMemory((int)openedProcessHandle, charClass_adress, buffer, buffer.Length, ref bytesRead);
            return Encoding.Unicode.GetString(buffer); ;
        }
        public int charLvl(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[1];
            ReadProcessMemory((int)openedProcessHandle, charLvl_adress, buffer, buffer.Length, ref bytesRead);
            int valueToReturn = buffer[0];
            return valueToReturn;
        }
        public float x(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[sizeof(float)];
            ReadProcessMemory((int)openedProcessHandle, x_adress, buffer, buffer.Length, ref bytesRead);
            float valueToReturn = BitConverter.ToSingle(buffer, 0);
            return valueToReturn;
        }
        public float y(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[sizeof(float)];
            ReadProcessMemory((int)openedProcessHandle, y_adress, buffer, buffer.Length, ref bytesRead);
            float valueToReturn = BitConverter.ToSingle(buffer, 0);
            return valueToReturn;
        }
        public float z(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[sizeof(float)];
            ReadProcessMemory((int)openedProcessHandle, z_adress, buffer, buffer.Length, ref bytesRead);
            float valueToReturn = BitConverter.ToSingle(buffer, 0);
            return valueToReturn;
        }
        public float rotation(IntPtr openedProcessHandle)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[sizeof(float)];
            ReadProcessMemory((int)openedProcessHandle, rotation_adress, buffer, buffer.Length, ref bytesRead);
            float valueToReturn = BitConverter.ToSingle(buffer, 0);
            return valueToReturn;
        }
    }
}

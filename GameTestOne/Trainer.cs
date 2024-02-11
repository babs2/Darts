using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameTestOne
{
    public class Trainer
    {
        private static readonly Random rnd = new Random();
        public static void start()
        {
            SetConsoleFont("Consolas", 15, 30);
            int minScore = 0;
            int maxScore = 0;
            bool validNum = false;
            bool validNum2 = false;
            while (!validNum)
            {
                Console.WriteLine("Enter Lowest out you want to test on: (note lower than 22 is bogus)");
                string input = Console.ReadLine();
                validNum = int.TryParse(input, out minScore);
            }
            while (!validNum2)
            {
                Console.WriteLine("Enter Highest out you want to test on:");
                string input2 = Console.ReadLine();
                validNum2 = int.TryParse(input2, out maxScore);
            }


            while (true)
            {
                int counter = getRand(minScore, maxScore);
                Console.WriteLine(counter + " is counter");
                Console.ReadLine();
                outs(counter);
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void outs(int counter)
        {
            if (counter < 171)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                switch (counter)
                {
                    case 170:
                        Console.WriteLine("60 , 60 , Bull");
                        break;
                    case 167:
                        Console.WriteLine("60 , 57 , Bull");
                        break;
                    case 164:
                        Console.WriteLine("60 , 54 , Bull");
                        break;
                    case 161:
                        Console.WriteLine("60 , 51 , Bull");
                        break;
                    case 160:
                        Console.WriteLine("60 , 60 , D20");
                        break;
                    case 158:
                        Console.WriteLine("60 , 60 , D19");
                        break;
                    case 157:
                        Console.WriteLine("57 , 60 , D20");
                        break;
                    case 156:
                        Console.WriteLine("60 , 60 , D18");
                        break;
                    case 155:
                        Console.WriteLine("60 , 57 , D19");
                        break;
                    case 154:
                        Console.WriteLine("60 , 54 , D20");
                        break;
                    case 153:
                        Console.WriteLine("60 , 57 , D18");
                        break;
                    case 152:
                        Console.WriteLine("60 , 60 , D16");
                        break;
                    case 151:
                        Console.WriteLine("60 , 51 , D20");
                        break;
                    case 150:
                        Console.WriteLine("60 , 54 , D18");
                        break;
                    case 149:
                        Console.WriteLine("60 , 57 , D16");
                        break;
                    case 148:
                        Console.WriteLine("60 , 48 , D20");
                        break;
                    case 147:
                        Console.WriteLine("60 , 51 , D18");
                        break;
                    case 146:
                        Console.WriteLine("60 , 54 , D16");
                        break;
                    case 145:
                        Console.WriteLine("60 , 45 , D20");
                        break;
                    case 144:
                        Console.WriteLine("60 , 60 , D12");
                        break;
                    case 143:
                        Console.WriteLine("60 , 51 , D16");
                        break;
                    case 142:
                        Console.WriteLine("60 , 42 , D20");
                        break;
                    case 141:
                        Console.WriteLine("60 , 57 , D12");
                        break;
                    case 140:
                        Console.WriteLine("60 , 48 , D16");
                        break;
                    case 139:
                        Console.WriteLine("57 , 42 , D20");
                        break;
                    case 138:
                        Console.WriteLine("60 , 54 , D12");
                        break;
                    case 137:
                        Console.WriteLine("57 , 48 , D16");
                        break;
                    case 136:
                        Console.WriteLine("60 , 60 , D8");
                        break;
                    case 135:
                        Console.WriteLine("60 , 51 , D12");
                        break;
                    case 134:
                        Console.WriteLine("60 , 42 , D16");
                        break;
                    case 133:
                        Console.WriteLine("60 , 57 , D8");
                        break;
                    case 132:
                        Console.WriteLine("60 , 48 , D12");
                        break;
                    case 131:
                        Console.WriteLine("60 , 39 , D16");
                        break;
                    case 130:
                        Console.WriteLine("60 , 60 , D5");
                        break;
                    case 129:
                        Console.WriteLine("57 , 48 , D12");
                        break;
                    case 128:
                        Console.WriteLine("54 , 42 , D16");
                        break;
                    case 127:
                        Console.WriteLine("60 , 51 , D8");
                        break;
                    case 126:
                        Console.WriteLine("57 , 57 , D6");
                        break;
                    case 125:
                        Console.WriteLine("25 , 60 , D20");
                        break;
                    case 124:
                        Console.WriteLine("60 , 48 , D8");
                        break;
                    case 123:
                        Console.WriteLine("57 , 48 , D9");
                        break;
                    case 122:
                        Console.WriteLine("54 , 60 , D4");
                        break;
                    case 121:
                        Console.WriteLine("51 , 30 , D20");
                        break;
                    case 120:
                        Console.WriteLine("60 , 20 , D20");
                        break;
                    case 119:
                        Console.WriteLine("57 , 30 , D16");
                        break;
                    case 118:
                        Console.WriteLine("60 , 18 , D20");
                        break;
                    case 117:
                        Console.WriteLine("60 , 17 , D20");
                        break;
                    case 116:
                        Console.WriteLine("60 , 16 , D20");
                        break;
                    case 115:
                        Console.WriteLine("60 , 15 , D20");
                        break;
                    case 114:
                        Console.WriteLine("60 , 14 , D20");
                        break;
                    case 113:
                        Console.WriteLine("60 , 13 , D20");
                        break;
                    case 112:
                        Console.WriteLine("60 , 12 , D20");
                        break;
                    case 111:
                        Console.WriteLine("60 , 19 , D16");
                        break;
                    case 110:
                        Console.WriteLine("60 , 18 , D16");
                        break;
                    case 109:
                        Console.WriteLine("57 , 20 , D16");
                        break;
                    case 108:
                        Console.WriteLine("60 , 16 , D16");
                        break;
                    case 107:
                        Console.WriteLine("57 , 18 , D16");
                        Console.WriteLine("19 , 60 , D14");
                        break;
                    case 106:
                        Console.WriteLine("60 , 14 , D16");
                        Console.WriteLine("20 , 54 , D16");
                        break;
                    case 105:
                        Console.WriteLine("57 , 16 , D16");
                        Console.WriteLine("19 , 54 , D16");
                        break;
                    case 104:
                        Console.WriteLine("54 , 18 , D16");
                        Console.WriteLine("18 , 54 , D16");
                        break;
                    case 103:
                        Console.WriteLine("60 , 11 , D16");
                        Console.WriteLine("20 , 51 , D16");
                        break;
                    case 102:
                        Console.WriteLine("60 , 10 , D16");
                        Console.WriteLine("20 , 42 , D20");
                        break;
                    case 101:
                        Console.WriteLine("57 , 12 , D16");
                        Console.WriteLine("19 , 42 , D20");
                        break;
                    case 100:
                        Console.WriteLine("60 , D20 ");
                        Console.WriteLine("20 , 60 , D10");
                        break;
                    case 99:
                        Console.WriteLine("57 , 10 , D16");
                        Console.WriteLine("19 , 60 , D10");
                        break;
                    case 98:
                        Console.WriteLine("60 , D19 ");
                        Console.WriteLine("20 , 54 , D12 ");
                        break;
                    case 97:
                        Console.WriteLine("57 , D20 ");
                        Console.WriteLine("19 , 54 , D12");
                        break;
                    case 96:
                        Console.WriteLine("60 , D18 ");
                        Console.WriteLine("20 , 60 , D8 ");
                        break;
                    case 95:
                        Console.WriteLine("57 , D19 ");
                        Console.WriteLine("19 , 60 , D8");
                        break;
                    case 94:
                        Console.WriteLine("54 , D20 ");
                        Console.WriteLine("18 , 60 , D8 ");
                        break;
                    case 93:
                        Console.WriteLine("57 , D18 ");
                        Console.WriteLine("19 , 42 , D16 ");
                        break;
                    case 92:
                        Console.WriteLine("60 , D16 ");
                        Console.WriteLine("20 , 48 , D12 ");
                        break;
                    case 91:
                        Console.WriteLine("51 , D20 ");
                        Console.WriteLine("17 , 42 , D16 ");
                        break;
                    case 90:
                        Console.WriteLine("54 , D18 ");
                        Console.WriteLine("18 , 48 , D12 ");
                        break;
                    case 89:
                        Console.WriteLine("57 , D16 ");
                        Console.WriteLine("19 , 54 , D8 ");
                        break;
                    case 88:
                        Console.WriteLine("60 , D14 ");
                        Console.WriteLine("20 , 60, D4 ");
                        break;
                    case 87:
                        Console.WriteLine("51 , D18 ");
                        Console.WriteLine("17 , 54 , D8 ");
                        break;
                    case 86:
                        Console.WriteLine("54 , D16 ");
                        Console.WriteLine("18 , 18 , Bull");
                        break;
                    case 85:
                        Console.WriteLine("45 , D20 ");
                        Console.WriteLine("15 , 54, D8");
                        break;
                    case 84:
                        Console.WriteLine("60 , D12 ");
                        Console.WriteLine("20 , 14 , Bull");
                        break;
                    case 83:
                        Console.WriteLine("51 , D16 ");
                        Console.WriteLine("17 , 54 , D6");
                        break;
                    case 82:
                        Console.WriteLine("42 , D20 ");
                        Console.WriteLine("14 , 60 , D4");
                        break;
                    case 81:
                        Console.WriteLine("57 , D12 ");
                        Console.WriteLine("19 , 42 , D10");
                        break;
                    case 80:
                        Console.WriteLine("60 , D10 ");
                        Console.WriteLine("20 , 20 , D20");
                        break;
                    case 79:
                        Console.WriteLine("57 , D11 ");
                        Console.WriteLine("19 , 20 , D20");
                        break;
                    case 78:
                        Console.WriteLine("54 , D12 ");
                        Console.WriteLine("18 , 20 , D20");
                        break;
                    case 77:
                        Console.WriteLine("57 , D10 ");
                        Console.WriteLine("19 , 18 , D20");
                        break;
                    case 76:
                        Console.WriteLine("60 , D8 ");
                        Console.WriteLine("20 , 48 , D4");
                        Console.WriteLine("20 , 16 , D20");
                        break;
                    case 75:
                        Console.WriteLine("51 , D12 ");
                        Console.WriteLine("17 , 18 , D20");
                        break;
                    case 74:
                        Console.WriteLine("42 , D16 ");
                        Console.WriteLine("14 , 20 , D20");
                        break;
                    case 73:
                        Console.WriteLine("57 , D8 ");
                        Console.WriteLine("19 , 14 , D20");
                        break;
                    case 72:
                        Console.WriteLine("48 , D12 ");
                        Console.WriteLine("16 , 48 , D4");
                        Console.WriteLine("16 , 24(T8) , D16");
                        Console.WriteLine("16 , 16 , D20");
                        break;
                    case 71:
                        Console.WriteLine("39 , D16 ");
                        Console.WriteLine("13 , 18 , D20");
                        break;
                    case 70:
                        Console.WriteLine("54 , D8 ");
                        Console.WriteLine("18 , 20 , D16");
                        break;
                    case 69:
                        Console.WriteLine("45 , D12 ");
                        Console.WriteLine("15 , 14 , D20");
                        break;
                    case 68:
                        Console.WriteLine("60 , D4 ");
                        Console.WriteLine("20 , 16 , D16");
                        break;
                    case 67:
                        Console.WriteLine("51 , D8 ");
                        Console.WriteLine("17 , 18 , D16");
                        break;
                    case 66:
                        Console.WriteLine("42 , D12 ");
                        Console.WriteLine("14 , 20 , D16");
                        break;
                    case 65:
                        Console.WriteLine("33 , D16 ");
                        Console.WriteLine("11 , 12 , D16");
                        break;
                    case 64:
                        Console.WriteLine("48 , D8 ");
                        Console.WriteLine("16 , 16 , D16");
                        break;
                    case 63:
                        Console.WriteLine("51 , D6 ");
                        Console.WriteLine("17 , 14 , D16");
                        break;
                    case 62:
                        Console.WriteLine("42 , D10 ");
                        Console.WriteLine("14 , D16 ");
                        break;
                    case 61:
                        Console.WriteLine("45 , D8 ");
                        Console.WriteLine("15 , 14 , D16");
                        break;
                    case 60:
                        Console.WriteLine("20 , D20 ");
                        break;
                    case 59:
                        Console.WriteLine("19 , D20 ");
                        break;
                    case 58:
                        Console.WriteLine("18 , D20 ");
                        break;
                    case 57:
                        Console.WriteLine("17 , D20 ");
                        break;
                    case 56:
                        Console.WriteLine("16 , D20 ");
                        break;
                    case 55:
                        Console.WriteLine("15 , D20 ");
                        break;
                    case 54:
                        Console.WriteLine("14 , D20 ");
                        break;
                    case 53:
                        Console.WriteLine("13 , D20 ");
                        break;
                    case 52:
                        Console.WriteLine("20 , D16 ");
                        break;
                    case 51:
                        Console.WriteLine("19 , D16 ");
                        break;
                    case 50:
                        Console.WriteLine("18 , D16 ");
                        break;
                    case 49:
                        Console.WriteLine("17 , D16 ");
                        break;
                    case 48:
                        Console.WriteLine("16 , D16 ");
                        break;
                    case 47:
                        Console.WriteLine("15 , D16 ");
                        break;
                    case 46:
                        Console.WriteLine("14 , D16 ");
                        break;
                    case 45:
                        Console.WriteLine("13 , D16 ");
                        break;
                    case 44:
                        Console.WriteLine("12 , D16 ");
                        break;
                    case 43:
                        Console.WriteLine("11 , D16 ");
                        break;
                    case 42:
                        Console.WriteLine("10 , D16 ");
                        break;
                    case 41:
                        Console.WriteLine("9 , D16 ");
                        break;
                    case 40:
                        Console.WriteLine("D20 ");
                        break;
                    case 39:
                        Console.WriteLine("7 , D16");
                        break;
                    case 38:
                        Console.WriteLine("6 , D16 ");
                        break;
                    case 37:
                        Console.WriteLine("5 , D16 ");
                        break;
                    case 36:
                        Console.WriteLine("D18 ");
                        break;
                    case 35:
                        Console.WriteLine("3 , D16 ");
                        break;
                    case 34:
                        Console.WriteLine("2 , D16 ");
                        break;
                    case 33:
                        Console.WriteLine("1 , D16 ");
                        break;
                    case 32:
                        Console.WriteLine("D16 ");
                        break;
                    case 31:
                        Console.WriteLine("15 , D8 ");
                        break;
                    case 30:
                        Console.WriteLine("14 , D8 ");
                        break;
                    case 29:
                        Console.WriteLine("13 , D8 ");
                        break;
                    case 28:
                        Console.WriteLine("12 , D8 ");
                        break;
                    case 27:
                        Console.WriteLine("11 , D8 ");
                        break;
                    case 26:
                        Console.WriteLine("10 , D8 ");
                        break;
                    case 25:
                        Console.WriteLine("9 , D8 ");
                        break;
                    case 24:
                        Console.WriteLine("D12 ");
                        break;
                    case 23:
                        Console.WriteLine("7 , D8 ");
                        break;
                    case 22:
                        Console.WriteLine("6 , D8 ");
                        break;
                    case 21:
                        Console.WriteLine("5 , D8 ");
                        break;
                    case 20:
                        Console.WriteLine("D10");
                        break;
                    case 19:
                        Console.WriteLine("3 , D8");
                        break;
                    case 18:
                        Console.WriteLine("D9");
                        break;
                    case 17:
                        Console.WriteLine("1 , D8");
                        break;
                    default:
                        Console.WriteLine("figure it out " + counter);
                        break;
                }
                Console.ResetColor();

            }
        }

        public static int getRand(int min, int max)
        {
            return rnd.Next(min, max);
        }

        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }

        internal struct COORD
        {
            internal short X;
            internal short Y;

            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int LF_FACESIZE = 32;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int dwType);


        public static void SetConsoleFont(string fontName = "Lucida Console", short fontSizeX = 8, short fontSizeY = 16)
        {
            unsafe
            {
                IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
                if (hnd != INVALID_HANDLE_VALUE)
                {
                    CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
                    info.cbSize = (uint)Marshal.SizeOf(info);

                    CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                    newInfo.dwFontSize = new COORD(fontSizeX, fontSizeY);
                    newInfo.FontWeight = 700; // Bold font
                    SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
        }


    }
}

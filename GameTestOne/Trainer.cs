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
            //SetConsoleFont("Consolas", 15, 30);
            Console.WriteLine("Do you want to select an out? (Y/N)");
            string prompt = Console.ReadLine().ToUpper();
            
            int minScore = 0;
            int maxScore = 0;
            int outSearch = 0;
            bool validNum = false;
            bool validNum2 = false;
            while (prompt == "Y")
            {
                Console.WriteLine("what out are you looking for?");
                prompt = Console.ReadLine().ToUpper();
                validNum = int.TryParse(prompt, out outSearch);
                if (validNum == true)
                {
                    outs(outSearch);
                    Console.WriteLine("want to search for another out? (Y/N)");
                    prompt = Console.ReadLine().ToUpper();
                }
            }
            Console.Clear();
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
                        Console.WriteLine("T20 , T20 , Bull");
                        break;
                    case 169:
                        Console.WriteLine("bogey");
                        break;
                    case 168:
                        Console.WriteLine("bogey");
                        break;
                    case 167:
                        Console.WriteLine("T20 , T19 , Bull");
                        break;
                    case 166:
                        Console.WriteLine("bogey");
                        break;
                    case 165:
                        Console.WriteLine("bogey");
                        break;
                    case 164:
                        Console.WriteLine("T20 , T18 , Bull");
                        break;
                    case 163:
                        Console.WriteLine("bogey");
                        break;
                    case 162:
                        Console.WriteLine("bogey");
                        break;
                    case 161:
                        Console.WriteLine("T20 , T17 , Bull");
                        break;
                    case 160:
                        Console.WriteLine("T20 , T20 , D20");
                        break;
                    case 159:
                        Console.WriteLine("bogey");
                        break;
                    case 158:
                        Console.WriteLine("T20 , T20 , D19");
                        break;
                    case 157:
                        Console.WriteLine("T19 , T20 , D20");
                        break;
                    case 156:
                        Console.WriteLine("T20 , T20 , D18");
                        break;
                    case 155:
                        Console.WriteLine("T20 , T19 , D19");
                        break;
                    case 154:
                        Console.WriteLine("T20 , T18 , D20");
                        break;
                    case 153:
                        Console.WriteLine("T20 , T19 , D18");
                        break;
                    case 152:
                        Console.WriteLine("T20 , T20 , D16");
                        break;
                    case 151:
                        Console.WriteLine("T20 , T17 , D20");
                        break;
                    case 150:
                        Console.WriteLine("T20 , T18 , D18");
                        break;
                    case 149:
                        Console.WriteLine("T20 , T19 , D16");
                        break;
                    case 148:
                        Console.WriteLine("T20 , T16 , D20");
                        break;
                    case 147:
                        Console.WriteLine("T20 , T17 , D18");
                        break;
                    case 146:
                        Console.WriteLine("T20 , T18 , D16");
                        break;
                    case 145:
                        Console.WriteLine("T20 , T15 , D20");
                        break;
                    case 144:
                        Console.WriteLine("T20 , T20 , D12");
                        break;
                    case 143:
                        Console.WriteLine("T20 , T17 , D16");
                        break;
                    case 142:
                        Console.WriteLine("T20 , T14 , D20");
                        break;
                    case 141:
                        Console.WriteLine("T20 , T19 , D12");
                        break;
                    case 140:
                        Console.WriteLine("T20 , T16 , D16");
                        break;
                    case 139:
                        Console.WriteLine("T19 , T14 , D20");
                        break;
                    case 138:
                        Console.WriteLine("T20 , T18 , D12");
                        break;
                    case 137:
                        Console.WriteLine("T19 , T16 , D16");
                        break;
                    case 136:
                        Console.WriteLine("T20 , T20 , D8");
                        break;
                    case 135:
                        Console.WriteLine("T20 , T17 , D12");
                        break;
                    case 134:
                        Console.WriteLine("T20 , T14 , D16");
                        break;
                    case 133:
                        Console.WriteLine("T20 , T19 , D8");
                        break;
                    case 132:
                        Console.WriteLine("T20 , T16 , D12");
                        break;
                    case 131:
                        Console.WriteLine("T20 , T13 , D16");
                        break;
                    case 130:
                        Console.WriteLine("T20 , T20 , D5");
                        Console.WriteLine("20 , T20 , Bull");
                        break;
                    case 129:
                        Console.WriteLine("T19 , T20 , D6");
                        Console.WriteLine("19 , T20 , Bull");
                        break;
                    case 128:
                        Console.WriteLine("T18 , T18 , D10");
                        Console.WriteLine("18 , T20 , Bull");
                        break;
                    case 127:
                        Console.WriteLine("T20 , T17 , D8");
                        Console.WriteLine("20 , T19 , Bull");
                        break;
                    case 126:
                        Console.WriteLine("T19 , T19 , D6");
                        Console.WriteLine("19 , T19 , Bull");
                        break;
                    case 125:
                        Console.WriteLine("T18 , T17 , D10");
                        Console.WriteLine("18 , T19 , Bull");
                        break;
                    case 124:
                        Console.WriteLine("T20 , T16 , D8");
                        Console.WriteLine("20 , T18 , Bull");
                        break;
                    case 123:
                        Console.WriteLine("T19 , T16 , D9");
                        Console.WriteLine("19 , T18 , Bull");
                        break;
                    case 122:
                        Console.WriteLine("T18 , T20 , D4");
                        Console.WriteLine("18 , T18 , Bull");
                        break;
                    case 121:
                        Console.WriteLine("T17 , 30 , D20");
                        Console.WriteLine("17 , T18 , Bull");
                        break;
                    case 120:
                        Console.WriteLine("T20 , 20 , D20");
                        break;
                    case 119:
                        Console.WriteLine("T19 , T14 , D10");
                        Console.WriteLine("19 , T20 , D20");
                        break;
                    case 118:
                        Console.WriteLine("T20 , 18 , D20");
                        Console.WriteLine("20 , T20 , D19");
                        break;
                    case 117:
                        Console.WriteLine("T20 , 17 , D20");
                        Console.WriteLine("20 , T19 , D20");
                        break;
                    case 116:
                        Console.WriteLine("T19 , 19 , D20");
                        break;
                    case 115:
                        Console.WriteLine("T19 , 18 , D20");
                        Console.WriteLine("19 , T20 , D18");
                        break;
                    case 114:
                        Console.WriteLine("T20 , 18 , D18");
                        Console.WriteLine("20 , T18 , D20");
                        break;
                    case 113:
                        Console.WriteLine("T20 , 13 , D20");
                        Console.WriteLine("20 , T19 , D18");
                        break;
                    case 112:
                        Console.WriteLine("T20 , 12 , D20");
                        Console.WriteLine("20 , T20 , D16");
                        break;
                    case 111:
                        Console.WriteLine("T18 , 14 , D20");
                        Console.WriteLine("19 , T20 , D16");
                        break;
                    case 110:
                        Console.WriteLine("T20 , 18 , D16");
                        Console.WriteLine("20 , T18 , D18");
                        break;
                    case 109:
                        Console.WriteLine("T20 , 17 , D16");
                        Console.WriteLine("20 , T19 , D16");
                        break;
                    case 108:
                        Console.WriteLine("T18 , 19 , D16");
                        Console.WriteLine("19 , T18 , D16");
                        break;
                    case 107:
                        Console.WriteLine("T19 , 18 , D16");
                        Console.WriteLine("19 , T20 , D14");
                        break;
                    case 106:
                        Console.WriteLine("T20 , 14 , D16");
                        Console.WriteLine("20 , T18 , D16");
                        break;
                    case 105:
                        Console.WriteLine("T19 , 16 , D16");
                        Console.WriteLine("19 , T18 , D16");
                        break;
                    case 104:
                        Console.WriteLine("T18 , 18 , D16");
                        Console.WriteLine("18 , T18 , D16");
                        break;
                    case 103:
                        Console.WriteLine("T20 , 11 , D16");
                        Console.WriteLine("20 , T17 , D16");
                        break;
                    case 102:
                        Console.WriteLine("T20 , 10 , D16");
                        Console.WriteLine("20 , T14 , D20");
                        break;
                    case 101:
                        Console.WriteLine("T19 , 12 , D16");
                        Console.WriteLine("19 , T14 , D20");
                        break;
                    case 100:
                        Console.WriteLine("T20 , D20 ");
                        Console.WriteLine("20 , T20 , D10");
                        break;
                    case 99:
                        Console.WriteLine("T19 , 10 , D16");
                        Console.WriteLine("19 , T20 , D10");
                        break;
                    case 98:
                        Console.WriteLine("T20 , D19 ");
                        Console.WriteLine("20 , T18 , D12 ");
                        break;
                    case 97:
                        Console.WriteLine("T19 , D20 ");
                        Console.WriteLine("19 , T18 , D12");
                        break;
                    case 96:
                        Console.WriteLine("T20 , D18 ");
                        Console.WriteLine("20 , T20 , D8 ");
                        break;
                    case 95:
                        Console.WriteLine("T19 , D19 ");
                        Console.WriteLine("19 , T20 , D8");
                        break;
                    case 94:
                        Console.WriteLine("T18 , D20 ");
                        Console.WriteLine("18 , T20 , D8 ");
                        break;
                    case 93:
                        Console.WriteLine("T19 , D18 ");
                        Console.WriteLine("19 , T14 , D16 ");
                        break;
                    case 92:
                        Console.WriteLine("T20 , D16 ");
                        Console.WriteLine("20 , T16 , D12 ");
                        break;
                    case 91:
                        Console.WriteLine("T17 , D20 ");
                        Console.WriteLine("17 , T14 , D16 ");
                        break;
                    case 90:
                        Console.WriteLine("T18 , D18 ");
                        Console.WriteLine("18 , T16 , D12 ");
                        break;
                    case 89:
                        Console.WriteLine("T19 , D16 ");
                        Console.WriteLine("19 , T18 , D8 ");
                        break;
                    case 88:
                        Console.WriteLine("T20 , D14 ");
                        Console.WriteLine("20 , 60, D4 ");
                        break;
                    case 87:
                        Console.WriteLine("T17 , D18 ");
                        Console.WriteLine("17 , T18 , D8 ");
                        break;
                    case 86:
                        Console.WriteLine("T18 , D16 ");
                        Console.WriteLine("18 , 18 , Bull");
                        break;
                    case 85:
                        Console.WriteLine("T15 , D20 ");
                        Console.WriteLine("15 , 54, D8");
                        break;
                    case 84:
                        Console.WriteLine("T20 , D12 ");
                        Console.WriteLine("20 , 14 , Bull");
                        break;
                    case 83:
                        Console.WriteLine("T17 , D16 ");
                        Console.WriteLine("17 , T18 , D6");
                        break;
                    case 82:
                        Console.WriteLine("T14 , D20 ");
                        Console.WriteLine("14 , T20 , D4");
                        break;
                    case 81:
                        Console.WriteLine("T19 , D12 ");
                        Console.WriteLine("19 , T14 , D10");
                        break;
                    case 80:
                        Console.WriteLine("T20 , D10 ");
                        Console.WriteLine("20 , 20 , D20");
                        break;
                    case 79:
                        Console.WriteLine("T19 , D11 ");
                        Console.WriteLine("19 , 20 , D20");
                        break;
                    case 78:
                        Console.WriteLine("T18 , D12 ");
                        Console.WriteLine("18 , 20 , D20");
                        break;
                    case 77:
                        Console.WriteLine("T19 , D10 ");
                        Console.WriteLine("19 , 18 , D20");
                        break;
                    case 76:
                        Console.WriteLine("T20 , D8 ");
                        Console.WriteLine("20 , T16 , D4");
                        Console.WriteLine("20 , 16 , D20");
                        break;
                    case 75:
                        Console.WriteLine("T17 , D12 ");
                        Console.WriteLine("17 , 18 , D20");
                        break;
                    case 74:
                        Console.WriteLine("T14 , D16 ");
                        Console.WriteLine("14 , 20 , D20");
                        break;
                    case 73:
                        Console.WriteLine("T19 , D8 ");
                        Console.WriteLine("19 , 14 , D20");
                        break;
                    case 72:
                        Console.WriteLine("T16 , D12 ");
                        Console.WriteLine("16 , T16 , D4");
                        Console.WriteLine("16 , 24(T8) , D16");
                        Console.WriteLine("16 , 16 , D20");
                        break;
                    case 71:
                        Console.WriteLine("T13 , D16 ");
                        Console.WriteLine("13 , 18 , D20");
                        break;
                    case 70:
                        Console.WriteLine("T18 , D8 ");
                        Console.WriteLine("18 , 20 , D16");
                        break;
                    case 69:
                        Console.WriteLine("T15 , D12 ");
                        Console.WriteLine("15 , 14 , D20");
                        break;
                    case 68:
                        Console.WriteLine("T20 , D4 ");
                        Console.WriteLine("20 , 16 , D16");
                        break;
                    case 67:
                        Console.WriteLine("T17 , D8 ");
                        Console.WriteLine("17 , 18 , D16");
                        break;
                    case 66:
                        Console.WriteLine("T14 , D12 ");
                        Console.WriteLine("14 , 20 , D16");
                        break;
                    case 65:
                        Console.WriteLine("T11 , D16 ");
                        Console.WriteLine("11 , 12 , D16");
                        break;
                    case 64:
                        Console.WriteLine("T16 , D8 ");
                        Console.WriteLine("16 , 16 , D16");
                        break;
                    case 63:
                        Console.WriteLine("T17 , D6 ");
                        Console.WriteLine("17 , 14 , D16");
                        break;
                    case 62:
                        Console.WriteLine("T14 , D10 ");
                        Console.WriteLine("14 , D16 ");
                        break;
                    case 61:
                        Console.WriteLine("T15 , D8 ");
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

        //internal unsafe struct CONSOLE_FONT_INFO_EX
        //{
        //    internal uint cbSize;
        //    internal uint nFont;
        //    internal COORD dwFontSize;
        //    internal int FontFamily;
        //    internal int FontWeight;
        //    internal fixed char FaceName[LF_FACESIZE];
        //}

        //internal struct COORD
        //{
        //    internal short X;
        //    internal short Y;

        //    internal COORD(short x, short y)
        //    {
        //        X = x;
        //        Y = y;
        //    }
        //}

        //private const int STD_OUTPUT_HANDLE = -11;
        //private const int TMPF_TRUETYPE = 4;
        //private const int LF_FACESIZE = 32;
        //private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        //[DllImport("kernel32.dll", SetLastError = true)]
        //static extern bool SetCurrentConsoleFontEx(
        //    IntPtr consoleOutput,
        //    bool maximumWindow,
        //    ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        //[DllImport("kernel32.dll", SetLastError = true)]
        //static extern IntPtr GetStdHandle(int dwType);


        //public static void SetConsoleFont(string fontName = "Lucida Console", short fontSizeX = 8, short fontSizeY = 16)
        //{
        //    unsafe
        //    {
        //        IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
        //        if (hnd != INVALID_HANDLE_VALUE)
        //        {
        //            CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
        //            info.cbSize = (uint)Marshal.SizeOf(info);

        //            CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
        //            newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
        //            newInfo.FontFamily = TMPF_TRUETYPE;
        //            IntPtr ptr = new IntPtr(newInfo.FaceName);
        //            Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

        //            newInfo.dwFontSize = new COORD(fontSizeX, fontSizeY);
        //            newInfo.FontWeight = 700; // Bold font
        //            SetCurrentConsoleFontEx(hnd, false, ref newInfo);
        //        }
        //    }
        //}


    }
}

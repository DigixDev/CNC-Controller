using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup.Localizer;

namespace CNC_Controller.Core
{
    public class GCodeLoader
    {
        private static List<string> Scopes { get; set; } = new List<string>();

        public static IList<Models.InputDataModel> Parser(string fileName)
        {
            var list=new List<Models.InputDataModel>();
            var reader = File.OpenText(fileName);

            while (reader.EndOfStream==false)
            {
                var line = reader.ReadLine().Trim();

                var data = ParseLine(line.ToUpper());
                list.Add(data);
            }

            return list;
        }

        public static Models.InputDataModel ParseLine(string line)
        {
            var data = new Models.InputDataModel();
            double value;
            char ch;

            while (line.Length > 0)
            {
                ch = GetChar(ref line);
                TrimLine(ref line);
                if (ch == 'N')
                {
                    data.nn = (uint) GetDouble(ref line);
                }

                if (ch == '%')
                {
                    data.g00 = 1;
                }

                if (ch == 'O')
                {
                    data.sc = 0;
                    data.g00 = 2;
                    Scopes.Add($"{ch}{GetNumberString(ref line)}");
                }

                if (ch == '/')
                {
                    data.g00 = 3;
                }

                if (ch == '(' || ch == ';' || ch == ':')
                {
                    data.sc = (ushort) Scopes.Count;
                    data.g00 = 4;
                    Scopes.Add($"{ch}{GetNumberString(ref line)}");
                }

                if (ch == 'I')
                {
                    data.ii = (uint)GetDouble(ref line);
                }

                if (ch == 'J')
                {
                    data.jj = (uint)GetDouble(ref line);
                }

                if (ch == 'K')
                {
                    data.kk = (uint)GetDouble(ref line);
                }

                if (ch == 'R')
                {
                    data.rr = (uint)GetDouble(ref line);
                }

                if (ch == 'P')
                {
                    data.pp = (uint)GetDouble(ref line);
                }

                if (ch == 'Q')
                {
                    data.qq = (uint)GetDouble(ref line);
                }

                if (ch == 'L')
                {
                    data.ll = (uint)GetDouble(ref line);
                }

                if (ch == 'T')
                {
                    data.tt = (ushort) GetDouble(ref line);
                }

                if (ch == 'H')
                {
                    data.hh = (ushort)GetDouble(ref line);
                }

                if (ch == 'D')
                {
                    data.dd = (ushort)GetDouble(ref line);
                }

                if (ch == 'M')
                {
                    data.mm = (byte)GetDouble(ref line);
                }

                if (ch == 'F')
                {
                    data.ff = GetDouble(ref line);
                }

                if (ch == 'S')
                {
                    data.ss = GetDouble(ref line);
                }

                if (ch == 'G')
                {
                    value = GetDouble(ref line);
                    switch (value)
                    {
                        case var n when (n >= 0 && n <= 3):
                            data.g00 = (ushort) value;
                            break;
                        case 4:
                            data.g04 = (ushort) value;
                            break;
                        case var n when (n >= 17 && n <= 19):
                            data.g17 = (ushort) value;
                            break;
                        case var n when (n >= 28 && n <= 30):
                            data.g28 = (byte) value;
                            break;
                        case var n when (n >= 40 && n <= 42):
                            data.g41 = (byte) value;
                            break;
                        case 43.4:
                            data.g43 = 143;
                            break;
                        case var n when (n >= 40 && n <= 42):
                            data.g41 = (byte) value;
                            break;
                        case 43:
                        case 44:
                        case 49:
                            data.g41 = (byte) value;
                            break;
                        case var n when (n >= 53 && n <= 59):
                            data.g54 = (byte) value;
                            break;
                        case 68.2:
                            data.g68 = 168;
                            break;
                        case var n when (n >= 73 && n <= 85):
                            data.g81 = (byte) n;
                            break;
                        case 90:
                        case 91:
                            data.g90 = (byte) value;
                            break;
                        case 98:
                        case 99:
                            data.g98 = (byte) value;
                            break;
                    }
                }
            }

            return data;
        }

        public static string GetNumberString(ref string line)
        {
            var mc = Regex.Match(line, "^[^\\s]+");
            if (mc.Success)
            {
                TrimLine(ref line, mc.Value.Length);
                return mc.Value;
            }

            return "-1";
        }

        public static char GetChar(ref string line)
        {
            line = line.Trim();
            var ch = ' ';

            if (line.Length > 0)
            {
                ch = line[0];
                line = line.Substring(1).Trim();
            }

            return ch;
        } 

        public static double GetDouble(ref string line) => Convert.ToDouble(GetNumberString(ref line));
      
        public static int GetInt(ref string line) => Convert.ToInt32(GetNumberString(ref line));
      
        public static byte GetByte(ref string line) => Convert.ToByte(GetNumberString(ref line));

        public static void TrimLine(ref string line, int len = 0) => line = line.Substring(Math.Min(len, line.Length)).Trim();
    }
}

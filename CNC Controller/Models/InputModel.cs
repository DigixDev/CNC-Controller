using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC_Controller.Models
{
    public class InputDataModel   //Read data single statement structure
    {
        public double th1, th2, th3, th4, th5, th6, th7, th8;//1-8-axis coordinates
        public double ii, jj, kk, rr, pp, qq, ll, ff, ss;//Arc, loss, length
        public uint nn;//N line number
        public ushort sc;//Comment string number
        public ushort tt, hh, dd;//Tool number, compensation number, number of calls
        public ushort g00;// "%"  "O"  "/"  ";"
        public ushort g01;//G00,G01,G02,G03
        public ushort g04;//G04
        //	unsigned char g16;//G15,G16
        public uint g17;//G17,G18,G19
        public byte g28;//G28,G29,G30
        public byte g41;//G40,G41,G42
        public byte g43;//G43,G44,G49
        public byte g54;//G53,G54-G59
        //	unsigned char g64;//G63,G64
        public byte g68;//G68,G69
        public byte g81;//G80,G81,G82,G83,G84,G85,G73,G74,G76
        public byte g90;//G90,G91
        public byte g98;//G98,G99
        public byte mm;//M´úÂë

        public static InputDataModel Create()
        {
            return new InputDataModel()
            {
                g00 = 0,
                g01 = 255,
                g04 = 0, 
                g17 = 0, g28 = 0, g41 = 0, g43 = 0, g54 = 0,
                g68 = 0, g81 = 0, g90 = 0, g98 = 0,
                th1 = 0.00000012, th2 = 0.00000012, th3 = 0.00000012, th4 = 0.00000012,
                th5 = 0.00000012, th6 = 0.00000012, th7 = 0.00000012, th8 = 0.00000012,
                ii = 0.00000012, jj = 0.00000012, kk = 0.00000012, rr = 0.00000012,
                pp = 0.00000012, qq = 0.00000012, ll = 0.00000012, ff = 0.00000012,
                tt = 255, hh = 255, dd = 255, mm = 255, nn = 0, ss = 0.00000012
            };
        }
	}
}

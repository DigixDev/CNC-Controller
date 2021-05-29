using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC_Controller.Models
{
    public class USB2//Read data single statement structure
    {
        public double th1, th2, th3, th4, th5, th6, th7, th8;//1-8-axis coordinates
        public double ii, jj, kk, rr, pp, qq, ll, ff, ss;//Arc, loss, length
        public uint nn;//N line number
        public ushort sc;//Comment string number
        public byte tt, hh, dd;//Tool number, compensation number, number of calls
        public byte g00;// "%"  "O"  "/"  ";"
        public byte g01;//G00,G01,G02,G03
        public byte g04;//G04
        //	unsigned char g16;//G15,G16
        public byte g17;//G17,G18,G19
        public byte g28;//G28,G29,G30
        public byte g41;//G40,G41,G42
        public byte g43;//G43,G44,G49
        public byte g54;//G53,G54-G59
        //	unsigned char g64;//G63,G64
        public byte g68;//G68,G69
        public byte g81;//G80,G81,G82,G83,G84,G85,G73,G74,G76
        public byte g90;//G90,G91
        public byte g98;//G98,G99
        public byte mm;//M代码
    };
    
}

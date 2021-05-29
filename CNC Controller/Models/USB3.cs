using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC_Controller.Models
{
    public class USB3//For data calculation
    {
        public double th1, th2, th3, th4, th5, th6, th7, th8;//1-8-axis coordinates
        public double ii, jj, kk, rr, pp, qq, ll, ff, ss;//Arc, loss, length
        public uint nn;//N line number
        public ushort sc;//Comment string number
        public byte tt, hh, dd;//Tool number, compensation number, number of calls
        public byte g00;// "%"  "O"  "/"  ";"
        public byte g01;//G00,G01,G02,G03
        public byte g04;//G04
        public byte g16;//G15,G16
        public byte g17;//G17,G18,G19
        public byte g28;//G28,G29,G30
        public byte g41;//G40,G41,G42
        public byte g43;//G43,G44,G49
        public byte g54;//G53,G54-G59
        public byte g64;//G63,G64
        public byte g68;//G68,G69
        public byte g81;//G80,G81,G82,G83,G84,G85,G73,G74,G76
        public byte g90;//G90,G91
        public byte g98;//G98,G99
        public byte mm;//M code

        public double ti1, ti2, ti3, ti4, ti5, ti6, ti7, ti8;//1-8-axis incremental coordinates
        public double u0, v0, w0, u1, v1, w1;//Vector 1
        public double va, vb, vc, vd, ve;//Vector 2 Angle 2
        public double h0, h1, d0, d1, l0, l1, a1;//Length compensation, diameter compensation, length, angle
        public double cy01, cy02, cy03, cy04, cy05, cy06, cy07, cy08;//Workpiece coordinate origin
        public double cy11, cy12, cy13, cy14, cy15, cy16, cy17, cy18, cy19;//Workpiece coordinate system vector
        public bool TCPM;//RTCP
    };
}

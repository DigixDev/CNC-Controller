using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNC_Controller.Models;

namespace CNC_Controller.Core
{
    public class Global
    {
        public const int DataL = 4196;     /* Define the length of DMA transfer 7268*/
        public static byte[] sendbuf=new byte[DataL], recbuf=new byte[129];  //Send and receive data array
                                                    ////////////////////////////////////////////////////////////////////////////////
        public static double fish_x05 = 0.0, fish_y05 = 0.0, fish_z05 = 0.0, fish_a05 = 0.0, fish_b05 = 0.0, fish_c05 = 0.0, fish_d05 = 0.0, fish_e05 = 0.0;//
        public static double fish_x06 = 0.0, fish_y06 = 0.0, fish_z06 = 0.0, fish_a06 = 0.0, fish_b06 = 0.0, fish_c06 = 0.0, fish_d06 = 0.0, fish_e06 = 0.0;//
        public static double fish_x07 = 0.0, fish_y07 = 0.0, fish_z07 = 0.0, fish_a07 = 0.0, fish_b07 = 0.0, fish_c07 = 0.0, fish_d07 = 0.0, fish_e07 = 0.0;//Theoretical RTCP coordinates
        public static double fish_x08 = 0.0, fish_y08 = 0.0, fish_z08 = 0.0, fish_a08 = 0.0, fish_b08 = 0.0, fish_c08 = 0.0, fish_d08 = 0.0, fish_e08 = 0.0;//Provisional calculation
        public static double fish_x10 = 0.0, fish_y10 = 0.0, fish_z10 = 0.0, fish_a10 = 0.0, fish_b10 = 0.0, fish_c10 = 0.0, fish_d10 = 0.0, fish_e10 = 0.0;//Relative reference coordinates
        public static byte zroe_x = 0, zroe_y = 0, zroe_z = 0, zroe_a = 0, zroe_b = 0, zroe_c = 0, zroe_d = 0, zroe_e = 0;//Back to zero
                                                                                                            ////////////////////////////////////////////////////////////////////////////////
        public static bool fish1010 = true, fish1020 = true, fish1052 = false, fish1053 = false, fish1054 = false, fish1055 = false, fish1058 = false, fish1059 = true, fish1057 = false;
        public static int fish_wparam1 = 0, fish_wparam2 = 0, fish_wparam3 = 0;//Manual and home button
        public static int fish1050 = 1, fish_o1 = 0, fish_o2 = 0, oeed1 = 0, oeed2 = 0, fish_errer = 0;//Mode, number of tooling, alarm number
        public static int iDraw0, iDraw1, iDraw2, iDraw3, iDraw4, iDraw5, iDraw6, iDraw7, iDraw8, iDraw9;
        public static byte[] fish_buf = new byte[256], fish_900 = new byte[256];
        public static byte[,] oeed=new byte[1000,60];
        public static byte fish_tt;
        public static byte[] Name_Draw0=new byte[120];
        public static byte[] f_nbmp=new byte[256];
        public static double fish_goto = 0.0, reed1 = 0.0, reed2 = 0.0;//Temporary angle calculated during G02/G03 interpolation
        public static double[] tool_d=new double[13], tool_r=new double[13], tool_l=new double[13], tool_a=new double[13], tool_b=new double[13];//Tool table information
        public static double[] work_x=new double[8], work_y=new double[8], work_z=new double[8], work_a=new double[8], work_b=new double[8], work_c=new double[8], work_d=new double[8], work_e=new double[8];//Workpiece coordinate system
        public static double[] tool_xA=new double[13], tool_yA=new double[13], tool_zA=new double[13], tool_aA=new double[13], tool_bA=new double[13], tool_cA=new double[13], tool_uA=new double[13], tool_vA=new double[13];//Tool change A position
        public static double[] tool_xB=new double[13], tool_yB=new double[13], tool_zB=new double[13], tool_aB=new double[13], tool_bB=new double[13], tool_cB=new double[13], tool_uB=new double[13], tool_vB=new double[13];//Tool change B position
        public static double[] tool_xC=new double[13], tool_yC=new double[13], tool_zC=new double[13], tool_aC=new double[13], tool_bC=new double[13], tool_cC=new double[13], tool_uC=new double[13], tool_vC=new double[13];//Tool change C position
        public static double fish_jgbl = 1.0, fish_zzbl = 1.0, fish_feed = 0.0;//Initial pulse screen rate Feed spindle override

        public static double fishg83x = 0.00000012, fishg83y = 0.00000012, fishg83z = 0.00000012, fishg83a = 0.00000012, fishg83b = 0.00000012, fishg83c = 0.00000012, fishg83d = 0.00000012, fishg83e = 0.00000012;
        public static double fishg83zz, fishg83r = 0.00000012, fishg83p = 0.00000012, fishg83q = 0.00000012, fishg83l = 0.00000012;
        public static uint fish1016 = 0;
        public static double fish_time1 = 0.0, fish_time2 = 0.0, fish_time3 = 0, fish_sl = 0;//Handwheel
        public static uint fish_ii = 0, fish_jj = 0, fish_kk = 0, fish_i2 = 100000, fish_i4 = 10000, fish_da = 0;//Number of programs 0-4294967296
        public static byte fish_mz = 0, fish_fx = 0, fish_aa = 0, fish_bb = 0, fish_cc = 0, fish_jg20 = 0;  //Pulse, direction
        public static byte fish1061 = 0, fish1062 = 0, fish1063 = 0, fish1064 = 0, fish1065 = 0, fish1066 = 32, fish1067 = 0, fish1068 = 0;//Relay

        public static USB7[] fishq = new USB7[9];
        public static USB6[] fishj=new USB6[10000];
        public static USB3 fishm1=new USB3();
        public static USB3 fishm2=new USB3();
        public static USB3 fishm3=new USB3();
        public static USB3 fishm4=new USB3();
        public static USB3 fishm5=new USB3();
        public static USB2[] fishg =new USB2[fish_i2];
    }
}

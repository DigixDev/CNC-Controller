using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNC_Controller.Models;
using Microsoft.Win32;
using static CNC_Controller.Core.Global;

namespace CNC_Controller.Core
{
    public class SettingLoader
    {
        public static void LoadSetting(string settingFile)
        {
            //var dlg = new OpenFileDialog();
            //dlg.FileName = "fish.txt";
            //if (dlg.ShowDialog() == true)
            //    settingFile = dlg.FileName;

            var lines = File.ReadAllLines(settingFile);

            Splitter.Split(lines, "Machine type", fishq, "q10");
            Splitter.Split(lines, "System resolution", fishq, "q11");
            Splitter.Split(lines, "System pulse rate", fishq, "q19");
            Splitter.Split(lines, "System movement speed", fishq, "q12");
            Splitter.Split(lines, "System acceleration", fishq, "q13");
            Splitter.Split(lines, "Handwheel acceleration parameters", fishq, "q15");
            Splitter.Split(lines, "Acceleration limit angle", fishq, "q16");
            Splitter.Split(lines, "Minimum acceleration arc", fishq, "q17");
            Splitter.Split(lines, "Measuring the long distance of the knife", fishq, "q20");
            Splitter.Split(lines, "Z-direction position of tool gauge", fishq, "q22");
            Splitter.Split(lines, "Spindle tool", ref fish_tt);
            Splitter.Split(lines, "High and low", fishq, "q1");
            Splitter.Split(lines, "Number of workpieces", ref fish_o2);
            Splitter.Split(lines, "Axis label", fishq, "q1", 1);
            Splitter.Split(lines, "Axis type", fishq, "q2", 1);
            Splitter.Split(lines, "Axis direction", fishq, "q3", 1);
            Splitter.Split(lines, "Coordinate axis X position", fishq, "q4", 1);
            Splitter.Split(lines, "Coordinate axis Y position", fishq, "q5", 1);
            Splitter.Split(lines, "Coordinate axis Z position", fishq, "q6", 1);
            Splitter.Split(lines, "Coordinate axis U vector", fishq, "q7", 1);
            Splitter.Split(lines, "Coordinate axis V vector", fishq, "q8", 1);
            Splitter.Split(lines, "Coordinate axis W vector", fishq, "q9", 1);
            Splitter.Split(lines, "Output IO port", fishq, "q10", 1);
            Splitter.Split(lines, "Resolution", fishq, "q11", 1);
            Splitter.Split(lines, "Maximum moving speed", fishq, "q12", 1);
            Splitter.Split(lines, "Acceleration of each axis", fishq, "q13", 1);
            Splitter.Split(lines, "Initial speed of each axis", fishq, "q14", 1);
            Splitter.Split(lines, "Minimum position", fishq, "q15", 1);
            Splitter.Split(lines, "Maximum position", fishq, "q16", 1);
            Splitter.Split(lines, "Retreat speed", fishq, "q17", 1);
            Splitter.Split(lines, "Zero speed", fishq, "q18", 1);
            Splitter.Split(lines, "Home direction", fishq, "q19", 1);
            Splitter.Split(lines, "Backlash", fishq, "q20", 1);
            Splitter.Split(lines, "Feedback resolution", fishq, "q21", 1);
            Splitter.Split(lines, "Feedback absolute value", fishq, "q22", 1);
            Splitter.Split(lines, "Tracking error", fishq, "q23", 1);
            if (lines.Any(x => x.Contains("Breakpoint location")))
            {
                Splitter.Split(lines, "Breakpoint location", fishq, "q50", 1);
                fish_x07 = fishq[1].q50;
                fish_y07 = fishq[2].q50;
                fish_z07 = fishq[3].q50;
                fish_a07 = fishq[4].q50;
                fish_b07 = fishq[5].q50;
                fish_c07 = fishq[6].q50;
                fish_d07 = fishq[7].q50;
                fish_e07 = fishq[8].q50;
                fishm2.th1 = fishq[1].q50;
                fishm2.th2 = fishq[2].q50;
                fishm2.th3 = fishq[3].q50;
                fishm2.th4 = fishq[4].q50;
                fishm2.th5 = fishq[5].q50;
                fishm2.th6 = fishq[6].q50;
                fishm2.th7 = fishq[7].q50;
                fishm2.th8 = fishq[8].q50;
                fish_x10 = fishq[1].q50;
                fish_y10 = fishq[2].q50;
                fish_z10 = fishq[3].q50;
                fish_a10 = fishq[4].q50;
                fish_b10 = fishq[5].q50;
                fish_c10 = fishq[6].q50;
                fish_d10 = fishq[7].q50;
                fish_e10 = fishq[8].q50;
                for (var n = 0; n < 10000; n++)
                {
                    if(fishj[n]==null)
                        fishj[n]=new USB6();

                    fishj[n].g = 0;
                    fishj[n].x = fishq[1].q50;
                    fishj[n].y = fishq[2].q50;
                    fishj[n].z = fishq[3].q50;
                }
            }

            Splitter.Split(lines, "First reference point", fishq, "q51", 1);
            Splitter.Split(lines, "Second reference point", fishq, "q52", 1);
            Splitter.Split(lines, "Workpiece coordinate system 0", fishq, "q52", 1);
            Splitter.SplitDouble(lines, "Workpiece coordinate system 0", 0, work_x, work_y, work_z, work_a, work_b,
                work_c, work_d, work_e);
            Splitter.SplitDouble(lines, "Workpiece coordinate system 1", 1, work_x, work_y, work_z, work_a, work_b,
                work_c, work_d, work_e);
            Splitter.SplitDouble(lines, "Workpiece coordinate system 2", 2, work_x, work_y, work_z, work_a, work_b,
                work_c, work_d, work_e);
            Splitter.SplitDouble(lines, "Workpiece coordinate system 3", 3, work_x, work_y, work_z, work_a, work_b,
                work_c, work_d, work_e);
            Splitter.SplitDouble(lines, "Workpiece coordinate system 4", 4, work_x, work_y, work_z, work_a, work_b,
                work_c, work_d, work_e);
            Splitter.SplitDouble(lines, "Workpiece coordinate system 5", 5, work_x, work_y, work_z, work_a, work_b,
                work_c, work_d, work_e);
            Splitter.SplitDouble(lines, "Workpiece coordinate system 6", 6, work_x, work_y, work_z, work_a, work_b,
                work_c, work_d, work_e);
            Splitter.SplitDouble(lines, "Tool 0", 0, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 1", 1, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 2", 2, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 3", 3, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 4", 4, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 5", 5, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 6", 6, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 7", 7, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 8", 8, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 9", 9, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 10", 10, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 11", 11, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool 12", 12, tool_d, tool_r, tool_l, tool_a, tool_b);
            Splitter.SplitDouble(lines, "Tool change position 0A", 0, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 0B", 0, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 0C", 0, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 1A", 1, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 1B", 1, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 1C", 1, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 2A", 2, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 2B", 2, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 2C", 2, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 3A", 3, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 3B", 3, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 3C", 3, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 4A", 4, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 4B", 4, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 4C", 4, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 5A", 5, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 5B", 5, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 5C", 5, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 6A", 6, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 6B", 6, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 6C", 6, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 7A", 7, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 7B", 7, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 7C", 7, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 8A", 8, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 8B", 8, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 8C", 8, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 9A", 9, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 9B", 9, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 9C", 9, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 10A", 10, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 10B", 10, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 10C", 10, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 11A", 11, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 11B", 11, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 11C", 11, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);
            Splitter.SplitDouble(lines, "Tool change position 12A", 12, tool_xA, tool_yA, tool_zA, tool_aA, tool_bA,
                tool_cA, tool_uA, tool_vA);
            Splitter.SplitDouble(lines, "Tool change position 12B", 12, tool_xB, tool_yB, tool_zB, tool_aB, tool_bB,
                tool_cB, tool_uB, tool_vB);
            Splitter.SplitDouble(lines, "Tool change position 12C", 12, tool_xC, tool_yC, tool_zC, tool_aC, tool_bC,
                tool_cC, tool_uC, tool_vC);

            sendbuf[0] = fish_fx = 0; //Initialization direction
            fishq[0].q14 = fishq[0].q11 * fishq[0].q19 * 60.0; //Calculate the theoretical maximum speed

            fishm2.g00 = 0;fishm2.g01 = 1;fishm2.g04 = 0;fishm2.g16 = 15;
            fishm2.g17 = 17;fishm2.g28 = 0;fishm2.g41 = 40;fishm2.g43 = 49;fishm2.g54 = 1;
            fishm2.g64 = 63;fishm2.g68 = 69;fishm2.g81 = 80;
            fishm2.g90 = 90;fishm2.g98 = 98;
            fishm2.ii = 0.0;fishm2.jj = 0.0;fishm2.kk = 0.0;fishm2.rr = 0.0;
            fishm2.pp = 0.0;fishm2.qq = 0.0;fishm2.ll = 0.0;fishm2.ff = 1000;
            fishm2.tt = fish_tt;fishm2.hh = 0;
            fishm2.dd = 0; fishm2.mm = 255;fishm2.ss = 12000;

            fishm2.u0 = 0.0;
            fishm2.v0 = 0.0;
            fishm2.w0 = 0.0;fishm2.u1 = 0.0;
            fishm2.v1 = 0.0;fishm2.w1 = 0.0;
            fishm2.va = 0.0;fishm2.vb = 0.0;
            fishm2.vc = 0.0;fishm2.vd = 0.0;fishm2.ve = 0.0;
            fishm2.h0 = 0.0;fishm2.h1 = 0.0;
            fishm2.d0 = 0.0;fishm2.d1 = 0.0;
            fishm2.cy01 = work_x[fishm2.g54] + work_x[0];
            fishm2.cy02 = work_y[fishm2.g54] + work_y[0];
            fishm2.cy03 = work_z[fishm2.g54] + work_z[0];
            fishm2.cy04 = work_a[fishm2.g54] + work_a[0];
            fishm2.cy05 = work_b[fishm2.g54] + work_b[0];
            fishm2.cy06 = work_c[fishm2.g54] + work_c[0];
            fishm2.cy07 = work_d[fishm2.g54] + work_d[0];
            fishm2.cy08 = work_e[fishm2.g54] + work_e[0];
            fishm2.cy11 = 1.0;
            fishm2.cy12 = 0.0;
            fishm2.cy13 = 0.0;
            fishm2.cy14 = 0.0;
            fishm2.cy15 = 1.0;
            fishm2.cy16 = 0.0;
            fishm2.cy17 = 0.0;
            fishm2.cy18 = 0.0;
            fishm2.cy19 = 1.0;
        }
    }
}

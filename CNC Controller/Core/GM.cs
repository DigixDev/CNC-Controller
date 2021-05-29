using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CNC_Controller.Core.Global;

namespace CNC_Controller.Core
{
    public class GM
    {
        public USB2 usbcncinit()    //Initialize reading data
        {
            var fishw=new USB2();
            g00 = 0;
            g01 = 255;
            g04 = 0;
            g17 = 0;
            g28 = 0;
            g41 = 0;
            g43 = 0;
            g54 = 0;
            g68 = 0;
            g81 = 0;
            g90 = 0;
            g98 = 0;
            th1 = 0.00000012;
            th2 = 0.00000012;
            th3 = 0.00000012;
            th4 = 0.00000012;
            th5 = 0.00000012;
            th6 = 0.00000012;
            th7 = 0.00000012;
            th8 = 0.00000012;
            ii = 0.00000012;
            jj = 0.00000012;
            kk = 0.00000012;
            rr = 0.00000012;
            pp = 0.00000012;
            qq = 0.00000012;
            ll = 0.00000012;
            ff = 0.00000012;
            tt = 255;
            hh = 255;
            dd = 255;
            mm = 255;
            nn = 0;//-1;
            ss = 0.00000012;
            return fishw;
        }

        public USB3 usbcncGOGO(USB3 fishw)  //Calculate end point coordinates
        {
            th1 = th1 + ti1;//Mechanical theoretical point coordinates
            th2 = th2 + ti2;
            th3 = th3 + ti3;
            th4 = th4 + ti4;
            th5 = th5 + ti5;
            th6 = th6 + ti6;
            th7 = th7 + ti7;
            th8 = th8 + ti8;
            h1 = h0 + h1;
            d1 = d0 + d1;
            return fishw;
        }

		public USB4 usbcncRTCP(USB3 fishm7)//Calculate RTCP coordinates
		{
			double pti01, pti02, pti03, pti04, pti05, pti06, pti07, pti08, pti09, pti10, pti11, pti12, pti13, pti14, pti15, pti16, pti17, pti18;
			USB4 fishm8;
			if (fishm7.TCPM && (fishq[0].q10 == 7546 || fishq[0].q10 == 7556 || fishq[0].q10 == 7545 || fishq[0].q10 == 7554))//Double turntable
			{
				pti04 = Math.Cos(fishm7.th5 * Math.PI / 180.0);
				pti05 = Math.Sin(fishm7.th5 * Math.PI / 180.0);
				pti06 = (fishq[5].q7 * fishm7.th1 + fishq[5].q8 * fishm7.th2 + fishq[5].q9 * fishm7.th3) * (1.0 - Math.Cos(fishm7.th5 * Math.PI / 180.0));
				pti01 = fishm7.th1 * pti04 + (fishq[5].q9 * fishm7.th2 - fishq[5].q8 * fishm7.th3) * pti05 + fishq[5].q7 * pti06;
				pti02 = fishm7.th2 * pti04 + (fishq[5].q7 * fishm7.th3 - fishq[5].q9 * fishm7.th1) * pti05 + fishq[5].q8 * pti06;
				pti03 = fishm7.th3 * pti04 + (fishq[5].q8 * fishm7.th1 - fishq[5].q7 * fishm7.th2) * pti05 + fishq[5].q9 * pti06;
				pti07 = Math.Cos(fishm7.th4 * Math.PI / 180.0);
				pti08 = Math.Sin(fishm7.th4 * Math.PI / 180.0);
				pti09 = (fishq[4].q7 * (pti01 + fishq[4].q4) + fishq[4].q8 * (pti02 + fishq[4].q5) + fishq[4].q9 * (pti03 + fishq[4].q6)) * (1.0 - Math.Cos(fishm7.th4 *Math.PI / 180.0));
				fishm8.th1 = (pti01 + fishq[4].q4) * pti07 + (fishq[4].q9 * (pti02 + fishq[4].q5) - fishq[4].q8 * (pti03 + fishq[4].q6)) * pti08 + fishq[4].q7 * pti09 - fishq[4].q4;
				fishm8.th2 = (pti02 + fishq[4].q5) * pti07 + (fishq[4].q7 * (pti03 + fishq[4].q6) - fishq[4].q9 * (pti01 + fishq[4].q4)) * pti08 + fishq[4].q8 * pti09 - fishq[4].q5;
				fishm8.th3 = (pti03 + fishq[4].q6) * pti07 + (fishq[4].q8 * (pti01 + fishq[4].q4) - fishq[4].q7 * (pti02 + fishq[4].q5)) * pti08 + fishq[4].q9 * pti09 - fishq[4].q6 + fishm7.h0;
				fishm8.th4 = fishm7.th4;
				fishm8.th5 = fishm7.th5;
				fishm8.th6 = fishm7.th6;
				fishm8.th7 = fishm7.th7;
				fishm8.th8 = fishm7.th8;
			}
			else if (fishm7.TCPM && (fishq[0].q10 == 7531 || fishq[0].q10 == 7532 || fishq[0].q10 == 7512 || fishq[0].q10 == 7521))//Double swing head
			{
				pti04 = Math.Cos(-fishm7.th5 * Math.PI / 180.0);
				pti05 = Math.Sin(-fishm7.th5 * Math.PI / 180.0);
				pti06 = (fishq[5].q7 * fishq[5].q4 + fishq[5].q8 * fishq[5].q5 + fishq[5].q9 * (fishq[5].q6 - fishm7.h0)) * (1.0 - Math.Cos(-fishm7.th5 *Math.PI / 180.0));
				pti01 = fishq[5].q4 * pti04 + (fishq[5].q9 * fishq[5].q5 - fishq[5].q8 * (fishq[5].q6 - fishm7.h0)) * pti05 + fishq[5].q7 * pti06;
				pti02 = fishq[5].q5 * pti04 + (fishq[5].q7 * (fishq[5].q6 - fishm7.h0) - fishq[5].q9 * fishq[5].q4) * pti05 + fishq[5].q8 * pti06;
				pti03 = (fishq[5].q6 - fishm7.h0) * pti04 + (fishq[5].q8 * fishq[5].q4 - fishq[5].q7 * fishq[5].q5) * pti05 + fishq[5].q9 * pti06;
				pti07 = Math.Cos(-fishm7.th4 * Math.PI / 180.0);
				pti08 = Math.Sin(-fishm7.th4 * Math.PI / 180.0);
				pti09 = (fishq[4].q7 * (fishq[4].q4 + pti01) + fishq[4].q8 * (fishq[4].q5 + pti02) + fishq[4].q9 * (fishq[4].q6 + pti03)) * (1 - Math.Cos(-fishm7.th4 *Math.PI / 180.0));
				fishm8.th1 = fishm7.th1 + ((fishq[4].q4 + pti01) * pti07 + (fishq[4].q9 * (fishq[4].q5 + pti02) - fishq[4].q8 * (fishq[4].q6 + pti03)) * pti08 + fishq[4].q7 * pti09);
				fishm8.th2 = fishm7.th2 + ((fishq[4].q5 + pti02) * pti07 + (fishq[4].q7 * (fishq[4].q6 + pti03) - fishq[4].q9 * (fishq[4].q4 + pti01)) * pti08 + fishq[4].q8 * pti09);
				fishm8.th3 = fishm7.th3 + ((fishq[4].q6 + pti03) * pti07 + (fishq[4].q8 * (fishq[4].q4 + pti01) - fishq[4].q7 * (fishq[4].q5 + pti02)) * pti08 + fishq[4].q9 * pti09);
				fishm8.th4 = fishm7.th4;
				fishm8.th5 = fishm7.th5;
				fishm8.th6 = fishm7.th6;
				fishm8.th7 = fishm7.th7;
				fishm8.th8 = fishm7.th8;
			}
			else if (fishm7.TCPM && (fishq[0].q10 == 7516 || fishq[0].q10 == 7526 || fishq[0].q10 == 7515 || fishq[0].q10 == 7524))//Sway
			{
				pti04 = Math.Cos(-fishm7.th4 * Math.PI / 180.0);
				pti05 = Math.Sin(-fishm7.th4 * Math.PI / 180.0);
				pti06 = (fishq[4].q7 * fishq[4].q4 + fishq[4].q8 * fishq[4].q5 + fishq[4].q9 * (fishq[4].q6 - fishm7.h0)) * (1.0 - Math.Cos(-fishm7.th4 *Math.PI / 180.0));
				pti01 = fishq[4].q4 * pti04 + (fishq[4].q9 * fishq[4].q5 - fishq[4].q8 * (fishq[4].q6 - fishm7.h0)) * pti05 + fishq[4].q7 * pti06;
				pti02 = fishq[4].q5 * pti04 + (fishq[4].q7 * (fishq[4].q6 - fishm7.h0) - fishq[4].q9 * fishq[4].q4) * pti05 + fishq[4].q8 * pti06;
				pti03 = (fishq[4].q6 - fishm7.h0) * pti04 + (fishq[4].q8 * fishq[4].q4 - fishq[4].q7 * fishq[4].q5) * pti05 + fishq[4].q9 * pti06;
				pti07 = Math.Cos(fishm7.th5 * Math.PI / 180.0);
				pti08 = Math.Sin(fishm7.th5 * Math.PI / 180.0);
				pti09 = (fishq[5].q7 * fishm7.th1 + fishq[5].q8 * fishm7.th2 + fishq[5].q9 * fishm7.th3) * (1.0 - Math.Cos(fishm7.th5 *Math.PI / 180.0));
				fishm8.th1 = fishm7.th1 * pti07 + (fishq[5].q9 * fishm7.th2 - fishq[5].q8 * fishm7.th3) * pti08 + fishq[5].q7 * pti09 - pti01;
				fishm8.th2 = fishm7.th2 * pti07 + (fishq[5].q7 * fishm7.th3 - fishq[5].q9 * fishm7.th1) * pti08 + fishq[5].q8 * pti09 - pti02;
				fishm8.th3 = fishm7.th3 * pti07 + (fishq[5].q8 * fishm7.th1 - fishq[5].q7 * fishm7.th2) * pti08 + fishq[5].q9 * pti09 - pti03;
				fishm8.th4 = fishm7.th4;
				fishm8.th5 = fishm7.th5;
				fishm8.th6 = fishm7.th6;
				fishm8.th7 = fishm7.th7;
				fishm8.th8 = fishm7.th8;
			}
			else if (fishm7.TCPM && fishq[0].q10 == 7403)
			{
				pti01 = Math.Sqrt(fishm7.th1 * fishm7.th1 + fishm7.th2 * fishm7.th2);
				if (pti01 < fishq[1].q5 + fishq[2].q5 && pti01 > Math.Abs(fishq[1].q5 + fishq[2].q5))
				{
					if (fishm7.th1 > 0)
						pti02 = 90.0 + Math.Asin(fishm7.th2 / pti01) * 180.0 / Math.PI;
					else if (fishm7.th1 < 0)
						pti02 = -90.0 - Math.Asin(fishm7.th2 / pti01) * 180.0 / Math.PI;
					else if (fishm7.th1 == 0 && fishm7.th2 > 0)
						pti02 = 180.0;
					else pti02 = 0;
					pti03 = Math.Acos((pti01 * pti01 + fishq[2].q5 * fishq[2].q5 - fishq[1].q5 * fishq[1].q5) / (2.0 * pti01 * fishq[2].q5)) * 180.0 /Math.PI;
					fishm8.th1 = pti02 + pti03;
					fishm8.th2 = 180.0 - Math.Acos((fishq[1].q5 * fishq[1].q5 + fishq[2].q5 * fishq[2].q5 - pti01 * pti01) / (2.0 * fishq[1].q5 * fishq[2].q5)) * 180.0 /Math.PI;
				}
				else fish_errer = 121;
				fishm8.th3 = fishm7.th3;
				fishm8.th4 = fishm7.th4;
				fishm8.th5 = fishm7.th5;
				fishm8.th6 = fishm7.th6;
				fishm8.th7 = fishm7.th7;
				fishm8.th8 = fishm7.th8;
			}
			else if (fishm7.TCPM && fishq[0].q10 == 7776)
			{
				if (fishm7.th4 == 0.0)//B axis rotation
				{
					pti01 = fishq[5].q6 * Math.Sin(fishm7.th5 * Math.PI / 180.0) + fishm7.th1;
					pti02 = fishm7.th2;
					pti03 = fishq[5].q6 * Math.Cos(fishm7.th5 * Math.PI / 180.0) + fishm7.th3;
				}
				else if (fishm7.th5 == 0.0)//A axis rotation
				{
					pti01 = fishm7.th1;
					pti02 = -fishq[5].q6 * Math.Sin(fishm7.th4 * Math.PI / 180.0) + fishm7.th2;
					pti03 = fishq[5].q6 * Math.Cos(fishm7.th4 * Math.PI / 180.0) + fishm7.th3;
				}
				else
				{
					pti01 = fishq[5].q6 * Math.Sin(Math.Asin(Math.Cos(Math.Atan(Math.Cos(fishm7.th5 * Math.PI / 180.0) * Math.Tan(fishm7.th4 * Math.PI / 180.0))) * Math.Sin(fishm7.th5 * Math.PI / 180.0))) + fishm7.th1;//The X coordinate at the B axis rotates around the B axis first
					pti02 = -fishq[5].q6 * Math.Sin(Math.Atan(Math.Cos(fishm7.th5 * Math.PI / 180.0) * Math.Tan(fishm7.th4 * Math.PI / 180.0))) + fishm7.th2;//The y coordinate on the B axis rotates around the B axis first
					pti03 = fishq[5].q6 * Math.Cos(Math.Atan(Math.Cos(fishm7.th5 * Math.PI / 180.0) * Math.Tan(fishm7.th4 * Math.PI / 180.0))) * Math.Cos(fishm7.th5 * Math.PI / 180.0) + fishm7.th3;//The z coordinate at the B axis rotates around the B axis first
				}
				if (Math.Sqrt((Math.Sqrt(pti01 * pti01 + pti02 * pti02) - fishq[1].q5) * (Math.Sqrt(pti01 * pti01 + pti02 * pti02) - fishq[1].q5) + (pti03 - fishq[1].q6) * (pti03 - fishq[1].q6)) < Math.Sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5) + fishq[2].q6 - 2)//Anti-overtravel, 2mm distance
				{
					if (pti01 == 0 && pti02 > 0)//Y Axis
						fishm8.th1 = 0;
					else if (pti01 > 0 && pti02 > 0)//Quadrant 1
						fishm8.th1 = Math.Atan(pti01 / pti02) * 180.0 / Math.PI;
					else if (pti01 > 0 && pti02 == 0)//X Axis
						fishm8.th1 = 90.0;
					else if (pti01 > 0 && pti02 < 0)//Quadrant 4
						fishm8.th1 = 90.0 - Math.Atan(pti02 / pti01) * 180.0 / Math.PI;
					else if (pti01 < 0 && pti02 > 0)//Quadrant 2
						fishm8.th1 = Math.Atan(pti01 / pti02) * 180.0 / Math.PI;
					else if (pti01 < 0 && pti02 == 0)//-X Axis
						fishm8.th1 = -90.0;
					else if (pti01 < 0 && pti02 < 0)//Quadrant 3
						fishm8.th1 = -90.0 - Math.Atan(pti02 / pti01) * 180.0 / Math.PI;
					else if (pti01 == 0 && pti02 < 0)//-Y Axis
						fishm8.th1 = 180.0;

					fishm8.th6 = fishm7.th6 - fishm8.th1;//TCPM C axis
					pti07 = Math.Sqrt(pti01 * pti01 + pti02 * pti02);//Y-axis coordinate after X-axis rotation (polar coordinate of end point)
					pti08 = Math.Sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5);//Length of right-angle member
					pti09 = 90 - Math.Asin(fishq[3].q6 / pti08) * 180.0 / Math.PI;//Angle 3
					pti10 = Math.Sqrt((pti07 - fishq[1].q5) * (pti07 - fishq[1].q5) + (pti03 - fishq[1].q6) * (pti03 - fishq[1].q6));//Length of connecting rod
					pti11 = Math.Asin((pti03 - fishq[1].q6) / pti10) * 180.0 / Math.PI;//1 angle
					pti12 = Math.Acos((fishq[2].q6 * fishq[2].q6 + pti10 * pti10 - pti08 * pti08) / (2 * fishq[2].q6 * pti10)) * 180.0 / Math.PI;//2 angle
					fishm8.th2 = 90.0 - pti11 - pti12;//y-axis angle
					fishm8.th3 = Math.Acos((fishq[2].q6 * fishq[2].q6 + pti08 * pti08 - pti10 * pti10) / (2 * fishq[2].q6 * pti08)) * 180.0 / Math.PI - 180.0 + pti09;//Z axis angle
					pti04 = (fishq[1].q5 + fishq[2].q6 * Math.Sin(fishm8.th2 * Math.PI / 180.0) + fishq[3].q6 * Math.Sin((-fishm8.th3 + fishm8.th2) * Math.PI / 180.0)) * Math.Sin(fishm8.th1 * Math.PI / 180.0);//X coordinate at right angle of A axis
					pti05 = (fishq[1].q5 + fishq[2].q6 * Math.Sin(fishm8.th2 * Math.PI / 180.0) + fishq[3].q6 * Math.Sin((-fishm8.th3 + fishm8.th2) * Math.PI / 180.0)) * Math.Cos(fishm8.th1 * Math.PI / 180.0);//The y coordinate at right angles to the A axis
					pti06 = fishq[1].q6 + fishq[2].q6 * Math.Cos(fishm8.th2 * Math.PI / 180.0) + fishq[3].q6 * Math.Cos((-fishm8.th3 + fishm8.th2) * Math.PI / 180.0);//Z coordinate at right angles to the A axis
					pti13 = Math.Sqrt((pti04 - fishm7.th1) * (pti04 - fishm7.th1) + (pti05 - fishm7.th2) * (pti05 - fishm7.th2) + (pti06 - fishm7.th3) * (pti06 - fishm7.th3));//Calculate the distance from the tip of the tool at a right angle to the A axis
					if (fishm7.th4 <= 90.0 + fishm8.th3 - fishm8.th2)
						fishm8.th5 = Math.Acos((fishq[5].q6 * fishq[5].q6 + fishq[3].q5 * fishq[3].q5 - pti13 * pti13) / (2 * fishq[3].q5 * fishq[5].q6)) * 180.0 / Math.PI - 90.0;
					else
						fishm8.th5 = 270.0 - Math.Acos((fishq[5].q6 * fishq[5].q6 + fishq[3].q5 * fishq[3].q5 - pti13 * pti13) / (2 * fishq[3].q5 * fishq[5].q6)) * 180.0 /Math.PI;
					pti15 = fishm8.th2 - fishm8.th3 - fishm8.th5;
					pti16 = pti01 - fishq[5].q6 * Math.Sin(pti15 * Math.PI / 180.0) * Math.Sin(fishm8.th1 * Math.PI / 180.0);//X coordinate of virtual point
					pti17 = pti02 - fishq[5].q6 * Math.Sin(pti15 * Math.PI / 180.0) * Math.Cos(fishm8.th1 * Math.PI / 180.0);//Y coordinate of virtual point
					pti18 = pti03 - fishq[5].q6 * Math.Cos(pti15 * Math.PI / 180.0);//Z coordinate at virtual point
					pti14 = Math.Sqrt((pti16 - fishm7.th1) * (pti16 - fishm7.th1) + (pti17 - fishm7.th2) * (pti17 - fishm7.th2) + (pti18 - fishm7.th3) * (pti18 - fishm7.th3));
					if (90.0 - Math.Atan(fishm7.th1 / fishm7.th2) * 180.0 / Math.PI >= 90.0 - Math.Atan(pti01 / pti02) * 180.0 / Math.PI)
						fishm8.th4 = 2.0 * Math.Asin(pti14 / 2.0 / fishq[5].q6 / Math.Cos(fishm8.th5 * Math.PI / 180.0)) * 180.0 / Math.PI;
					else
						fishm8.th4 = -2.0 * Math.Asin(pti14 / 2.0 / fishq[5].q6 / Math.Cos(fishm8.th5 * Math.PI / 180.0)) * 180.0 / Math.PI;
				}
				else fish_errer = 117;
				fishm8.th7 = fishm7.th7;
				fishm8.th8 = fishm7.th8;
			}
			else if (fishm7.TCPM && fishq[0].q10 == 7778)
			{
				pti07 = fishq[6].q4 * Math.Cos(-fishm7.th6 * Math.PI / 180.0) + fishq[6].q5 * Math.Sin(-fishm7.th6 * Math.PI / 180.0);
				pti08 = fishq[6].q5 * Math.Cos(-fishm7.th6 * Math.PI / 180.0) - fishq[6].q4 * Math.Sin(-fishm7.th6 * Math.PI / 180.0);
				pti09 = fishq[6].q6 - fishm7.h0;
				pti13 = pti07 * Math.Cos(-fishm7.th5 * Math.PI / 180.0) - pti09 * Math.Sin(-fishm7.th5 * Math.PI / 180.0);
				pti14 = pti08;
				pti15 = pti09 * Math.Cos(-fishm7.th5 * Math.PI / 180.0) + pti07 * Math.Sin(-fishm7.th5 * Math.PI / 180.0);
				pti01 = fishm7.th1 - pti13;
				pti02 = fishm7.th2 - (pti14 * Math.Cos(-fishm7.th4 * Math.PI / 180.0) + pti15 * Math.Sin(-fishm7.th4 * Math.PI / 180.0));
				pti03 = fishm7.th3 - (pti15 * Math.Cos(-fishm7.th4 * Math.PI / 180.0) - pti14 * Math.Sin(-fishm7.th4 * Math.PI / 180.0));//Calculate the coordinates of the AB axis intersection point

				if (Math.Sqrt((Math.Sqrt(pti01 * pti01 + pti02 * pti02) - fishq[1].q5) * (Math.Sqrt(pti01 * pti01 + pti02 * pti02) - fishq[1].q5) + (pti03 - fishq[1].q6) * (pti03 - fishq[1].q6)) < Math.Sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5) + fishq[2].q6 - 2)//·À³¬³Ì£¬2mm¾àÀë
				{
					if (pti01 == 0 && pti02 > 0)//Y Axis
						fishm8.th1 = 0;
					else if (pti01 > 0 && pti02 > 0)//Quadrant 1
						fishm8.th1 = Math.Atan(pti01 / pti02) * 180.0 / Math.PI;
					else if (pti01 > 0 && pti02 == 0)//X Axis
						fishm8.th1 = 90.0;
					else if (pti01 > 0 && pti02 < 0)//Quadrant 4
						fishm8.th1 = 90.0 - Math.Atan(pti02 / pti01) * 180.0 / Math.PI;
					else if (pti01 < 0 && pti02 > 0)//Quadrant 2
						fishm8.th1 = Math.Atan(pti01 / pti02) * 180.0 / Math.PI;
					else if (pti01 < 0 && pti02 == 0)//-X Axis
						fishm8.th1 = -90.0;
					else if (pti01 < 0 && pti02 < 0)//Quadrant 3
						fishm8.th1 = -90.0 - Math.Atan(pti02 / pti01) * 180.0 / Math.PI;
					else if (pti01 == 0 && pti02 < 0)//-Y Axis
						fishm8.th1 = 180.0;

					pti07 = Math.Sqrt(pti01 * pti01 + pti02 * pti02);//Y-axis coordinate after X-axis rotation (polar coordinate of end point)
					pti08 = Math.Sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5);//Right angle member length
					pti09 = 90 - Math.Asin(fishq[3].q6 / pti08) * 180.0 / Math.PI;//Angle 3
					pti10 = Math.Sqrt((pti07 - fishq[1].q5) * (pti07 - fishq[1].q5) + (pti03 - fishq[1].q6) * (pti03 - fishq[1].q6));//Length of connecting rod
					pti11 = Math.Asin((pti03 - fishq[1].q6) / pti10) * 180.0 / Math.PI;//1 angle
					pti12 = Math.Acos((fishq[2].q6 * fishq[2].q6 + pti10 * pti10 - pti08 * pti08) / (2 * fishq[2].q6 * pti10)) * 180.0 / Math.PI;//2 angle
					fishm8.th2 = 90.0 - pti11 - pti12;//y-axis angle
					fishm8.th3 = Math.Acos((fishq[2].q6 * fishq[2].q6 + pti08 * pti08 - pti10 * pti10) / (2 * fishq[2].q6 * pti08)) * 180.0 / Math.PI - 180.0 + pti09;//Z axis angle
					pti04 = (fishq[1].q5 + fishq[2].q6 * Math.Sin(fishm8.th2 * Math.PI / 180.0) + fishq[3].q6 * Math.Sin((-fishm8.th3 + fishm8.th2) * Math.PI / 180.0)) * Math.Sin(fishm8.th1 * Math.PI / 180.0);//X coordinate at right angle of A axis
					pti05 = (fishq[1].q5 + fishq[2].q6 * Math.Sin(fishm8.th2 *Math.PI / 180.0) + fishq[3].q6 * Math.Sin((-fishm8.th3 + fishm8.th2) *Math.PI / 180.0)) * Math.Cos(fishm8.th1 *Math.PI / 180.0);//The y coordinate at right angles to the A axis
					pti06 = fishq[1].q6 + fishq[2].q6 * Math.Cos(fishm8.th2 *Math.PI / 180.0) + fishq[3].q6 * Math.Cos((-fishm8.th3 + fishm8.th2) *Math.PI / 180.0);//Z coordinate at right angles to the A axis
					pti10 = fishq[6].q4 * Math.Cos(-fishm7.th6 *Math.PI / 180.0) + fishq[6].q5 * Math.Sin(-fishm7.th6 *Math.PI / 180.0);
					pti11 = fishq[6].q5 * Math.Cos(-fishm7.th6 *Math.PI / 180.0) - fishq[6].q4 * Math.Sin(-fishm7.th6 *Math.PI / 180.0);
					pti12 = 0;
					pti13 = pti10 * Math.Cos(-fishm7.th5 *Math.PI / 180.0) - pti12 * Math.Sin(-fishm7.th5 *Math.PI / 180.0);
					pti14 = pti11;
					pti15 = pti12 * Math.Cos(-fishm7.th5 *Math.PI / 180.0) + pti10 * Math.Sin(-fishm7.th5 *Math.PI / 180.0);
					pti07 = fishm7.th1 - pti13;//Calculate the position of Z0 point
					pti08 = fishm7.th2 - (pti14 * Math.Cos(-fishm7.th4 *Math.PI / 180.0) + pti15 * Math.Sin(-fishm7.th4 *Math.PI / 180.0));//Calculate the position of Z0 point
					pti09 = fishm7.th3 - (pti15 * Math.Cos(-fishm7.th4 *Math.PI / 180.0) - pti14 * Math.Sin(-fishm7.th4 *Math.PI / 180.0));//Calculate the position of Z0 point
					pti13 = Math.Sqrt((pti04 - pti07) * (pti04 - pti07) + (pti05 - pti08) * (pti05 - pti08) + (pti06 - pti09) * (pti06 - pti09));//Calculate the distance between the right angle of the A axis and the tip of the tool
					if (fishm7.th4 <= 90.0 + fishm8.th3 - fishm8.th2)//Calculate fifth axis coordinates
						fishm8.th5 = Math.Acos(((fishm7.h0 - fishq[6].q6) * (fishm7.h0 - fishq[6].q6) + fishq[3].q5 * fishq[3].q5 - pti13 * pti13) / (2.0 * fishq[3].q5 * (fishm7.h0 - fishq[6].q6))) * 180.0 /Math.PI - 90.0;
					else
						fishm8.th5 = 270.0 - Math.Acos(((fishm7.h0 - fishq[6].q6) * (fishm7.h0 - fishq[6].q6) + fishq[3].q5 * fishq[3].q5 - pti13 * pti13) / (2.0 * fishq[3].q5 * (fishm7.h0 - fishq[6].q6))) * 180.0 /Math.PI;

					pti15 = fishm8.th2 - fishm8.th3 - fishm8.th5;//Virtual axis angle 4
					pti16 = pti01 - (fishm7.h0 - fishq[6].q6) * Math.Sin(pti15 *Math.PI / 180.0) * Math.Sin(fishm8.th1 *Math.PI / 180.0);//X coordinate of virtual point
					pti17 = pti02 - (fishm7.h0 - fishq[6].q6) * Math.Sin(pti15 *Math.PI / 180.0) * Math.Cos(fishm8.th1 *Math.PI / 180.0);//Y coordinate of virtual point
					pti18 = pti03 - (fishm7.h0 - fishq[6].q6) * Math.Cos(pti15 *Math.PI / 180.0);//Z coordinate at virtual point
					pti14 = Math.Sqrt((pti16 - pti07) * (pti16 - pti07) + (pti17 - pti08) * (pti17 - pti08) + (pti18 - pti09) * (pti18 - pti09));//Distance between virtual point and Z0 point
					if (90.0 - Math.Atan(pti07 / pti08) * 180.0 /Math.PI >= 90.0 - Math.Atan(pti01 / pti02) * 180.0 /Math.PI)//Calculate the fourth axis coordinates
						fishm8.th4 = 2.0 * Math.Asin(pti14 / 2.0 / (fishm7.h0 - fishq[6].q6) / Math.Cos(fishm8.th5 *Math.PI / 180.0)) * 180.0 /Math.PI;
					else
						fishm8.th4 = -2.0 * Math.Asin(pti14 / 2.0 / (fishm7.h0 - fishq[6].q6) / Math.Cos(fishm8.th5 *Math.PI / 180.0)) * 180.0 /Math.PI;
					if (fishq[6].q4 * fishq[6].q4 + fishq[6].q5 * fishq[6].q5 > 0)//If the clamping position is offset, calculate the C axis coordinate
					{
						pti01 = fishq[6].q4;//¡Ì
						pti02 = (fishq[6].q5 * Math.Cos(-fishm8.th5 *Math.PI / 180.0) + (fishq[6].q6 - fishm7.h0) * Math.Sin(-fishm8.th5 *Math.PI / 180.0));//¡Ì
						pti03 = ((fishq[6].q6 - fishm7.h0) * Math.Cos(-fishm8.th5 *Math.PI / 180.0) - fishq[6].q5 * Math.Sin(-fishm8.th5 *Math.PI / 180.0));//¡Ì
						pti04 = pti01 * Math.Cos(-fishm8.th4 *Math.PI / 180.0) - pti03 * Math.Sin(-fishm8.th4 *Math.PI / 180.0);//¡Ì
						pti05 = pti02;//¡Ì
						pti06 = pti03 * Math.Cos(-fishm8.th4 *Math.PI / 180.0) + pti01 * Math.Sin(-fishm8.th4 *Math.PI / 180.0);//¡Ì
						pti10 = ((pti05 + fishq[3].q5) * Math.Cos(-fishm8.th3 *Math.PI / 180.0) + (pti06 + fishq[3].q6) * Math.Sin(-fishm8.th3 *Math.PI / 180.0));//¡Ì
						pti11 = ((pti06 + fishq[3].q6) * Math.Cos(-fishm8.th3 *Math.PI / 180.0) - (pti05 + fishq[3].q5) * Math.Sin(-fishm8.th3 *Math.PI / 180.0));//¡Ì
						pti12 = (pti10 * Math.Cos(fishm8.th2 *Math.PI / 180.0) + (pti11 + fishq[2].q6) * Math.Sin(fishm8.th2 *Math.PI / 180.0));//¡Ì
						pti13 = ((pti11 + fishq[2].q6) * Math.Cos(fishm8.th2 *Math.PI / 180.0) - pti10 * Math.Sin(fishm8.th2 *Math.PI / 180.0));//¡Ì
						pti14 = pti04 * Math.Cos(fishm8.th1 *Math.PI / 180.0) + (pti12 + fishq[1].q5) * Math.Sin(fishm8.th1 *Math.PI / 180.0);//¡Ì
						pti15 = (pti12 + fishq[1].q5) * Math.Cos(fishm8.th1 *Math.PI / 180.0) - pti04 * Math.Sin(fishm8.th1 *Math.PI / 180.0);//¡Ì
						pti16 = pti13 + fishq[1].q6;//¡Ì
						pti17 = Math.Sqrt((fishm7.th1 - pti14) * (fishm7.th1 - pti14) + (fishm7.th2 - pti15) * (fishm7.th2 - pti15) + (fishm7.th3 - pti16) * (fishm7.th3 - pti16));
						pti18 = Math.Sqrt(fishq[6].q4 * fishq[6].q4 + fishq[6].q5 * fishq[6].q5);
						//Need a positive and negative judgment method
						fishm8.th6 = 2.0 * Math.Asin(pti17 / 2.0 / pti18) * 180.0 /Math.PI;
					}
					else
						fishm8.th6 = fishm7.th6 - fishm8.th1;//TCPM C axis
				}
				else fish_errer = 117;
				fishm8.th7 = fishm7.th7;
				fishm8.th8 = fishm7.th8;
			}
			else
			{
				fishm8.th1 = fishm7.th1;
				fishm8.th2 = fishm7.th2;
				fishm8.th3 = fishm7.th3 + fishm7.h0;
				fishm8.th4 = fishm7.th4;
				fishm8.th5 = fishm7.th5;
				fishm8.th6 = fishm7.th6;
				fishm8.th7 = fishm7.th7;
				fishm8.th8 = fishm7.th8;
			}
			return fishm8;
		}

		public void usbcncpath()
		{
			USB4 pth0 = usbcncRTCP(fishm2);//Calculate the coordinates after RTCP

			fish_mz = 0;//Initialization pulse signal
			if (pth0.th1 - fishq[1].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[1].q3) fish_fx = fish_fx & ~fishq[1].q10;
				else fish_fx = fish_fx | fishq[1].q10;
				if (pth0.th1 - fishq[1].q50 >= fishq[1].q11)
				{
					fish_mz = fish_mz | fishq[1].q10;
					fishq[1].q50 = fishq[1].q50 + fishq[1].q11;//x-axis actual
				}
			}
			else if (pth0.th1 - fishq[1].q50 < 0)
			{
				if (fishq[1].q3) fish_fx = fish_fx | fishq[1].q10;
				else fish_fx = fish_fx & ~fishq[1].q10;
				if (pth0.th1 - fishq[1].q50 <= -fishq[1].q11)
				{
					fish_mz = fish_mz | fishq[1].q10;
					fishq[1].q50 = fishq[1].q50 - fishq[1].q11;//x-axis actual
				}
			}
			if (pth0.th2 - fishq[2].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[2].q3) fish_fx = fish_fx & ~fishq[2].q10;
				else fish_fx = fish_fx | fishq[2].q10;
				if (pth0.th2 - fishq[2].q50 >= fishq[2].q11)
				{
					fish_mz = fish_mz | fishq[2].q10;
					fishq[2].q50 = fishq[2].q50 + fishq[2].q11;//Y axis actual
				}
			}
			else if (pth0.th2 - fishq[2].q50 < 0)
			{
				if (fishq[2].q3) fish_fx = fish_fx | fishq[2].q10;
				else fish_fx = fish_fx & ~fishq[2].q10;
				if (pth0.th2 - fishq[2].q50 <= -fishq[2].q11)
				{
					fish_mz = fish_mz | fishq[2].q10;
					fishq[2].q50 = fishq[2].q50 - fishq[2].q11;
				}
			}
			if (pth0.th3 - fishq[3].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[3].q3) fish_fx = fish_fx & ~fishq[3].q10;
				else fish_fx = fish_fx | fishq[3].q10;
				if (pth0.th3 - fishq[3].q50 >= fishq[3].q11)
				{
					fish_mz = fish_mz | fishq[3].q10;
					fishq[3].q50 = fishq[3].q50 + fishq[3].q11;//Z axis actual
				}
			}
			else if (pth0.th3 - fishq[3].q50 < 0)
			{
				if (fishq[3].q3) fish_fx = fish_fx | fishq[3].q10;
				else fish_fx = fish_fx & ~fishq[3].q10;
				if (pth0.th3 - fishq[3].q50 <= -fishq[3].q11)
				{
					fish_mz = fish_mz | fishq[3].q10;
					fishq[3].q50 = fishq[3].q50 - fishq[3].q11;
				}
			}
			if (pth0.th4 - fishq[4].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[4].q3) fish_fx = fish_fx & ~fishq[4].q10;
				else fish_fx = fish_fx | fishq[4].q10;
				if (pth0.th4 - fishq[4].q50 >= fishq[4].q11)
				{
					fish_mz = fish_mz | fishq[4].q10;
					fishq[4].q50 = fishq[4].q50 + fishq[4].q11;//A-axis actual
				}
			}
			else if (pth0.th4 - fishq[4].q50 < 0)
			{
				if (fishq[4].q3) fish_fx = fish_fx | fishq[4].q10;
				else fish_fx = fish_fx & ~fishq[4].q10;
				if (pth0.th4 - fishq[4].q50 <= -fishq[4].q11)
				{
					fish_mz = fish_mz | fishq[4].q10;
					fishq[4].q50 = fishq[4].q50 - fishq[4].q11;
				}
			}
			if (pth0.th5 - fishq[5].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[5].q3) fish_fx = fish_fx & ~fishq[5].q10;
				else fish_fx = fish_fx | fishq[5].q10;
				if (pth0.th5 - fishq[5].q50 >= fishq[5].q11)
				{
					fish_mz = fish_mz | fishq[5].q10;
					fishq[5].q50 = fishq[5].q50 + fishq[5].q11;//B axis actual
				}
			}
			else if (pth0.th5 - fishq[5].q50 < 0)
			{
				if (fishq[5].q3) fish_fx = fish_fx | fishq[5].q10;
				else fish_fx = fish_fx & ~fishq[5].q10;
				if (pth0.th5 - fishq[5].q50 <= -fishq[5].q11)
				{
					fish_mz = fish_mz | fishq[5].q10;
					fishq[5].q50 = fishq[5].q50 - fishq[5].q11;
				}
			}
			if (pth0.th6 - fishq[6].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[6].q3) fish_fx = fish_fx & ~fishq[6].q10;
				else fish_fx = fish_fx | fishq[6].q10;
				if (pth0.th6 - fishq[6].q50 >= fishq[6].q11)
				{
					fish_mz = fish_mz | fishq[6].q10;
					fishq[6].q50 = fishq[6].q50 + fishq[6].q11;//C axis actual
				}
			}
			else if (pth0.th6 - fishq[6].q50 < 0)
			{
				if (fishq[6].q3) fish_fx = fish_fx | fishq[6].q10;
				else fish_fx = fish_fx & ~fishq[6].q10;
				if (pth0.th6 - fishq[6].q50 <= -fishq[6].q11)
				{
					fish_mz = fish_mz | fishq[6].q10;
					fishq[6].q50 = fishq[6].q50 - fishq[6].q11;
				}
			}
			if (pth0.th7 - fishq[7].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[7].q3) fish_fx = fish_fx & ~fishq[7].q10;
				else fish_fx = fish_fx | fishq[7].q10;
				if (pth0.th7 - fishq[7].q50 >= fishq[7].q11)
				{
					fish_mz = fish_mz | fishq[7].q10;
					fishq[7].q50 = fishq[7].q50 + fishq[7].q11;//D axis actual
				}
			}
			else if (pth0.th7 - fishq[7].q50 < 0)
			{
				if (fishq[7].q3) fish_fx = fish_fx | fishq[7].q10;
				else fish_fx = fish_fx & ~fishq[7].q10;
				if (pth0.th7 - fishq[7].q50 <= -fishq[7].q11)
				{
					fish_mz = fish_mz | fishq[7].q10;
					fishq[7].q50 = fishq[7].q50 - fishq[7].q11;
				}
			}
			if (pth0.th8 - fishq[8].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[8].q3) fish_fx = fish_fx & ~fishq[8].q10;
				else fish_fx = fish_fx | fishq[8].q10;
				if (pth0.th8 - fishq[8].q50 >= fishq[8].q11)
				{
					fish_mz = fish_mz | fishq[8].q10;
					fishq[8].q50 = fishq[8].q50 + fishq[8].q11;//E axis actual
				}
			}
			else if (pth0.th8 - fishq[8].q50 < 0)
			{
				if (fishq[8].q3) fish_fx = fish_fx | fishq[8].q10;
				else fish_fx = fish_fx & ~fishq[8].q10;
				if (pth0.th8 - fishq[8].q50 <= -fishq[8].q11)
				{
					fish_mz = fish_mz | fishq[8].q10;
					fishq[8].q50 = fishq[8].q50 - fishq[8].q11;
				}
			}
			if (fishq[4].q2)
			{
				if (fishq[4].q50 >= 360.0)
				{
					fishm1.th4 = fishm1.th4 - 360.0;
					fishm2.th4 = fishm2.th4 - 360.0;
					fishq[4].q50 = fishq[4].q50 - 360.0;
				}
				else if (fishq[4].q50 < 0.0)
				{
					fishm1.th4 = fishm1.th4 + 360.0;
					fishm2.th4 = fishm2.th4 + 360.0;
					fishq[4].q50 = fishq[4].q50 + 360.0;
				}
			}
			if (fishq[5].q2)
			{
				if (fishq[5].q50 >= 360.0)
				{
					fishm1.th5 = fishm1.th5 - 360.0;
					fishm2.th5 = fishm2.th5 - 360.0;
					fishq[5].q50 = fishq[5].q50 - 360.0;
				}
				else if (fishq[5].q50 < 0.0)
				{
					fishm1.th5 = fishm1.th5 + 360.0;
					fishm2.th5 = fishm2.th5 + 360.0;
					fishq[5].q50 = fishq[5].q50 + 360.0;
				}
			}
			if (fishq[6].q2)
			{
				if (fishq[6].q50 >= 360.0)
				{
					fishm1.th6 = fishm1.th6 - 360.0;
					fishm2.th6 = fishm2.th6 - 360.0;
					fishq[6].q50 = fishq[6].q50 - 360.0;
				}
				else if (fishq[6].q50 < 0.0)
				{
					fishm1.th6 = fishm1.th6 + 360.0;
					fishm2.th6 = fishm2.th6 + 360.0;
					fishq[6].q50 = fishq[6].q50 + 360.0;
				}
			}
			if (fishq[7].q2)
			{
				if (fishq[7].q50 >= 360.0)
				{
					fishm1.th7 = fishm1.th7 - 360.0;
					fishm2.th7 = fishm2.th7 - 360.0;
					fishq[7].q50 = fishq[7].q50 - 360.0;
				}
				else if (fishq[7].q50 < 0.0)
				{
					fishm1.th7 = fishm1.th7 + 360.0;
					fishm2.th7 = fishm2.th7 + 360.0;
					fishq[7].q50 = fishq[7].q50 + 360.0;
				}
			}
			if (fishq[8].q2)
			{
				if (fishq[8].q50 >= 360.0)
				{
					fishm1.th8 = fishm1.th8 - 360.0;
					fishm2.th8 = fishm2.th8 - 360.0;
					fishq[8].q50 = fishq[8].q50 - 360.0;
				}
				else if (fishq[8].q50 < 0.0)
				{
					fishm1.th8 = fishm1.th8 + 360.0;
					fishm2.th8 = fishm2.th8 + 360.0;
					fishq[8].q50 = fishq[8].q50 + 360.0;
				}
			}

			if (fish1050 != 8)
			{
				if (pth0.th1 < fishq[1].q15) fish_errer = 100;
				else if (pth0.th1 > fishq[1].q16) fish_errer = 101;
				if (pth0.th2 < fishq[2].q15) fish_errer = 102;
				else if (pth0.th2 > fishq[2].q16) fish_errer = 103;
				if (pth0.th3 < fishq[3].q15) fish_errer = 104;
				else if (pth0.th3 > fishq[3].q16) fish_errer = 105;
				if (pth0.th4 < fishq[4].q15) fish_errer = 106;
				else if (pth0.th4 > fishq[4].q16) fish_errer = 107;
				if (pth0.th5 < fishq[5].q15) fish_errer = 108;
				else if (pth0.th5 > fishq[5].q16) fish_errer = 109;
				if (pth0.th6 < fishq[6].q15) fish_errer = 110;
				else if (pth0.th6 > fishq[6].q16) fish_errer = 111;
				if (pth0.th7 < fishq[7].q15) fish_errer = 112;
				else if (pth0.th7 > fishq[7].q16) fish_errer = 113;
				if (pth0.th8 < fishq[8].q15) fish_errer = 114;
				else if (pth0.th8 > fishq[8].q16) fish_errer = 115;
			}

			if (fish_da >= DataL - 6 || sendbuf[0] != fish_fx)
			{
				sendbuf[DataL - 6] = char(fish_da >> 8);
				sendbuf[DataL - 5] = char(fish_da);
				while (fish_da < DataL - 6)//Commutation complement 0 pulse
					sendbuf[fish_da++] = 0;
				if (fishm2.ss / 12000 * fish_zzbl * 127.5 > 255)
					sendbuf[DataL - 4] = 0;//"0"Is the maximum speed
				else
					sendbuf[DataL - 4] = 255 - fishm2.ss / 12000 * fish_zzbl * 127.5;
				sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
				sendbuf[DataL - 2] = char(fishq[0].q19 / 10000);
				sendbuf[DataL - 1] = fishq[0].q1;
				while (DataL != zyUSB_WriteData(3, sendbuf, DataL, 500))//If the sending fails, please resend the signal again
				{
					fish_errer = 1001;
					Sleep(20);
				}
				zyUSB_ReadData(2, recbuf, sizeof(recbuf), 300);
				if (fish_errer == 1001) fish_errer = 0;
				if (fish1050 == 2)
				{
					fish_wparam2 = recbuf[20];
					if (recbuf[21] == 2 && fish_jg20 != 2)
					{
						fish_jgbl = 0.02;
						fish_jg20 = 2;
					}
					else if (recbuf[21] == 10 && fish_jg20 != 10)
					{
						fish_jgbl = 0.1;
						fish_jg20 = 10;
					}
					else if (recbuf[21] == 100 && fish_jg20 != 100)
					{
						fish_jgbl = 1.0;
						fish_jg20 = 100;
					}
					if (recbuf[20] != 0 && recbuf[19] != 0)
					{
						if (recbuf[19] < 128 && fish_sl >= 0)
							fish_sl = fish_sl + 0.1 * fish_jgbl * recbuf[19];
						else if (recbuf[19] > 128 && fish_sl <= 0)
							fish_sl = fish_sl + 0.1 * fish_jgbl * (recbuf[19] - 256);
					}
				}
				if (recbuf[18] == 1) fish_errer = 1006;
				else if (recbuf[15] == 1) fish_errer = 1005;
				fish_da = 1;
				sendbuf[0] = fish_fx;
				if (fishm2.g01 == 0) fishj[fish_jj].g = 0;
				else fishj[fish_jj].g = 1;
				fishj[fish_jj].x = fishq[1].q50;
				fishj[fish_jj].y = fishq[2].q50;
				fishj[fish_jj].z = fishq[3].q50;
				fish_jj++;
				if (fish_jj >= 10000) fish_jj = 0;
			}
			sendbuf[fish_da++] = fish_mz;
		}

		void usbcnc_G04(int fish_G403)//G04
		{
			sendbuf[DataL - 6] = char(fish_da >> 8);
			sendbuf[DataL - 5] = char(fish_da);
			while (fish_da < DataL - 6)//Reissue the pulse before G04
				sendbuf[fish_da++] = 0;
			if (fishm2.ss / 12000 * fish_zzbl * 127.5 >= 255)
				sendbuf[DataL - 4] = 0;//"0"Is the maximum speed
			else
				sendbuf[DataL - 4] = 255 - fishm2.ss / 12000 * fish_zzbl * 127.5;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
			sendbuf[DataL - 2] = char(fishq[0].q19 / 10000);
			sendbuf[DataL - 1] = fishq[0].q1;
			while (DataL != zyUSB_WriteData(3, sendbuf, DataL, 500))//If the sending fails, please resend the signal again
			{
				fish_errer = 1001;
				Sleep(20);
			}
			zyUSB_ReadData(2, recbuf, sizeof(recbuf), 300);
			if (fish_errer == 1001) fish_errer = 0;
			if (fish1050 == 2)
			{
				fish_wparam2 = recbuf[20];
				if (recbuf[21] == 2 && fish_jg20 != 2)
				{
					fish_jgbl = 0.02;
					fish_jg20 = 2;
				}
				else if (recbuf[21] == 10 && fish_jg20 != 10)
				{
					fish_jgbl = 0.1;
					fish_jg20 = 10;
				}
				else if (recbuf[21] == 100 && fish_jg20 != 100)
				{
					fish_jgbl = 1.0;
					fish_jg20 = 100;
				}
				if (recbuf[20] != 0 && recbuf[19] != 0)
				{
					if (recbuf[19] < 128 && fish_sl >= 0)
						fish_sl = fish_sl + 0.1 * fish_jgbl * recbuf[19];
					else if (recbuf[19] > 128 && fish_sl <= 0)
						fish_sl = fish_sl + 0.1 * fish_jgbl * (recbuf[19] - 256);
				}
			}
			if (recbuf[18] == 1) fish_errer = 1006;
			else if (recbuf[15] == 1) fish_errer = 1005;
			fish_da = 1;
			sendbuf[0] = fish_fx;
			Sleep(fish_G403);
		}
		void usbcnc_M00()
		{
			if (fish_o1 > 0) fish_o1--;
			fish1052 = FALSE;//Allow selection of program segments
			fish1053 = FALSE;//Program pause
			while (!fish1053 && fish1050 == 0 && !fish1054)
				usbcnc_G04(100);
		}
		void usbcnc_M01(bool fish_m01)
		{
			if (fish_m01)
			{
				fish1052 = FALSE;//Allow selection of program segments
				fish1053 = FALSE;//Program pause
				while (!fish1053 && fish1050 == 0 && !fish1054)
					usbcnc_G04(100);
			}
		}
		void usbcnc_M03(int fish_m03)
		{
			fish1061 = 1;
			fish1062 = 0;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
			if (fish_m03 / 12000 * fish_zzbl * 127.5 > 255)
				sendbuf[DataL - 4] = 0;//"0"Is the maximum speed
			else
				sendbuf[DataL - 4] = 255 - fish_m03 / 12000 * fish_zzbl * 127.5;
		}
		void usbcnc_M04(int fish_m04)
		{
			fish1061 = 0;
			fish1062 = 2;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
			if (fish_m04 / 12000 * fish_zzbl * 127.5 > 255)
				sendbuf[DataL - 4] = 0;//"0"Is the maximum speed
			else
				sendbuf[DataL - 4] = 255 - fish_m04 / 12000 * fish_zzbl * 127.5;
		}
		void usbcnc_M05()
		{
			fish1061 = 0;
			fish1062 = 0;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
			sendbuf[DataL - 4] = 255;
		}

		void usbcnc_M07()
		{
			fish1063 = 4;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M08()
		{
			fish1064 = 8;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M09()
		{
			fish1063 = 0;
			fish1064 = 0;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M61()
		{
			fishq[0].q1 = fishq[0].q1 & 31 | 128;
			fish_feed = 0;
			fishm1 = fishm2;
			fishm2.ti3 = 0;
			while (recbuf[17] == 0 && fish_errer == 0 && fishm2.ti3 < fishq[0].q20)//Key not released
			{
				if (fish1054 && fish_feed > fishq[3].q13)
					fish_feed = fish_feed - fishq[3].q13;
				else if (fish1054 && fish_feed < fishq[3].q13)
					fish_feed = 0.0;
				else if (fish_feed < fishq[3].q18)
					fish_feed = fish_feed + fishq[3].q13;
				fishm2.th3 = fishm2.th3 - fishq[0].q11 * fish_feed / fishq[0].q14;
				fishm2.ti3 = fishm2.ti3 + fishq[0].q11 * fish_feed / fishq[0].q14;
				usbcncpath();
				if (fish1054 && fish_feed == 0)//Program reset
					fish_errer = 9999;
			}
			usbcnc_G04(1);//Pause for 1 second
			usbcnc_G04(1000);//Pause for 1 second
			fish_feed = 0;
			fishq[0].q1 = fishq[0].q1 & 31;
			if (fishm2.ti3 < fishq[0].q20 && fish_errer == 0)
			{
				tool_l[fishm2.tt] = fishq[3].q50 - fishq[0].q22 + recbuf[22] * fishq[3].q11;
				tool_b[fishm2.tt] = 0.0;
			}
			while (fishm2.ti3 > 0 && fish_errer == 0)
			{
				if (fish1054 && fish_feed > fishq[3].q13)
					fish_feed = fish_feed - fishq[3].q13;
				else if (fish1054 && fish_feed < fishq[3].q13)
					fish_feed = 0.0;
				else if (fish_feed < fishq[3].q18)
					fish_feed = fish_feed + fishq[3].q13;
				fishm2.ti3 = fishm2.ti3 - fishq[0].q11 * fish_feed / fishq[0].q14;
				fishm2.th3 = fishm2.th3 + fishq[0].q11 * fish_feed / fishq[0].q14;
				usbcncpath();
				if (fish1054 && fish_feed == 0)//Program reset
					fish_errer = 9999;
			}
		}

		void usbcnc_M75()
		{
			fish1065 = 16;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M76()
		{
			fish1066 = 32;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M77()
		{
			fish1067 = 64;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M78()
		{
			fish1068 = 128;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M85()
		{
			fish1065 = 0;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M86()
		{
			fish1066 = 0;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M87()
		{
			fish1067 = 0;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}
		void usbcnc_M88()
		{
			fish1068 = 0;
			sendbuf[DataL - 3] = fish1061 + fish1062 + fish1063 + fish1064 + fish1065 + fish1066 + fish1067 + fish1068;
		}

		void usbcnc_M128()
		{
			if (fishq[0].q10 == 7546 || fishq[0].q10 == 7556 || fishq[0].q10 == 7545 || fishq[0].q10 == 7554)//Double pendulum
			{
				fish_x05 = (fishq[4].q4 + fishq[1].q50) * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q9 * (fishq[4].q5 + fishq[2].q50) - fishq[4].q8 * (fishq[4].q6 + fishq[3].q50 - fishm2.h0)) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q7 * (fishq[4].q7 * (fishq[4].q4 + fishq[1].q50) + fishq[4].q8 * (fishq[4].q5 + fishq[2].q50) + fishq[4].q9 * (fishq[4].q6 + fishq[3].q50 - fishm2.h0)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0)) - fishq[4].q4;
				fish_y05 = (fishq[4].q5 + fishq[2].q50) * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q7 * (fishq[4].q6 + fishq[3].q50 - fishm2.h0) - fishq[4].q9 * (fishq[4].q4 + fishq[1].q50)) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q8 * (fishq[4].q7 * (fishq[4].q4 + fishq[1].q50) + fishq[4].q8 * (fishq[4].q5 + fishq[2].q50) + fishq[4].q9 * (fishq[4].q6 + fishq[3].q50 - fishm2.h0)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0)) - fishq[4].q5;
				fish_z05 = (fishq[4].q6 + fishq[3].q50 - fishm2.h0) * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q8 * (fishq[4].q4 + fishq[1].q50) - fishq[4].q7 * (fishq[4].q5 + fishq[2].q50)) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q9 * (fishq[4].q7 * (fishq[4].q4 + fishq[1].q50) + fishq[4].q8 * (fishq[4].q5 + fishq[2].q50) + fishq[4].q9 * (fishq[4].q6 + fishq[3].q50 - fishm2.h0)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0)) - fishq[4].q6;
				fishm2.th1 = fish_x05 * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q9 * fish_y05 - fishq[5].q8 * fish_z05) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q7 * (fishq[5].q7 * fish_x05 + fishq[5].q8 * fish_y05 + fishq[5].q9 * fish_z05) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fishm2.th2 = fish_y05 * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q7 * fish_z05 - fishq[5].q9 * fish_x05) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q8 * (fishq[5].q7 * fish_x05 + fishq[5].q8 * fish_y05 + fishq[5].q9 * fish_z05) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fishm2.th3 = fish_z05 * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q8 * fish_x05 - fishq[5].q7 * fish_y05) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q9 * (fishq[5].q7 * fish_x05 + fishq[5].q8 * fish_y05 + fishq[5].q9 * fish_z05) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fishm2.TCPM = TRUE;
			}
			else if (fishq[0].q10 == 7521 || fishq[0].q10 == 7512 || fishq[0].q10 == 7532 || fishq[0].q10 == 7531)//Double swing head
			{
				fish_x05 = fishq[5].q4 * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q9 * fishq[5].q5 - fishq[5].q8 * (fishq[5].q6 - fishm2.h0)) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q7 * (fishq[5].q7 * fishq[5].q4 + fishq[5].q8 * fishq[5].q5 + fishq[5].q9 * (fishq[5].q6 - fishm2.h0)) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fish_y05 = fishq[5].q5 * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q7 * (fishq[5].q6 - fishm2.h0) - fishq[5].q9 * fishq[5].q4) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q8 * (fishq[5].q7 * fishq[5].q4 + fishq[5].q8 * fishq[5].q5 + fishq[5].q9 * (fishq[5].q6 - fishm2.h0)) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fish_z05 = (fishq[5].q6 - fishm2.h0) * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q8 * fishq[5].q4 - fishq[5].q7 * fishq[5].q5) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q9 * (fishq[5].q7 * fishq[5].q4 + fishq[5].q8 * fishq[5].q5 + fishq[5].q9 * (fishq[5].q6 - fishm2.h0)) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fishm2.th1 = fishq[1].q50 - ((fishq[4].q4 + fish_x05) * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q9 * (fishq[4].q5 + fish_y05) - fishq[4].q8 * (fishq[4].q6 + fish_z05)) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q7 * (fishq[4].q7 * (fishq[4].q4 + fish_x05) + fishq[4].q8 * (fishq[4].q5 + fish_y05) + fishq[4].q9 * (fishq[4].q6 + fish_z05)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0)));
				fishm2.th2 = fishq[2].q50 - ((fishq[4].q5 + fish_y05) * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q7 * (fishq[4].q6 + fish_z05) - fishq[4].q9 * (fishq[4].q4 + fish_x05)) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q8 * (fishq[4].q7 * (fishq[4].q4 + fish_x05) + fishq[4].q8 * (fishq[4].q5 + fish_y05) + fishq[4].q9 * (fishq[4].q6 + fish_z05)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0)));
				fishm2.th3 = fishq[3].q50 - ((fishq[4].q6 + fish_z05) * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q8 * (fishq[4].q4 + fish_x05) - fishq[4].q7 * (fishq[4].q5 + fish_y05)) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q9 * (fishq[4].q7 * (fishq[4].q4 + fish_x05) + fishq[4].q8 * (fishq[4].q5 + fish_y05) + fishq[4].q9 * (fishq[4].q6 + fish_z05)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0)));
				fishm2.TCPM = TRUE;
			}
			else if (fishq[0].q10 == 7515 || fishq[0].q10 == 7524 || fishq[0].q10 == 7526 || fishq[0].q10 == 7516)//Sway
			{
				fish_x05 = fishq[4].q4 * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q9 * fishq[4].q5 - fishq[4].q8 * (fishq[4].q6 - fishm2.h0)) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q7 * (fishq[4].q7 * fishq[4].q4 + fishq[4].q8 * fishq[4].q5 + fishq[4].q9 * (fishq[4].q6 - fishm2.h0)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0));
				fish_y05 = fishq[4].q5 * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q7 * (fishq[4].q6 - fishm2.h0) - fishq[4].q9 * fishq[4].q4) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q8 * (fishq[4].q7 * fishq[4].q4 + fishq[4].q8 * fishq[4].q5 + fishq[4].q9 * (fishq[4].q6 - fishm2.h0)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0));
				fish_z05 = (fishq[4].q6 - fishm2.h0) * cos(-fishq[4].q50 * PI / 180.0) + (fishq[4].q8 * fishq[4].q4 - fishq[4].q7 * fishq[4].q5) * sin(-fishq[4].q50 * PI / 180.0) + fishq[4].q9 * (fishq[4].q7 * fishq[4].q4 + fishq[4].q8 * fishq[4].q5 + fishq[4].q9 * (fishq[4].q6 - fishm2.h0)) * (1.0 - cos(-fishq[4].q50 * PI / 180.0));
				fishm2.th1 = (fishq[1].q50 + fish_x05) * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q9 * (fishq[2].q50 + fish_y05) - fishq[5].q8 * (fishq[3].q50 + fish_z05)) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q7 * (fishq[5].q7 * (fishq[1].q50 + fish_x05) + fishq[5].q8 * (fishq[2].q50 + fish_y05) + fishq[5].q9 * (fishq[3].q50 + fish_z05)) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fishm2.th2 = (fishq[2].q50 + fish_y05) * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q7 * (fishq[3].q50 + fish_z05) - fishq[5].q9 * (fishq[1].q50 + fish_x05)) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q8 * (fishq[5].q7 * (fishq[1].q50 + fish_x05) + fishq[5].q8 * (fishq[2].q50 + fish_y05) + fishq[5].q9 * (fishq[3].q50 + fish_z05)) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fishm2.th3 = (fishq[3].q50 + fish_z05) * cos(-fishq[5].q50 * PI / 180.0) + (fishq[5].q8 * (fishq[1].q50 + fish_x05) - fishq[5].q7 * (fishq[2].q50 + fish_y05)) * sin(-fishq[5].q50 * PI / 180.0) + fishq[5].q9 * (fishq[5].q7 * (fishq[1].q50 + fish_x05) + fishq[5].q8 * (fishq[2].q50 + fish_y05) + fishq[5].q9 * (fishq[3].q50 + fish_z05)) * (1.0 - cos(-fishq[5].q50 * PI / 180.0));
				fishm2.TCPM = TRUE;
			}
			else if (fishq[0].q10 == 7403)
			{
				fish_x05 = fishq[2].q5 * sin(fishq[2].q50 * PI / 180.0);
				fish_y05 = -fishq[2].q5 * cos(fishq[2].q50 * PI / 180.0);
				fishm2.th1 = (fish_y05 - fishq[1].q5) * sin(fishq[2].q50 * PI / 180.0) + fish_x05 * cos(fishq[2].q50 * PI / 180.0);
				fishm2.th2 = (fish_y05 - fishq[1].q5) * cos(fishq[2].q50 * PI / 180.0) + fish_x05 * sin(fishq[2].q50 * PI / 180.0);
				fishm2.th3 = fishq[3].q50;
				fishm2.TCPM = TRUE;
			}
			else if (fishq[0].q10 == 7776)
			{

				fish_y08 = fishq[2].q6 * sin(fishq[2].q50 * PI / 180.0) + fishq[1].q5;//Y coordinate at Z axis (polar coordinate)
				fish_z08 = fishq[2].q6 * cos(fishq[2].q50 * PI / 180.0) + fishq[1].q6;//Z coordinate at Z axis
				fish_y06 = sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5);//Right angle member length
				fish_z06 = 90 - asin(fishq[3].q6 / fish_y06) * 180.0 / PI;//Angle 3//fish_z06=90-asin(fishq[3].q6/fish_y06)*180.0/PI;¡Ì
				fish_x06 = fish_y06 * cos((90 - (fish_z06 - fishq[3].q50) - fishq[2].q50) * PI / 180.0) + fish_y08;//Y coordinate on B axis
				fish_x08 = fish_y06 * sin((90 - (fish_z06 - fishq[3].q50) - fishq[2].q50) * PI / 180.0) + fish_z08;//Z coordinate at B axis
				fish_b08 = fishq[5].q6 * cos(fishq[5].q50 * PI / 180.0) * cos(fishq[4].q50 * PI / 180.0) * sin((-fishq[3].q50 + fishq[2].q50) * PI / 180.0);//C axis projection relative to K point Y length
				fish_c08 = fishq[5].q6 * cos(fishq[5].q50 * PI / 180.0) * cos(fishq[4].q50 * PI / 180.0) * cos((-fishq[3].q50 + fishq[2].q50) * PI / 180.0);//C axis projection relative to K point Z length
				fish_a06 = fishq[5].q6 * cos(fishq[5].q50 * PI / 180.0) * sin(fishq[4].q50 * PI / 180.0);//C axis relative X length
				fish_b06 = fish_b08 - fishq[5].q6 * sin(fishq[5].q50 * PI / 180.0) * cos((-fishq[3].q50 + fishq[2].q50) * PI / 180.0);//C axis relative to Y length
				fish_c06 = fish_c08 + fishq[5].q6 * sin(fishq[5].q50 * PI / 180.0) * sin((-fishq[3].q50 + fishq[2].q50) * PI / 180.0);//C axis relative to Z length
				fish_x05 = -fish_a06 * cos(fishq[1].q50 * PI / 180.0) + (fish_x06 - fish_b06) * sin(fishq[1].q50 * PI / 180.0);//Coordinates after rotating the X axis
				fish_y05 = fish_a06 * sin(fishq[1].q50 * PI / 180.0) + (fish_x06 - fish_b06) * cos(fishq[1].q50 * PI / 180.0);//Coordinates after rotating the Y axis
				fish_z05 = fish_x08 - fish_c06;//Coordinates after rotating the Z axis
				fishm2.th1 = fish_x05;
				fishm2.th2 = fish_y05;
				fishm2.th3 = fish_z05;

				fish_a05 = fish_a06 * cos(fishq[1].q50 * PI / 180.0) + fish_b06 * sin(fishq[1].q50 * PI / 180.0);//The vector after the length of the C axis is rotated;
				fish_b05 = -fish_a06 * sin(fishq[1].q50 * PI / 180.0) + fish_b06 * cos(fishq[1].q50 * PI / 180.0);
				fish_c05 = fish_c06;
				fishm2.th4 = -asin(fish_b05 / sqrt(fish_b05 * fish_b05 + fish_c05 * fish_c05)) * 180.0 / PI;
				fishm2.th5 = asin(fish_a05 / sqrt(fish_a05 * fish_a05 + fish_c05 * fish_c05)) * 180.0 / PI;
				fishm2.th6 = fishq[6].q50 + fishq[1].q50;
				fishm2.th7 = fishq[7].q50;
				fishm2.TCPM = TRUE;
			}
			else if (fishq[0].q10 == 7778)
			{
				if (fishq[1].q50 <= 0.01 && fishq[2].q50 <= 0.01 && fishq[3].q50 <= 0.01 && fishq[4].q50 <= 0.01 && fishq[5].q50 <= 0.01 && fishq[6].q50 <= 0.01)
				{
					fishm2.th1 = fishq[6].q4;
					fishm2.th2 = fishq[1].q5 + fishq[3].q5 + fishq[6].q5;
					fishm2.th3 = fishq[1].q6 + fishq[2].q6 + fishq[3].q6 + fishq[6].q6;
					fishm2.TCPM = TRUE;
				}
				else
					fish_errer = 1011;
			}
		}
		void usbcnc_M129()
		{
			fishm2.TCPM = FALSE;
			fishm2.th1 = fishq[1].q50;
			fishm2.th2 = fishq[2].q50;
			fishm2.th3 = fishq[3].q50 - fishm2.h0;
			fishm2.th4 = fishq[4].q50;
			fishm2.th5 = fishq[5].q50;
			fishm2.th6 = fishq[6].q50;
			fishm2.th7 = fishq[7].q50;
		}


		USB3 usbcncLA(USB3 fish_m, USB2 fish_g)//Calculate length and vector
		{
			if (fish_g.g00 == 0 || !fish1059)//'/'Jump priority is highest
			{
				double fm_vx = fish_m.u1, fm_vy = fish_m.v1, fm_vz = fish_m.w1, fm_va = fish_m.va;//Record the previous vector
				double fm_vb = fish_m.vb, fm_vc = fish_m.vc, fm_vd = fish_m.vd, fm_ve = fish_m.ve;//Record the previous vector
				fish_m.g00 = fish_g.g00,fish_m.g04 = fish_g.g04,fish_m.g28 = fish_g.g28,fish_m.mm = fish_g.mm;//Non-modal
				if (fish_g.g01 != 255) fish_m.g01 = fish_g.g01;
				//		if(fish_g.g16!=0)				fish_m.g16=fish_g.g16;
				if (fish_g.g17 != 0) fish_m.g17 = fish_g.g17;
				if (fish_g.g41 != 0) fish_m.g41 = fish_g.g41;
				if (fish_g.g43 != 0) fish_m.g43 = fish_g.g43;
				//		if(fish_g.g64!=0)				fish_m.g64=fish_g.g64;
				if (fish_g.g81 != 0) fish_m.g81 = fish_g.g81;
				if (fish_g.g90 != 0) fish_m.g90 = fish_g.g90;
				if (fish_g.g98 != 0) fish_m.g98 = fish_g.g98;
				if (fish_g.ii != 0.00000012) fish_m.ii = fish_g.ii;
				else fish_m.ii = 0;
				if (fish_g.jj != 0.00000012) fish_m.jj = fish_g.jj;
				else fish_m.jj = 0;
				if (fish_g.kk != 0.00000012) fish_m.kk = fish_g.kk;
				else fish_m.kk = 0;
				if (fish_g.rr != 0.00000012) fish_m.rr = fish_g.rr;
				else fish_m.rr = 0;
				if (fish_g.pp != 0.00000012) fish_m.pp = fish_g.pp;
				else fish_m.pp = 0;
				if (fish_g.qq != 0.00000012) fish_m.qq = fish_g.qq;
				else fish_m.qq = 0;
				if (fish_g.ll != 0.00000012) fish_m.ll = fish_g.ll;
				else fish_m.ll = 0;
				if (fish_g.ff != 0.00000012) fish_m.ff = fish_g.ff;
				if (fish_g.tt != 255) fish_m.tt = fish_g.tt;
				if (fish_g.hh != 255) fish_m.hh = fish_g.hh;
				if (fish_g.dd != 255) fish_m.dd = fish_g.dd;
				if (fish_g.ss != 0.00000012) fish_m.ss = fish_g.ss;

				if (fish_m.g43 == 43) fish_m.h1 = tool_l[fish_m.hh] + tool_b[fish_m.hh] - fish_m.h0;
				else if (fish_m.g43 == 44) fish_m.h1 = -tool_l[fish_m.hh] - tool_b[fish_m.hh] - fish_m.h0;
				else if (fish_m.g43 == 49) fish_m.h1 = 0.0 - fish_m.h0;
				else fish_m.h1 = 0.0;
				if (fish_m.g41 == 41) fish_m.d1 = tool_d[fish_m.dd] - fish_m.d0;
				else if (fish_m.g41 == 42) fish_m.d1 = -tool_d[fish_m.dd] - fish_m.d0;
				else if (fish_m.g41 == 40) fish_m.d1 = 0.0 - fish_m.d0;
				else fish_m.d1 = 0.0;

				if (fish_g.mm == 128) fish_m.TCPM = TRUE;
				else if (fish_g.mm == 129) fish_m.TCPM = FALSE;

				if (fish_g.g54 != 0 || fish_g.g68 != 0)
				{
					if (fish_g.g54 == 53) fish_m.g54 = 7;
					else if (fish_g.g54 == 54) fish_m.g54 = 1;
					else if (fish_g.g54 == 55) fish_m.g54 = 2;
					else if (fish_g.g54 == 56) fish_m.g54 = 3;
					else if (fish_g.g54 == 57) fish_m.g54 = 4;
					else if (fish_g.g54 == 58) fish_m.g54 = 5;
					else if (fish_g.g54 == 59) fish_m.g54 = 6;
					if (fish_g.g68 != 0) fish_m.g68 = fish_g.g68;

					if (fish_m.g68 == 68)
					{
						if (fishq[0].q10 == 7546 || fishq[0].q10 == 7556 || fishq[0].q10 == 7545 || fishq[0].q10 == 7554)
						{
							fish_a05 = (work_x[fish_m.g54] + work_x[0]) * cos(fish_m.th5 * PI / 180.0) + (fishq[5].q9 * (work_y[fish_m.g54] + work_y[0]) - fishq[5].q8 * (work_z[fish_m.g54] + work_z[0])) * sin(fish_m.th5 * PI / 180.0) + fishq[5].q7 * (fishq[5].q7 * (work_x[fish_m.g54] + work_x[0]) + fishq[5].q8 * (work_y[fish_m.g54] + work_y[0]) + fishq[5].q9 * (work_z[fish_m.g54] + work_z[0])) * (1 - cos(fish_m.th5 * PI / 180.0));
							fish_b05 = (work_y[fish_m.g54] + work_y[0]) * cos(fish_m.th5 * PI / 180.0) + (fishq[5].q7 * (work_z[fish_m.g54] + work_z[0]) - fishq[5].q9 * (work_x[fish_m.g54] + work_x[0])) * sin(fish_m.th5 * PI / 180.0) + fishq[5].q8 * (fishq[5].q7 * (work_x[fish_m.g54] + work_x[0]) + fishq[5].q8 * (work_y[fish_m.g54] + work_y[0]) + fishq[5].q9 * (work_z[fish_m.g54] + work_z[0])) * (1 - cos(fish_m.th5 * PI / 180.0));
							fish_c05 = (work_z[fish_m.g54] + work_z[0]) * cos(fish_m.th5 * PI / 180.0) + (fishq[5].q8 * (work_x[fish_m.g54] + work_x[0]) - fishq[5].q7 * (work_y[fish_m.g54] + work_y[0])) * sin(fish_m.th5 * PI / 180.0) + fishq[5].q9 * (fishq[5].q7 * (work_x[fish_m.g54] + work_x[0]) + fishq[5].q8 * (work_y[fish_m.g54] + work_y[0]) + fishq[5].q9 * (work_z[fish_m.g54] + work_z[0])) * (1 - cos(fish_m.th5 * PI / 180.0));
							fish_m.cy01 = (fish_a05 + fishq[4].q4) * cos(fish_m.th4 * PI / 180.0) + (fishq[4].q9 * (fish_b05 + fishq[4].q5) - fishq[4].q8 * (fish_c05 + fishq[4].q6)) * sin(fish_m.th4 * PI / 180.0) + fishq[4].q7 * (fishq[4].q7 * (fish_a05 + fishq[4].q4) + fishq[4].q8 * (fish_b05 + fishq[4].q5) + fishq[4].q9 * (fish_c05 + fishq[4].q6)) * (1 - cos(fish_m.th4 * PI / 180.0)) - fishq[4].q4;
							fish_m.cy02 = (fish_b05 + fishq[4].q5) * cos(fish_m.th4 * PI / 180.0) + (fishq[4].q7 * (fish_c05 + fishq[4].q6) - fishq[4].q9 * (fish_a05 + fishq[4].q4)) * sin(fish_m.th4 * PI / 180.0) + fishq[4].q8 * (fishq[4].q7 * (fish_a05 + fishq[4].q4) + fishq[4].q8 * (fish_b05 + fishq[4].q5) + fishq[4].q9 * (fish_c05 + fishq[4].q6)) * (1 - cos(fish_m.th4 * PI / 180.0)) - fishq[4].q5;
							fish_m.cy03 = (fish_c05 + fishq[4].q6) * cos(fish_m.th4 * PI / 180.0) + (fishq[4].q8 * (fish_a05 + fishq[4].q4) - fishq[4].q7 * (fish_b05 + fishq[4].q5)) * sin(fish_m.th4 * PI / 180.0) + fishq[4].q9 * (fishq[4].q7 * (fish_a05 + fishq[4].q4) + fishq[4].q8 * (fish_b05 + fishq[4].q5) + fishq[4].q9 * (fish_c05 + fishq[4].q6)) * (1 - cos(fish_m.th4 * PI / 180.0)) - fishq[4].q6;
						}
						else if (fishq[0].q10 == 7521 || fishq[0].q10 == 7512 || fishq[0].q10 == 7532 || fishq[0].q10 == 7531)//Double swing head
						{
							fish_x05 = fishq[5].q4 * cos(-fish_m.th5 * PI / 180.0) + (fishq[5].q9 * fishq[5].q5 - fishq[5].q8 * (fishq[5].q6 - fishm2.h1)) * sin(-fish_m.th5 * PI / 180.0) + fishq[5].q7 * (fishq[5].q7 * fishq[5].q4 + fishq[5].q8 * fishq[5].q5 + fishq[5].q9 * (fishq[5].q6 - fishm2.h1)) * (1 - cos(-fish_m.th5 * PI / 180.0));
							fish_y05 = fishq[5].q5 * cos(-fish_m.th5 * PI / 180.0) + (fishq[5].q7 * (fishq[5].q6 - fishm2.h1) - fishq[5].q9 * fishq[5].q4) * sin(-fish_m.th5 * PI / 180.0) + fishq[5].q8 * (fishq[5].q7 * fishq[5].q4 + fishq[5].q8 * fishq[5].q5 + fishq[5].q9 * (fishq[5].q6 - fishm2.h1)) * (1 - cos(-fish_m.th5 * PI / 180.0));
							fish_z05 = (fishq[5].q6 - fishm2.h1) * cos(-fish_m.th5 * PI / 180.0) + (fishq[5].q8 * fishq[5].q4 - fishq[5].q7 * fishq[5].q5) * sin(-fish_m.th5 * PI / 180.0) + fishq[5].q9 * (fishq[5].q7 * fishq[5].q4 + fishq[5].q8 * fishq[5].q5 + fishq[5].q9 * (fishq[5].q6 - fishm2.h1)) * (1 - cos(-fish_m.th5 * PI / 180.0));
							fish_m.cy01 = (work_x[fish_m.g54] + work_x[0]) + ((fishq[4].q4 + fish_x05) * cos(-fish_m.th4 * PI / 180.0) + (fishq[4].q9 * (fishq[4].q5 + fish_y05) - fishq[4].q8 * (fishq[4].q6 + fish_z05)) * sin(-fish_m.th4 * PI / 180.0) + fishq[4].q7 * (fishq[4].q7 * (fishq[4].q4 + fish_x05) + fishq[4].q8 * (fishq[4].q5 + fish_y05) + fishq[4].q9 * (fishq[4].q6 + fish_z05)) * (1 - cos(-fish_m.th4 * PI / 180.0)));
							fish_m.cy02 = (work_y[fish_m.g54] + work_y[0]) + ((fishq[4].q5 + fish_y05) * cos(-fish_m.th4 * PI / 180.0) + (fishq[4].q7 * (fishq[4].q6 + fish_z05) - fishq[4].q9 * (fishq[4].q4 + fish_x05)) * sin(-fish_m.th4 * PI / 180.0) + fishq[4].q8 * (fishq[4].q7 * (fishq[4].q4 + fish_x05) + fishq[4].q8 * (fishq[4].q5 + fish_y05) + fishq[4].q9 * (fishq[4].q6 + fish_z05)) * (1 - cos(-fish_m.th4 * PI / 180.0)));
							fish_m.cy03 = (work_z[fish_m.g54] + work_z[0]) + ((fishq[4].q6 + fish_z05) * cos(-fish_m.th4 * PI / 180.0) + (fishq[4].q8 * (fishq[4].q4 + fish_x05) - fishq[4].q7 * (fishq[4].q5 + fish_y05)) * sin(-fish_m.th4 * PI / 180.0) + fishq[4].q9 * (fishq[4].q7 * (fishq[4].q4 + fish_x05) + fishq[4].q8 * (fishq[4].q5 + fish_y05) + fishq[4].q9 * (fishq[4].q6 + fish_z05)) * (1 - cos(-fish_m.th4 * PI / 180.0)));
						}
						else if (fishq[0].q10 == 7524 || fishq[0].q10 == 7516 || fishq[0].q10 == 7526 || fishq[0].q10 == 7515)//Sway
						{
							fish_x05 = fishq[4].q4 * cos(-fish_m.th4 * PI / 180.0) + (fishq[4].q9 * fishq[4].q5 - fishq[4].q8 * (fishq[4].q6 - fishm2.h1)) * sin(-fish_m.th4 * PI / 180.0) + fishq[4].q7 * (fishq[4].q7 * fishq[4].q4 + fishq[4].q8 * fishq[4].q5 + fishq[4].q9 * (fishq[4].q6 - fishm2.h1)) * (1 - cos(-fish_m.th4 * PI / 180.0));
							fish_y05 = fishq[4].q5 * cos(-fish_m.th4 * PI / 180.0) + (fishq[4].q7 * (fishq[4].q6 - fishm2.h1) - fishq[4].q9 * fishq[4].q4) * sin(-fish_m.th4 * PI / 180.0) + fishq[4].q8 * (fishq[4].q7 * fishq[4].q4 + fishq[4].q8 * fishq[4].q5 + fishq[4].q9 * (fishq[4].q6 - fishm2.h1)) * (1 - cos(-fish_m.th4 * PI / 180.0));
							fish_z05 = (fishq[4].q6 - fishm2.h1) * cos(-fish_m.th4 * PI / 180.0) + (fishq[4].q8 * fishq[4].q4 - fishq[4].q7 * fishq[4].q5) * sin(-fish_m.th4 * PI / 180.0) + fishq[4].q9 * (fishq[4].q7 * fishq[4].q4 + fishq[4].q8 * fishq[4].q5 + fishq[4].q9 * (fishq[4].q6 - fishm2.h1)) * (1 - cos(-fish_m.th4 * PI / 180.0));
							fish_m.cy01 = (work_x[fish_m.g54] + work_x[0]) * cos(fish_m.th5 * PI / 180.0) + (fishq[5].q9 * fish_m.th2 - fishq[5].q8 * fish_m.th3) * sin(fish_m.th5 * PI / 180.0) + fishq[5].q7 * (fishq[5].q7 * fish_m.th1 + fishq[5].q8 * fish_m.th2 + fishq[5].q9 * fish_m.th3) * (1 - cos(fish_m.th5 * PI / 180.0)) - fish_x05;
							fish_m.cy02 = (work_y[fish_m.g54] + work_y[0]) * cos(fish_m.th5 * PI / 180.0) + (fishq[5].q7 * fish_m.th3 - fishq[5].q9 * fish_m.th1) * sin(fish_m.th5 * PI / 180.0) + fishq[5].q8 * (fishq[5].q7 * fish_m.th1 + fishq[5].q8 * fish_m.th2 + fishq[5].q9 * fish_m.th3) * (1 - cos(fish_m.th5 * PI / 180.0)) - fish_y05;
							fish_m.cy03 = (work_z[fish_m.g54] + work_z[0]) * cos(fish_m.th5 * PI / 180.0) + (fishq[5].q8 * fish_m.th1 - fishq[5].q7 * fish_m.th2) * sin(fish_m.th5 * PI / 180.0) + fishq[5].q9 * (fishq[5].q7 * fish_m.th1 + fishq[5].q8 * fish_m.th2 + fishq[5].q9 * fish_m.th3) * (1 - cos(fish_m.th5 * PI / 180.0)) - fish_z05;
						}
						fish_m.cy04 = work_a[fish_m.g54] + work_a[0];
						fish_m.cy05 = work_b[fish_m.g54] + work_b[0];
						fish_m.cy06 = work_c[fish_m.g54] + work_c[0];
						fish_m.cy07 = work_d[fish_m.g54] + work_d[0];
						fish_m.cy08 = work_e[fish_m.g54] + work_e[0];
						fish_m.cy11 = 1.0,fish_m.cy12 = 0.0,fish_m.cy13 = 0.0;
						fish_m.cy14 = 0.0,fish_m.cy15 = 1.0,fish_m.cy16 = 0.0;
						fish_m.cy17 = 0.0,fish_m.cy18 = 0.0,fish_m.cy19 = 1.0;
					}
					/*	else if(fish_m.g68==168)
					{
					if(fishq[0].q10==7546||fishq[0].q10==7556||fishq[0].q10==7545||fishq[0].q10==7554)
					{
					}
					else if(fishq[0].q10==7521 || fishq[0].q10==7512 || fishq[0].q10==7532 || fishq[0].q10==7531)//Double swing head
					{
					}
					else if(fishq[0].q10==7524 || fishq[0].q10==7516 || fishq[0].q10==7526 || fishq[0].q10==7515)//Sway
					{
					}
				}*/
					else if (fish_m.g68 == 69)
					{
						fish_m.cy01 = work_x[fish_m.g54] + work_x[0];
						fish_m.cy02 = work_y[fish_m.g54] + work_y[0];
						fish_m.cy03 = work_z[fish_m.g54] + work_z[0];
						fish_m.cy04 = work_a[fish_m.g54] + work_a[0];
						fish_m.cy05 = work_b[fish_m.g54] + work_b[0];
						fish_m.cy06 = work_c[fish_m.g54] + work_c[0];
						fish_m.cy07 = work_d[fish_m.g54] + work_d[0];
						fish_m.cy08 = work_e[fish_m.g54] + work_e[0];
						fish_m.cy11 = 1.0,fish_m.cy12 = 0.0,fish_m.cy13 = 0.0;
						fish_m.cy14 = 0.0,fish_m.cy15 = 1.0,fish_m.cy16 = 0.0;
						fish_m.cy17 = 0.0,fish_m.cy18 = 0.0,fish_m.cy19 = 1.0;
					}
				}

				if (fish_m.g28 == 28)
				{
					if (fish_g.th1 != 0.00000012) fish_g.th1 = fishq[1].q51 - fish_m.cy01 + fish_g.th1;
					if (fish_g.th2 != 0.00000012) fish_g.th2 = fishq[2].q51 - fish_m.cy02 + fish_g.th2;
					if (fish_g.th3 != 0.00000012) fish_g.th3 = fishq[3].q51 - fish_m.cy03 + fish_g.th3;
					if (fish_g.th4 != 0.00000012) fish_g.th4 = fishq[4].q51 - fish_m.cy04 + fish_g.th4;
					if (fish_g.th5 != 0.00000012) fish_g.th5 = fishq[5].q51 - fish_m.cy05 + fish_g.th5;
					if (fish_g.th6 != 0.00000012) fish_g.th6 = fishq[6].q51 - fish_m.cy06 + fish_g.th6;
					if (fish_g.th7 != 0.00000012) fish_g.th7 = fishq[7].q51 - fish_m.cy07 + fish_g.th7;
					if (fish_g.th8 != 0.00000012) fish_g.th8 = fishq[8].q51 - fish_m.cy08 + fish_g.th8;
					fish_m.h1 = 0.0 - fish_m.h0,fish_m.d1 = 0.0 - fish_m.d0;//Cancel tool compensation
				}
				else if (fish_m.g28 == 30)
				{
					if (fish_g.th1 != 0.00000012) fish_g.th1 = fishq[1].q52 - fish_m.cy01 + fish_g.th1;
					if (fish_g.th2 != 0.00000012) fish_g.th2 = fishq[2].q52 - fish_m.cy02 + fish_g.th2;
					if (fish_g.th3 != 0.00000012) fish_g.th3 = fishq[3].q52 - fish_m.cy03 + fish_g.th3;
					if (fish_g.th4 != 0.00000012) fish_g.th4 = fishq[4].q52 - fish_m.cy04 + fish_g.th4;
					if (fish_g.th5 != 0.00000012) fish_g.th5 = fishq[5].q52 - fish_m.cy05 + fish_g.th5;
					if (fish_g.th6 != 0.00000012) fish_g.th6 = fishq[6].q52 - fish_m.cy06 + fish_g.th6;
					if (fish_g.th7 != 0.00000012) fish_g.th7 = fishq[7].q52 - fish_m.cy07 + fish_g.th7;
					if (fish_g.th8 != 0.00000012) fish_g.th8 = fishq[8].q52 - fish_m.cy08 + fish_g.th8;
					fish_m.h1 = 0.0 - fish_m.h0,fish_m.d1 = 0.0 - fish_m.d0;//Cancel tool compensation
				}
				//////////////////////////////The following calculates the increment, vector, length, etc.
				if (fish_m.g90 == 90)
				{
					if (fish_g.th1 == 0.00000012) fish_m.ti1 = 0.0;
					else fish_m.ti1 = fish_g.th1 + fish_m.cy01 - fish_m.th1;//Mechanical program point-the previous point of the mechanical coordinate
					if (fish_g.th2 == 0.00000012) fish_m.ti2 = 0.0;
					else fish_m.ti2 = fish_g.th2 + fish_m.cy02 - fish_m.th2;
					if (fish_g.th3 == 0.00000012) fish_m.ti3 = 0.0;
					else fish_m.ti3 = fish_g.th3 + fish_m.cy03 - fish_m.th3;

					if (fishq[4].q2)
					{
						while (fish_g.th4 < 0)//Cannot use ii
							fish_g.th4 = fish_g.th4 + 360.0;
						while (fish_g.th4 >= 360.0)
							fish_g.th4 = fish_g.th4 - 360.0;
						if (fish_g.th4 == 0.00000012)
							fish_m.ti4 = 0.0;
						else
						{
							if (fish_g.th4 + fish_m.cy04 - fish_m.th4 > 180.0)
								fish_m.ti4 = fish_g.th4 + fish_m.cy04 - (fish_m.th4 + 360.0);
							else if (fish_g.th4 + fish_m.cy04 - fish_m.th4 < -180.0)
								fish_m.ti4 = fish_g.th4 + fish_m.cy04 - (fish_m.th4 - 360.0);
							else
								fish_m.ti4 = fish_g.th4 + fish_m.cy04 - fish_m.th4;
						}
					}
					else
					{
						if (fish_g.th4 == 0.00000012)
							fish_m.ti4 = 0.0;
						else
							fish_m.ti4 = fish_g.th4 + fish_m.cy04 - fish_m.th4;
					}
					if (fishq[5].q2)
					{
						while (fish_g.th5 < 0)//Cannot use ii
							fish_g.th5 = fish_g.th5 + 360.0;
						while (fish_g.th5 >= 360.0)
							fish_g.th5 = fish_g.th5 - 360.0;
						if (fish_g.th5 == 0.00000012)
							fish_m.ti5 = 0.0;
						else
						{
							if (fish_g.th5 + fish_m.cy05 - fish_m.th5 > 180.0)
								fish_m.ti5 = fish_g.th5 + fish_m.cy05 - (fish_m.th5 + 360.0);
							else if (fish_g.th5 + fish_m.cy05 - fish_m.th5 < -180.0)
								fish_m.ti5 = fish_g.th5 + fish_m.cy05 - (fish_m.th5 - 360.0);
							else
								fish_m.ti5 = fish_g.th5 + fish_m.cy05 - fish_m.th5;
						}
					}
					else
					{
						if (fish_g.th5 == 0.00000012)
							fish_m.ti5 = 0.0;
						else
							fish_m.ti5 = fish_g.th5 + fish_m.cy05 - fish_m.th5;
					}
					if (fishq[6].q2)
					{
						while (fish_g.th6 < 0)//Cannot use ii
							fish_g.th6 = fish_g.th6 + 360.0;
						while (fish_g.th6 >= 360.0)
							fish_g.th6 = fish_g.th6 - 360.0;
						if (fish_g.th6 == 0.00000012)
							fish_m.ti6 = 0.0;
						else
						{
							if (fish_g.th6 + fish_m.cy06 - fish_m.th6 > 180.0)
								fish_m.ti6 = fish_g.th6 + fish_m.cy06 - (fish_m.th6 + 360.0);
							else if (fish_g.th6 + fish_m.cy06 - fish_m.th6 < -180.0)
								fish_m.ti6 = fish_g.th6 + fish_m.cy06 - (fish_m.th6 - 360.0);
							else
								fish_m.ti6 = fish_g.th6 + fish_m.cy06 - fish_m.th6;
						}
					}
					else
					{
						if (fish_g.th6 == 0.00000012)
							fish_m.ti6 = 0.0;
						else
							fish_m.ti6 = fish_g.th6 + fish_m.cy06 - fish_m.th6;
					}
					if (fishq[7].q2)
					{
						while (fish_g.th7 < 0)//Cannot use ii
							fish_g.th7 = fish_g.th7 + 360.0;
						while (fish_g.th7 >= 360.0)
							fish_g.th7 = fish_g.th7 - 360.0;
						if (fish_g.th7 == 0.00000012)
							fish_m.ti7 = 0.0;
						else
						{
							if (fish_g.th7 + fish_m.cy07 - fish_m.th7 > 180.0)
								fish_m.ti7 = fish_g.th7 + fish_m.cy07 - (fish_m.th7 + 360.0);
							else if (fish_g.th7 + fish_m.cy07 - fish_m.th7 < -180.0)
								fish_m.ti7 = fish_g.th7 + fish_m.cy07 - (fish_m.th7 - 360.0);
							else
								fish_m.ti7 = fish_g.th7 + fish_m.cy07 - fish_m.th7;
						}
					}
					else
					{
						if (fish_g.th7 == 0.00000012)
							fish_m.ti7 = 0.0;
						else
							fish_m.ti7 = fish_g.th7 + fish_m.cy07 - fish_m.th7;
					}
					if (fishq[8].q2)
					{
						while (fish_g.th8 < 0)//Cannot use ii
							fish_g.th8 = fish_g.th8 + 360.0;
						while (fish_g.th8 >= 360.0)
							fish_g.th8 = fish_g.th8 - 360.0;
						if (fish_g.th8 == 0.00000012)
							fish_m.ti8 = 0.0;
						else
						{
							if (fish_g.th8 + fish_m.cy08 - fish_m.th8 > 180.0)
								fish_m.ti8 = fish_g.th8 + fish_m.cy08 - (fish_m.th8 + 360.0);
							else if (fish_g.th8 + fish_m.cy08 - fish_m.th8 < -180.0)
								fish_m.ti8 = fish_g.th8 + fish_m.cy08 - (fish_m.th8 - 360.0);
							else
								fish_m.ti8 = fish_g.th8 + fish_m.cy08 - fish_m.th8;
						}
					}
					else
					{
						if (fish_g.th8 == 0.00000012)
							fish_m.ti8 = 0.0;
						else
							fish_m.ti8 = fish_g.th8 + fish_m.cy08 - fish_m.th8;
					}
				}
				else if (fish_m.g90 == 91)//Incremental (relative) programming
				{
					if (fish_g.th1 == 0.00000012) fish_m.ti1 = 0.0;
					else fish_m.ti1 = fish_g.th1;
					if (fish_g.th2 == 0.00000012) fish_m.ti2 = 0.0;
					else fish_m.ti2 = fish_g.th2;
					if (fish_g.th3 == 0.00000012) fish_m.ti3 = 0.0;
					else fish_m.ti3 = fish_g.th3;
					if (fish_g.th4 == 0.00000012) fish_m.ti4 = 0.0;
					else fish_m.ti4 = fish_g.th4;
					if (fish_g.th5 == 0.00000012) fish_m.ti5 = 0.0;
					else fish_m.ti5 = fish_g.th5;
					if (fish_g.th6 == 0.00000012) fish_m.ti6 = 0.0;
					else fish_m.ti6 = fish_g.th6;
					if (fish_g.th7 == 0.00000012) fish_m.ti7 = 0.0;
					else fish_m.ti7 = fish_g.th7;
					if (fish_g.th8 == 0.00000012) fish_m.ti8 = 0.0;
					else fish_m.ti8 = fish_g.th8;
				}

				if (fish_m.g01 == 0 || fish_m.g01 == 1)
				{
					fish_m.l0 = 0.0;
					fish_m.l1 = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti2 * fish_m.ti2 + fish_m.ti3 * fish_m.ti3);//Optimal instruction length
					if (fish_m.l1 == 0)
					{
						fish_m.u0 = fish_m.u1 = 0.0;
						fish_m.v0 = fish_m.v1 = 0.0;
						fish_m.w0 = fish_m.w1 = 0.0;
					}
					else
					{
						fish_m.u0 = fish_m.u1 = fish_m.ti1 / fish_m.l1;
						fish_m.v0 = fish_m.v1 = fish_m.ti2 / fish_m.l1;
						fish_m.w0 = fish_m.w1 = fish_m.ti3 / fish_m.l1;
					}
				}
				else if (fish_m.g01 == 2 || fish_m.g01 == 3)
				{
					if (fish_m.g17 == 17)
					{
						if (fish_m.ii == 0 && fish_m.jj == 0)//When not programming in IJK
						{
							if (fish_m.ti1 == 0 && fish_m.ti2 == 0)//Start and end coincide
								fish_errer = 1010;//Can not use R programming when the whole circle, alarm
							else
							{
								double tiu = fish_m.ti1 / sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti2 * fish_m.ti2);
								double tiv = fish_m.ti2 / sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti2 * fish_m.ti2);
								if (fish_m.rr > 0)//Is it R+?
								{
									if (fish_m.g01 == 2)
									{
										double tix = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti2 * fish_m.ti2) / 2.0;
										double tiy = -sqrt(fish_m.rr * fish_m.rr - tix * tix);
										fish_m.ii = tix * tiu - tiy * tiv;
										fish_m.jj = tix * tiv + tiy * tiu;
									}
									else if (fish_m.g01 == 3)
									{
										double tix = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti2 * fish_m.ti2) / 2.0;
										double tiy = sqrt(fish_m.rr * fish_m.rr - tix * tix);
										fish_m.ii = tix * tiu - tiy * tiv;
										fish_m.jj = tix * tiv + tiy * tiu;
									}
								}
								else if (fish_m.rr < 0)//Is it R-method
								{
									if (fish_m.g01 == 2)
									{
										double tix = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti2 * fish_m.ti2) / 2.0;
										double tiy = sqrt(fish_m.rr * fish_m.rr - tix * tix);
										fish_m.ii = tix * tiu - tiy * tiv;
										fish_m.jj = tix * tiv + tiy * tiu;
									}
									else if (fish_m.g01 == 3)
									{
										double tix = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti2 * fish_m.ti2) / 2.0;
										double tiy = -sqrt(fish_m.rr * fish_m.rr - tix * tix);
										fish_m.ii = tix * tiu - tiy * tiv;
										fish_m.jj = tix * tiv + tiy * tiu;
									}
								}
								else fish_errer = 1009;//Are not on the police
							}
						}
						double fish_ui = fish_m.ti1 - fish_m.ii, fish_vi = fish_m.ti2 - fish_m.jj;
						fish_m.l0 = sqrt(fish_m.ii * fish_m.ii + fish_m.jj * fish_m.jj);
						fish_m.l1 = sqrt(fish_ui * fish_ui + fish_vi * fish_vi);
						if ((fish_m.l1 - fish_m.l0 <= 120 * fishq[0].q11) && (fish_m.l1 - fish_m.l0 >= -120 * fishq[0].q11))
						{
							fish_m.rr = (fish_m.l0 + fish_m.l1) / 2.0;
							if (fish_m.ii > 0 && fish_m.jj == 0) fish_m.l0 = PI;//Starting point is on the positive X axis
							else if (fish_m.ii > 0 && fish_m.jj > 0) fish_m.l0 = PI + atan(fish_m.jj / fish_m.ii);//Starting point is in the first quadrant
							else if (fish_m.ii == 0 && fish_m.jj > 0) fish_m.l0 = PI * 1.5;//Starting point is on the positive Y axis
							else if (fish_m.ii < 0 && fish_m.jj > 0) fish_m.l0 = 2.0 * PI + atan(fish_m.jj / fish_m.ii);//Starting point is in the second quadrant
							else if (fish_m.ii < 0 && fish_m.jj == 0) fish_m.l0 = 0;//Starting point is on the negative X axis
							else if (fish_m.ii < 0 && fish_m.jj < 0) fish_m.l0 = atan(fish_m.jj / fish_m.ii);//Starting point is in the third quadrant
							else if (fish_m.ii == 0 && fish_m.jj < 0) fish_m.l0 = PI / 2.0;//Starting point is on the negative X axis
							else if (fish_m.ii > 0 && fish_m.jj < 0) fish_m.l0 = PI + atan(fish_m.jj / fish_m.ii);//Starting point is in the fourth quadrant

							if (fish_ui > 0 && fish_vi == 0) fish_m.l1 = 0;//Starting point is on the positive X axis
							else if (fish_ui > 0 && fish_vi > 0) fish_m.l1 = atan(fish_vi / fish_ui);//Starting point is in the first quadrant
							else if (fish_ui == 0 && fish_vi > 0) fish_m.l1 = PI / 2.0;//Starting point is on the positive Y axis
							else if (fish_ui < 0 && fish_vi > 0) fish_m.l1 = PI + atan(fish_vi / fish_ui);//Starting point is in the second quadrant
							else if (fish_ui < 0 && fish_vi == 0) fish_m.l1 = PI;//Starting point is on the negative X axis
							else if (fish_ui < 0 && fish_vi < 0) fish_m.l1 = PI + atan(fish_vi / fish_ui);//Starting point is in the third quadrant
							else if (fish_ui == 0 && fish_vi < 0) fish_m.l1 = PI * 1.5;//Starting point is on the negative Y axis
							else if (fish_ui > 0 && fish_vi < 0) fish_m.l1 = 2.0 * PI + atan(fish_vi / fish_ui);//Starting point is in the fourth quadrant
							if (fish_m.g01 == 2)
							{
								fish_m.u0 = -fish_m.jj / sqrt(fish_m.ii * fish_m.ii + fish_m.jj * fish_m.jj);
								fish_m.v0 = fish_m.ii / sqrt(fish_m.ii * fish_m.ii + fish_m.jj * fish_m.jj);
								fish_m.u1 = fish_vi / sqrt(fish_ui * fish_ui + fish_vi * fish_vi);
								fish_m.v1 = -fish_ui / sqrt(fish_ui * fish_ui + fish_vi * fish_vi);
								while (fish_m.l0 - fish_m.l1 < fishq[0].q11 / fish_m.rr / 2.0)
									fish_m.l0 = fish_m.l0 + 2 * PI;
								fish_m.l1 = sqrt((fish_m.l0 - fish_m.l1) * fish_m.rr * (fish_m.l0 - fish_m.l1) * fish_m.rr + fish_m.ti3 * fish_m.ti3);
							}
							else if (fish_m.g01 == 3)
							{
								fish_m.u0 = fish_m.jj / sqrt(fish_m.ii * fish_m.ii + fish_m.jj * fish_m.jj);
								fish_m.v0 = -fish_m.ii / sqrt(fish_m.ii * fish_m.ii + fish_m.jj * fish_m.jj);
								fish_m.u1 = -fish_vi / sqrt(fish_ui * fish_ui + fish_vi * fish_vi);
								fish_m.v1 = fish_ui / sqrt(fish_ui * fish_ui + fish_vi * fish_vi);
								while (fish_m.l1 - fish_m.l0 < fishq[0].q11 / fish_m.rr / 2.0)
									fish_m.l1 = fish_m.l1 + 2 * PI;
								fish_m.l1 = sqrt((fish_m.l1 - fish_m.l0) * fish_m.rr * (fish_m.l1 - fish_m.l0) * fish_m.rr + fish_m.ti3 * fish_m.ti3);
							}
							fish_m.w0 = fish_m.w1 = fish_m.ti3 / fish_m.l1;
							fish_m.u0 = fish_m.u0 * sqrt(1.0 - fish_m.w0 * fish_m.w0);
							fish_m.v0 = fish_m.v0 * sqrt(1.0 - fish_m.w0 * fish_m.w0);
							fish_m.u1 = fish_m.u1 * sqrt(1.0 - fish_m.w1 * fish_m.w1);
							fish_m.v1 = fish_m.v1 * sqrt(1.0 - fish_m.w1 * fish_m.w1);
						}
						else
							fish_errer = 1008;
					}
					else if (fish_m.g17 == 18)
					{
						if (fish_m.ii == 0 && fish_m.kk == 0)//When not programming in IJK
						{
							if (fish_m.ti1 == 0 && fish_m.ti3 == 0)//Start and end coincide
								fish_errer = 1010;//Can not use R programming when the whole circle, alarm
							else
							{
								double tiu = fish_m.ti1 / sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti3 * fish_m.ti3);
								double tiw = fish_m.ti3 / sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti3 * fish_m.ti3);
								if (fish_m.rr > 0)//Is it R+?
								{
									if (fish_m.g01 == 3)
									{
										double tix = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti3 * fish_m.ti3) / 2.0;
										double tiz = -sqrt(fish_m.rr * fish_m.rr - tix * tix);
										fish_m.ii = tix * tiu - tiz * tiw;
										fish_m.kk = tix * tiw + tiz * tiu;
									}
									else if (fish_m.g01 == 2)
									{
										double tix = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti3 * fish_m.ti3) / 2.0;
										double tiz = sqrt(fish_m.rr * fish_m.rr - tix * tix);
										fish_m.ii = tix * tiu - tiz * tiw;
										fish_m.kk = tix * tiw + tiz * tiu;
									}
								}
								else if (fish_m.rr < 0)//Is it R-method
								{
									if (fish_m.g01 == 3)
									{
										double tix = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti3 * fish_m.ti3) / 2.0;
										double tiz = sqrt(fish_m.rr * fish_m.rr - tix * tix);
										fish_m.ii = tix * tiu - tiz * tiw;
										fish_m.kk = tix * tiw + tiz * tiu;
									}
									else if (fish_m.g01 == 2)
									{
										double tix = sqrt(fish_m.ti1 * fish_m.ti1 + fish_m.ti3 * fish_m.ti3) / 2.0;
										double tiz = -sqrt(fish_m.rr * fish_m.rr - tix * tix);
										fish_m.ii = tix * tiu - tiz * tiw;
										fish_m.kk = tix * tiw + tiz * tiu;
									}
								}
								else fish_errer = 1009;//Are not on the police
							}
						}
						double fish_ui = fish_m.ti1 - fish_m.ii, fish_wi = fish_m.ti3 - fish_m.kk;
						fish_m.l0 = sqrt(fish_m.ii * fish_m.ii + fish_m.kk * fish_m.kk);
						fish_m.l1 = sqrt(fish_ui * fish_ui + fish_wi * fish_wi);
						if ((fish_m.l1 - fish_m.l0 <= 120 * fishq[0].q11) && (fish_m.l1 - fish_m.l0 >= -120 * fishq[0].q11))
						{
							fish_m.rr = (fish_m.l0 + fish_m.l1) / 2.0;
							if (fish_m.ii > 0 && fish_m.kk == 0) fish_m.l0 = PI;//Starting point is on the positive X axis
							else if (fish_m.ii > 0 && fish_m.kk > 0) fish_m.l0 = PI + atan(fish_m.kk / fish_m.ii);//Starting point is in the first quadrant
							else if (fish_m.ii == 0 && fish_m.kk > 0) fish_m.l0 = PI * 1.5;//Starting point is on the positive Y axis
							else if (fish_m.ii < 0 && fish_m.kk > 0) fish_m.l0 = 2.0 * PI + atan(fish_m.kk / fish_m.ii);//Starting point is in the second quadrant
							else if (fish_m.ii < 0 && fish_m.kk == 0) fish_m.l0 = 0;//Starting point is on the negative X axis
							else if (fish_m.ii < 0 && fish_m.kk < 0) fish_m.l0 = atan(fish_m.kk / fish_m.ii);//Starting point is in the third quadrant
							else if (fish_m.ii == 0 && fish_m.kk < 0) fish_m.l0 = PI / 2.0;//Starting point is on the negative X axis
							else if (fish_m.ii > 0 && fish_m.kk < 0) fish_m.l0 = PI + atan(fish_m.kk / fish_m.ii);//Starting point is in the fourth quadrant

							if (fish_ui > 0 && fish_wi == 0) fish_m.l1 = 0;//Starting point is on the positive X axis
							else if (fish_ui > 0 && fish_wi > 0) fish_m.l1 = atan(fish_wi / fish_ui);//Starting point is in the first quadrant
							else if (fish_ui == 0 && fish_wi > 0) fish_m.l1 = PI / 2.0;//Starting point is on the positive Y axis
							else if (fish_ui < 0 && fish_wi > 0) fish_m.l1 = PI + atan(fish_wi / fish_ui);//Starting point is in the second quadrant
							else if (fish_ui < 0 && fish_wi == 0) fish_m.l1 = PI;//Starting point is on the negative X axis
							else if (fish_ui < 0 && fish_wi < 0) fish_m.l1 = PI + atan(fish_wi / fish_ui);//Starting point is in the third quadrant
							else if (fish_ui == 0 && fish_wi < 0) fish_m.l1 = PI * 1.5;//Starting point is on the negative Y axis
							else if (fish_ui > 0 && fish_wi < 0) fish_m.l1 = 2.0 * PI + atan(fish_wi / fish_ui);//Starting point is in the fourth quadrant
							if (fish_m.g01 == 3)
							{
								fish_m.u0 = -fish_m.kk / sqrt(fish_m.ii * fish_m.ii + fish_m.kk * fish_m.kk);
								fish_m.w0 = fish_m.ii / sqrt(fish_m.ii * fish_m.ii + fish_m.kk * fish_m.kk);
								fish_m.u1 = fish_wi / sqrt(fish_ui * fish_ui + fish_wi * fish_wi);
								fish_m.w1 = -fish_ui / sqrt(fish_ui * fish_ui + fish_wi * fish_wi);
								while (fish_m.l0 - fish_m.l1 < fishq[0].q11 / fish_m.rr / 2.0)
									fish_m.l0 = fish_m.l0 + 2 * PI;
								fish_m.l1 = sqrt((fish_m.l0 - fish_m.l1) * fish_m.rr * (fish_m.l0 - fish_m.l1) * fish_m.rr + fish_m.ti2 * fish_m.ti2);
							}
							else if (fish_m.g01 == 2)
							{
								fish_m.u0 = fish_m.kk / sqrt(fish_m.ii * fish_m.ii + fish_m.kk * fish_m.kk);
								fish_m.w0 = -fish_m.ii / sqrt(fish_m.ii * fish_m.ii + fish_m.kk * fish_m.kk);
								fish_m.u1 = -fish_wi / sqrt(fish_ui * fish_ui + fish_wi * fish_wi);
								fish_m.w1 = fish_ui / sqrt(fish_ui * fish_ui + fish_wi * fish_wi);
								while (fish_m.l1 - fish_m.l0 < fishq[0].q11 / fish_m.rr / 2.0)
									fish_m.l1 = fish_m.l1 + 2 * PI;
								fish_m.l1 = sqrt((fish_m.l1 - fish_m.l0) * fish_m.rr * (fish_m.l1 - fish_m.l0) * fish_m.rr + fish_m.ti2 * fish_m.ti2);
							}
							fish_m.v0 = fish_m.v1 = fish_m.ti2 / fish_m.l1;
							fish_m.u0 = fish_m.u0 * sqrt(1.0 - fish_m.v0 * fish_m.v0);
							fish_m.w0 = fish_m.w0 * sqrt(1.0 - fish_m.v0 * fish_m.v0);
							fish_m.u1 = fish_m.u1 * sqrt(1.0 - fish_m.v1 * fish_m.v1);
							fish_m.w1 = fish_m.w1 * sqrt(1.0 - fish_m.v1 * fish_m.v1);
						}
						else
							fish_errer = 1008;
					}
					else if (fish_m.g17 == 19)
					{
						if (fish_m.jj == 0 && fish_m.kk == 0)//When not programming in IJK
						{
							if (fish_m.ti2 == 0 && fish_m.ti3 == 0)//Start and end coincide
								fish_errer = 1010;//Can not use R programming when the whole circle, alarm
							else
							{
								double tiv = fish_m.ti2 / sqrt(fish_m.ti2 * fish_m.ti2 + fish_m.ti3 * fish_m.ti3);
								double tiw = fish_m.ti3 / sqrt(fish_m.ti2 * fish_m.ti2 + fish_m.ti3 * fish_m.ti3);
								if (fish_m.rr > 0)//Is it R+?
								{
									if (fish_m.g01 == 2)
									{
										double tiy = sqrt(fish_m.ti2 * fish_m.ti2 + fish_m.ti3 * fish_m.ti3) / 2.0;
										double tiz = -sqrt(fish_m.rr * fish_m.rr - tiy * tiy);
										fish_m.jj = tiy * tiv - tiz * tiw;
										fish_m.kk = tiy * tiw + tiz * tiv;
									}
									else if (fish_m.g01 == 3)
									{
										double tiy = sqrt(fish_m.ti2 * fish_m.ti2 + fish_m.ti3 * fish_m.ti3) / 2.0;
										double tiz = sqrt(fish_m.rr * fish_m.rr - tiy * tiy);
										fish_m.jj = tiy * tiv - tiz * tiw;
										fish_m.kk = tiy * tiw + tiz * tiv;
									}
								}
								else if (fish_m.rr < 0)//Is it R-method
								{
									if (fish_m.g01 == 2)
									{
										double tiy = sqrt(fish_m.ti2 * fish_m.ti2 + fish_m.ti3 * fish_m.ti3) / 2.0;
										double tiz = sqrt(fish_m.rr * fish_m.rr - tiy * tiy);
										fish_m.jj = tiy * tiv - tiz * tiw;
										fish_m.kk = tiy * tiw + tiz * tiv;
									}
									else if (fish_m.g01 == 3)
									{
										double tiy = sqrt(fish_m.ti2 * fish_m.ti2 + fish_m.ti3 * fish_m.ti3) / 2.0;
										double tiz = -sqrt(fish_m.rr * fish_m.rr - tiy * tiy);
										fish_m.jj = tiy * tiv - tiz * tiw;
										fish_m.kk = tiy * tiw + tiz * tiv;
									}
								}
								else fish_errer = 1009;//Are not on the police
							}
						}
						double fish_vi = fish_m.ti2 - fish_m.jj, fish_wi = fish_m.ti3 - fish_m.kk;
						fish_m.l0 = sqrt(fish_m.jj * fish_m.jj + fish_m.kk * fish_m.kk);
						fish_m.l1 = sqrt(fish_vi * fish_vi + fish_wi * fish_wi);
						if ((fish_m.l1 - fish_m.l0 <= 120 * fishq[0].q11) && (fish_m.l1 - fish_m.l0 >= -120 * fishq[0].q11))
						{
							fish_m.rr = (fish_m.l0 + fish_m.l1) / 2.0;
							if (fish_m.jj > 0 && fish_m.kk == 0) fish_m.l0 = PI;//Starting point is on the positive X axis
							else if (fish_m.jj > 0 && fish_m.kk > 0) fish_m.l0 = PI + atan(fish_m.kk / fish_m.jj);//Starting point is in the first quadrant
							else if (fish_m.jj == 0 && fish_m.kk > 0) fish_m.l0 = PI * 1.5;//Starting point is on the positive Y axis
							else if (fish_m.jj < 0 && fish_m.kk > 0) fish_m.l0 = 2.0 * PI + atan(fish_m.kk / fish_m.jj);//Starting point is in the second quadrant
							else if (fish_m.jj < 0 && fish_m.kk == 0) fish_m.l0 = 0;//Starting point is on the negative X axis
							else if (fish_m.jj < 0 && fish_m.kk < 0) fish_m.l0 = atan(fish_m.kk / fish_m.jj);//Starting point is in the third quadrant
							else if (fish_m.jj == 0 && fish_m.kk < 0) fish_m.l0 = PI / 2.0;//Starting point is on the negative X axis
							else if (fish_m.jj > 0 && fish_m.kk < 0) fish_m.l0 = PI + atan(fish_m.kk / fish_m.jj);//Starting point is in the fourth quadrant

							if (fish_vi > 0 && fish_wi == 0) fish_m.l1 = 0;//Starting point is on the positive X axis
							else if (fish_vi > 0 && fish_wi > 0) fish_m.l1 = atan(fish_wi / fish_vi);//Starting point is in the first quadrant
							else if (fish_vi == 0 && fish_wi > 0) fish_m.l1 = PI / 2.0;//Starting point is on the positive Y axis
							else if (fish_vi < 0 && fish_wi > 0) fish_m.l1 = PI + atan(fish_wi / fish_vi);//Starting point is in the second quadrant
							else if (fish_vi < 0 && fish_wi == 0) fish_m.l1 = PI;//Starting point is on the negative X axis
							else if (fish_vi < 0 && fish_wi < 0) fish_m.l1 = PI + atan(fish_wi / fish_vi);//Starting point is in the third quadrant
							else if (fish_vi == 0 && fish_wi < 0) fish_m.l1 = PI * 1.5;//Starting point is on the negative Y axis
							else if (fish_vi > 0 && fish_wi < 0) fish_m.l1 = 2.0 * PI + atan(fish_wi / fish_vi);//Starting point is in the fourth quadrant
							if (fish_m.g01 == 2)
							{
								fish_m.v0 = -fish_m.kk / sqrt(fish_m.jj * fish_m.jj + fish_m.kk * fish_m.kk);
								fish_m.w0 = fish_m.jj / sqrt(fish_m.jj * fish_m.jj + fish_m.kk * fish_m.kk);
								fish_m.v1 = fish_wi / sqrt(fish_vi * fish_vi + fish_wi * fish_wi);
								fish_m.w1 = -fish_vi / sqrt(fish_vi * fish_vi + fish_wi * fish_wi);
								while (fish_m.l0 - fish_m.l1 < fishq[0].q11 / fish_m.rr / 2.0)
									fish_m.l0 = fish_m.l0 + 2 * PI;
								fish_m.l1 = sqrt((fish_m.l0 - fish_m.l1) * fish_m.rr * (fish_m.l0 - fish_m.l1) * fish_m.rr + fish_m.ti1 * fish_m.ti1);
							}
							else if (fish_m.g01 == 3)
							{
								fish_m.v0 = fish_m.kk / sqrt(fish_m.jj * fish_m.jj + fish_m.kk * fish_m.kk);
								fish_m.w0 = -fish_m.jj / sqrt(fish_m.jj * fish_m.jj + fish_m.kk * fish_m.kk);
								fish_m.v1 = -fish_wi / sqrt(fish_vi * fish_vi + fish_wi * fish_wi);
								fish_m.w1 = fish_vi / sqrt(fish_vi * fish_vi + fish_wi * fish_wi);
								while (fish_m.l1 - fish_m.l0 < fishq[0].q11 / fish_m.rr / 2.0)
									fish_m.l1 = fish_m.l1 + 2 * PI;
								fish_m.l1 = sqrt((fish_m.l1 - fish_m.l0) * fish_m.rr * (fish_m.l1 - fish_m.l0) * fish_m.rr + fish_m.ti1 * fish_m.ti1);
							}
							fish_m.u0 = fish_m.u1 = fish_m.ti1 / fish_m.l1;
							fish_m.v0 = fish_m.v0 * sqrt(1.0 - fish_m.u0 * fish_m.u0);
							fish_m.w0 = fish_m.w0 * sqrt(1.0 - fish_m.u0 * fish_m.u0);
							fish_m.v1 = fish_m.v1 * sqrt(1.0 - fish_m.u1 * fish_m.u1);
							fish_m.w1 = fish_m.w1 * sqrt(1.0 - fish_m.u1 * fish_m.u1);
						}
						else
							fish_errer = 1008;
					}
				}
				//////////////////////////////////////Calculation vector
				double fish_lve = sqrt(fish_m.ti4 * fish_m.ti4 + fish_m.ti5 * fish_m.ti5 + fish_m.ti6 * fish_m.ti6 + fish_m.ti7 * fish_m.ti7 + fish_m.ti8 * fish_m.ti8);
				if (fish_lve == 0)
				{
					fish_m.va = 0.0;
					fish_m.vb = 0.0;
					fish_m.vc = 0.0;
					fish_m.vd = 0.0;
					fish_m.ve = 0.0;
					if (fm_va == 0 && fm_vb == 0 && fm_vc == 0 && fm_vd == 0 && fm_ve == 0)
						fishm1.a1 = 0.0;
					else
						fishm1.a1 = 180.0;
					if (fish_m.l1 == 0) fish_m.a1 = 180.0;
					else
					{
						if (fm_vx * fish_m.u0 + fm_vy * fish_m.v0 + fm_vz * fish_m.w0 >= 1.0) fish_m.a1 = 0.0;
						else if (fm_vx * fish_m.u0 + fm_vy * fish_m.v0 + fm_vz * fish_m.w0 <= -1.0) fish_m.a1 = 180.0;
						else fish_m.a1 = acos(fm_vx * fish_m.u0 + fm_vy * fish_m.v0 + fm_vz * fish_m.w0) * 180.0 / PI;
					}
				}
				else
				{
					fish_m.va = fish_m.ti4 / fish_lve;
					fish_m.vb = fish_m.ti5 / fish_lve;
					fish_m.vc = fish_m.ti6 / fish_lve;
					fish_m.vd = fish_m.ti7 / fish_lve;
					fish_m.ve = fish_m.ti8 / fish_lve;
					if (fish_m.l1 == 0) fish_m.a1 = 0.0;
					else
					{
						if (fm_vx * fish_m.u0 + fm_vy * fish_m.v0 + fm_vz * fish_m.w0 >= 1.0) fish_m.a1 = 0.0;
						else if (fm_vx * fish_m.u0 + fm_vy * fish_m.v0 + fm_vz * fish_m.w0 <= -1.0) fish_m.a1 = 180.0;
						else fish_m.a1 = acos(fm_vx * fish_m.u0 + fm_vy * fish_m.v0 + fm_vz * fish_m.w0) * 180.0 / PI;
					}
					if (fish_lve > fish_m.l1)
						fish_m.l1 = fish_lve;

					if (fm_va * fish_m.va + fm_vb * fish_m.vb + fm_vc * fish_m.vc + fm_vd * fish_m.vd + fm_ve * fish_m.ve >= 1.0) fishm1.a1 = 0.0;
					else if (fm_va * fish_m.va + fm_vb * fish_m.vb + fm_vc * fish_m.vc + fm_vd * fish_m.vd + fm_ve * fish_m.ve <= -1.0) fishm1.a1 = 180.0;
					else fishm1.a1 = acos(fm_va * fish_m.va + fm_vb * fish_m.vb + fm_vc * fish_m.vc + fm_vd * fish_m.vd + fm_ve * fish_m.ve) * 180.0 / PI;
				}
				if (fishm1.a1 > fish_m.a1) fish_m.a1 = fishm1.a1;
				///////////////////////////////////////////////////////////////////Calculate XYZ value and optimized length after RTCP
				USB4 pth1 = usbcncRTCP(fish_m);//Calculate the coordinates after RTCP
				USB4 pth2 = usbcncRTCP(usbcncGOGO(fish_m));//Calculate the coordinates after RTCP

				if (fish_jgbl <= 0.3)
				{
					if (fish_m.l1 / fish_m.ff / 0.3 < fabs(pth2.th1 - pth1.th1) / fishq[1].q12)
						fish_m.l1 = fabs(pth2.th1 - pth1.th1) * fish_m.ff * 0.3 / fishq[1].q12;
					if (fish_m.l1 / fish_m.ff / 0.3 < fabs(pth2.th2 - pth1.th2) / fishq[2].q12)
						fish_m.l1 = fabs(pth2.th2 - pth1.th2) * fish_m.ff * 0.3 / fishq[2].q12;
					if (fish_m.l1 / fish_m.ff / 0.3 < fabs(pth2.th3 - pth1.th3) / fishq[3].q12)
						fish_m.l1 = fabs(pth2.th3 - pth1.th3) * fish_m.ff * 0.3 / fishq[3].q12;
					if (fish_m.l1 / fish_m.ff / 0.3 < fabs(pth2.th4 - pth1.th4) / fishq[4].q12)
						fish_m.l1 = fabs(pth2.th4 - pth1.th4) * fish_m.ff * 0.3 / fishq[4].q12;
					if (fish_m.l1 / fish_m.ff / 0.3 < fabs(pth2.th5 - pth1.th5) / fishq[5].q12)
						fish_m.l1 = fabs(pth2.th5 - pth1.th5) * fish_m.ff * 0.3 / fishq[5].q12;
					if (fish_m.l1 / fish_m.ff / 0.3 < fabs(pth2.th6 - pth1.th6) / fishq[6].q12)
						fish_m.l1 = fabs(pth2.th6 - pth1.th6) * fish_m.ff * 0.3 / fishq[6].q12;
					if (fish_m.l1 / fish_m.ff / 0.3 < fabs(pth2.th7 - pth1.th7) / fishq[7].q12)
						fish_m.l1 = fabs(pth2.th7 - pth1.th7) * fish_m.ff * 0.3 / fishq[7].q12;
					if (fish_m.l1 / fish_m.ff / 0.3 < fabs(pth2.th8 - pth1.th8) / fishq[8].q12)
						fish_m.l1 = fabs(pth2.th8 - pth1.th8) * fish_m.ff * 0.3 / fishq[8].q12;
				}
				else
				{
					if (fish_m.l1 / fish_m.ff / fish_jgbl < fabs(pth2.th1 - pth1.th1) / fishq[1].q12)
						fish_m.l1 = fabs(pth2.th1 - pth1.th1) * fish_m.ff * fish_jgbl / fishq[1].q12;
					if (fish_m.l1 / fish_m.ff / fish_jgbl < fabs(pth2.th2 - pth1.th2) / fishq[2].q12)
						fish_m.l1 = fabs(pth2.th2 - pth1.th2) * fish_m.ff * fish_jgbl / fishq[2].q12;
					if (fish_m.l1 / fish_m.ff / fish_jgbl < fabs(pth2.th3 - pth1.th3) / fishq[3].q12)
						fish_m.l1 = fabs(pth2.th3 - pth1.th3) * fish_m.ff * fish_jgbl / fishq[3].q12;
					if (fish_m.l1 / fish_m.ff / fish_jgbl < fabs(pth2.th4 - pth1.th4) / fishq[4].q12)
						fish_m.l1 = fabs(pth2.th4 - pth1.th4) * fish_m.ff * fish_jgbl / fishq[4].q12;
					if (fish_m.l1 / fish_m.ff / fish_jgbl < fabs(pth2.th5 - pth1.th5) / fishq[5].q12)
						fish_m.l1 = fabs(pth2.th5 - pth1.th5) * fish_m.ff * fish_jgbl / fishq[5].q12;
					if (fish_m.l1 / fish_m.ff / fish_jgbl < fabs(pth2.th6 - pth1.th6) / fishq[6].q12)
						fish_m.l1 = fabs(pth2.th6 - pth1.th6) * fish_m.ff * fish_jgbl / fishq[6].q12;
					if (fish_m.l1 / fish_m.ff / fish_jgbl < fabs(pth2.th7 - pth1.th7) / fishq[7].q12)
						fish_m.l1 = fabs(pth2.th7 - pth1.th7) * fish_m.ff * fish_jgbl / fishq[7].q12;
					if (fish_m.l1 / fish_m.ff / fish_jgbl < fabs(pth2.th8 - pth1.th8) / fishq[8].q12)
						fish_m.l1 = fabs(pth2.th8 - pth1.th8) * fish_m.ff * fish_jgbl / fishq[8].q12;
				}
			}
			else
			{
				fish_m.l0 = 0,fish_m.l1 = 0,fish_m.a1 = 180.0;
			}
			return fish_m;
		}

		int usbcncTOTO()
		{
			for (reed1 = fishq[0].q11; reed1 < fishm2.l1 && fish_errer == 0; reed1 = reed1 + fishq[0].q11 * fish_feed / fishq[0].q14)
			{
				if (fish1053 && !fish1054)
				{
					if (fishm2.g01 == 0)
					{
						if (fish_feed > fishq[0].q12)
							fish_feed = fishq[0].q12;
						else if (fish_goto - reed1 <= fish_feed * fish_feed * fishq[0].q11 / fishq[0].q13 / 20000.0 && fish_feed > fishq[0].q13)
							fish_feed = fish_feed - fishq[0].q13;
						else if ((fish1058 || fishm2.mm == 0 || (fish1057 && fishm2.mm == 1)) && fishm2.l1 - reed1 <= fish_feed * fish_feed * fishq[0].q11 / fishq[0].q13 / 20000.0 && fish_feed > fishq[0].q13)
							fish_feed = fish_feed - fishq[0].q13;
						else if (fishm2.l1 - reed1 <= (fish_feed * fish_feed - fishq[0].q18 * fishq[0].q18) * fishq[0].q11 / fishq[0].q13 / 20000.0 && fish_feed > fishq[0].q18)
							fish_feed = fish_feed - fishq[0].q13;
						else if (fish_feed > fishq[0].q12 * fish_jgbl && fish_feed > fishq[0].q13)
							fish_feed = fish_feed - fishq[0].q13;
						else if (fish_feed < fishq[0].q13 && fish_jgbl == 0)
							fish_feed = 0.0;
						else if (fish_feed < fishq[0].q12 * fish_jgbl)
							fish_feed = fish_feed + fishq[0].q13;
					}
					else
					{
						if (fish_feed > fishq[0].q12)
							fish_feed = fishq[0].q12;
						else if (fish_goto - reed1 <= fish_feed * fish_feed * fishq[0].q11 / fishq[0].q13 / 20000.0 && fish_feed > fishq[0].q13)
							fish_feed = fish_feed - fishq[0].q13;
						else if ((fish1058 || fishm2.mm == 0 || (fish1057 && fishm2.mm == 1)) && fishm2.l1 - reed1 <= fish_feed * fish_feed * fishq[0].q11 / fishq[0].q13 / 20000.0 && fish_feed > fishq[0].q13)
							fish_feed = fish_feed - fishq[0].q13;
						else if (fishm2.l1 - reed1 <= (fish_feed * fish_feed - fishq[0].q18 * fishq[0].q18) * fishq[0].q11 / fishq[0].q13 / 20000.0 && fish_feed > fishq[0].q18)
							fish_feed = fish_feed - fishq[0].q13;
						else if (fish_feed > fishm2.ff * fish_jgbl && fish_feed > fishq[0].q13)
							fish_feed = fish_feed - fishq[0].q13;
						else if (fish_feed < fishq[0].q13 && fish_jgbl == 0)
							fish_feed = 0.0;
						else if (fish_feed < fishm2.ff * fish_jgbl)
							fish_feed = fish_feed + fishq[0].q13;
					}
				}
				else
				{
					if (fish_feed >= fishq[0].q13)
						fish_feed = fish_feed - fishq[0].q13;
					else
						fish_feed = 0.0;
				}

				if (fishm2.g01 == 0 || fishm2.g01 == 1)
				{
					fishm2.th1 = fishm1.th1 + fishm2.ti1 * reed1 / fishm2.l1;//Mechanical theoretical point coordinates
					fishm2.th2 = fishm1.th2 + fishm2.ti2 * reed1 / fishm2.l1;
					fishm2.th3 = fishm1.th3 + fishm2.ti3 * reed1 / fishm2.l1;
				}
				else if (fishm2.g01 == 2 || fishm2.g01 == 3)
				{
					if (fishm2.g17 == 17)
					{
						if (fishm2.g01 == 2) reed2 = fishm2.l0 - sqrt(reed1 * reed1 - fishm2.ti3 * reed1 / fishm2.l1 * fishm2.ti3 * reed1 / fishm2.l1) / fishm2.rr;//G02
						else reed2 = fishm2.l0 + sqrt(reed1 * reed1 - fishm2.ti3 * reed1 / fishm2.l1 * fishm2.ti3 * reed1 / fishm2.l1) / fishm2.rr;//G03
						fishm2.th1 = fishm1.th1 + fishm2.ii + fishm2.rr * cos(reed2);
						fishm2.th2 = fishm1.th2 + fishm2.jj + fishm2.rr * sin(reed2);
						fishm2.th3 = fishm1.th3 + fishm2.ti3 * reed1 / fishm2.l1;
					}
					else if (fishm2.g17 == 18)
					{
						if (fishm2.g01 == 3) reed2 = fishm2.l0 - sqrt(reed1 * reed1 - fishm2.ti2 * reed1 / fishm2.l1 * fishm2.ti2 * reed1 / fishm2.l1) / fishm2.rr;//G02
						else reed2 = fishm2.l0 + sqrt(reed1 * reed1 - fishm2.ti2 * reed1 / fishm2.l1 * fishm2.ti2 * reed1 / fishm2.l1) / fishm2.rr;//G03
						fishm2.th1 = fishm1.th1 + fishm2.ii + fishm2.rr * cos(reed2);
						fishm2.th2 = fishm1.th2 + fishm2.ti2 * reed1 / fishm2.l1;
						fishm2.th3 = fishm1.th3 + fishm2.kk + fishm2.rr * sin(reed2);
					}
					else if (fishm2.g17 == 19)
					{
						if (fishm2.g01 == 2) reed2 = fishm2.l0 - sqrt(reed1 * reed1 - fishm2.ti1 * reed1 / fishm2.l1 * fishm2.ti1 * reed1 / fishm2.l1) / fishm2.rr;//G02
						else reed2 = fishm2.l0 + sqrt(reed1 * reed1 - fishm2.ti1 * reed1 / fishm2.l1 * fishm2.ti1 * reed1 / fishm2.l1) / fishm2.rr;//G03
						fishm2.th1 = fishm1.th1 + fishm2.ti1 * reed1 / fishm2.l1;
						fishm2.th2 = fishm1.th2 + fishm2.jj + fishm2.rr * cos(reed2);
						fishm2.th3 = fishm1.th3 + fishm2.kk + fishm2.rr * sin(reed2);
					}
				}
				fishm2.th4 = fishm1.th4 + fishm2.ti4 * reed1 / fishm2.l1;
				fishm2.th5 = fishm1.th5 + fishm2.ti5 * reed1 / fishm2.l1;
				fishm2.th6 = fishm1.th6 + fishm2.ti6 * reed1 / fishm2.l1;
				fishm2.th7 = fishm1.th7 + fishm2.ti7 * reed1 / fishm2.l1;
				fishm2.th8 = fishm1.th8 + fishm2.ti8 * reed1 / fishm2.l1;
				fishm2.h0 = fishm1.h0 + fishm2.h1 * reed1 / fishm2.l1;
				fishm2.d0 = fishm1.d0 + fishm2.d1 * reed1 / fishm2.l1;
				usbcncpath();
				if (fish1054 && fish_feed == 0)//Program reset
				{
					fishm2.g01 = 0;
					fishm2.g81 = 80;
					return 9999;
				}
			}
			return fish_errer;
		}
		////////////////////////////////////////////////////
		int usbcncGOTO(USB2 fish_o, bool fish_jsd)//Automatic data processing
		{
			if (fish_o.g00 == 0 || !fish1059)//'/'Jump priority is highest
			{
				fishm1 = fishm2;
				fishm2 = usbcncLA(fishm1, fish_o);//Calculate length, vector
				if (fish_errer != 0) return fish_errer;
				if (fishm2.mm == 128) usbcnc_M128();//M front
				else if (fishm2.mm == 3) usbcnc_M03(fishm2.ss);
				else if (fishm2.mm == 4) usbcnc_M04(fishm2.ss);
				if (fishm2.g81 == 81)//Point drilling cycle
				{
					fishg83zz = fishm1.th3 - fishm1.cy03;
					if (fish_o.th1 != 0.00000012) fishg83x = fish_o.th1;
					if (fish_o.th2 != 0.00000012) fishg83y = fish_o.th2;
					if (fish_o.th3 != 0.00000012) fishg83z = fish_o.th3;
					if (fish_o.th4 != 0.00000012) fishg83a = fish_o.th4;
					if (fish_o.th5 != 0.00000012) fishg83b = fish_o.th5;
					if (fish_o.th6 != 0.00000012) fishg83c = fish_o.th6;
					if (fish_o.th7 != 0.00000012) fishg83d = fish_o.th7;
					if (fish_o.th8 != 0.00000012) fishg83e = fish_o.th8;
					if (fish_o.rr != 0.00000012) fishg83r = fish_o.rr;
					if (fish_o.pp != 0.00000012) fishg83p = fish_o.pp;
					if (fish_o.qq != 0.00000012) fishg83q = fish_o.qq;
					if (fish_o.ll != 0.00000012) fishg83l = fish_o.ll;
					fish_o.g01 = 0,fish_o.th3 = 0.00000012;//The first step is fast xyabcd positioning
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the first step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 2 Quickly locate to the R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the second step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83z;//The third step is cutting to point Z
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					usbcnc_G04(100);
					//No fourth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 5 Return to R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the fifth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					if (fishm2.g98 == 98)
					{
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zz;//Step 6 quickly return to the R plane
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the sixth step
					}
				}
				else if (fishm2.g81 == 82)//The drill cycle has a pause time
				{
					fishg83zz = fishm1.th3 - fishm1.cy03;
					if (fish_o.th1 != 0.00000012) fishg83x = fish_o.th1;
					if (fish_o.th2 != 0.00000012) fishg83y = fish_o.th2;
					if (fish_o.th3 != 0.00000012) fishg83z = fish_o.th3;
					if (fish_o.th4 != 0.00000012) fishg83a = fish_o.th4;
					if (fish_o.th5 != 0.00000012) fishg83b = fish_o.th5;
					if (fish_o.th6 != 0.00000012) fishg83c = fish_o.th6;
					if (fish_o.th7 != 0.00000012) fishg83d = fish_o.th7;
					if (fish_o.th8 != 0.00000012) fishg83e = fish_o.th8;
					if (fish_o.rr != 0.00000012) fishg83r = fish_o.rr;
					if (fish_o.pp != 0.00000012) fishg83p = fish_o.pp;
					if (fish_o.qq != 0.00000012) fishg83q = fish_o.qq;
					if (fish_o.ll != 0.00000012) fishg83l = fish_o.ll;
					fish_o.g01 = 0,fish_o.th3 = 0.00000012;//The first step is fast xyabcd positioning
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the first step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 2 Quickly locate to the R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the second step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83z;//The third step is cutting to point Z
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					usbcnc_G04(fishg83p);
					//No fourth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 5 Return to R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the fifth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					if (fishm2.g98 == 98)
					{
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zz;//Step 6 quickly return to the R plane
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the sixth step
					}
				}
				else if (fishm2.g81 == 83)//Éî¿××êÑ­»·
				{
					fishg83zz = fishm1.th3 - fishm1.cy03;
					if (fish_o.th1 != 0.00000012) fishg83x = fish_o.th1;
					if (fish_o.th2 != 0.00000012) fishg83y = fish_o.th2;
					if (fish_o.th3 != 0.00000012) fishg83z = fish_o.th3;
					if (fish_o.th4 != 0.00000012) fishg83a = fish_o.th4;
					if (fish_o.th5 != 0.00000012) fishg83b = fish_o.th5;
					if (fish_o.th6 != 0.00000012) fishg83c = fish_o.th6;
					if (fish_o.th7 != 0.00000012) fishg83d = fish_o.th7;
					if (fish_o.th8 != 0.00000012) fishg83e = fish_o.th8;
					if (fish_o.rr != 0.00000012) fishg83r = fish_o.rr;
					if (fish_o.pp != 0.00000012) fishg83p = fish_o.pp;
					if (fish_o.qq != 0.00000012) fishg83q = fish_o.qq;
					if (fish_o.ll != 0.00000012) fishg83l = fish_o.ll;
					fish_o.g01 = 0,fish_o.th3 = 0.00000012;//The first step is fast xyabcd positioning
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the first step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 2 Quickly locate to the R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the second step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					double fishg83zzz = fishg83r - fishg83q;
					while (fishg83zzz > fishg83z)
					{
						fishm1 = fishm2;
						fish_o.g01 = 1,fish_o.th3 = fishg83zzz;//third step  
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the third step
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83r;//third step 
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the third step
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zzz + 1.0;//third step 
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the third step
						fishg83zzz = fishg83zzz - fishg83q;
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83z;//third step 
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					usbcnc_G04(100);
					//No fourth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 5 Return to R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the fifth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					if (fishm2.g98 == 98)
					{
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zz;//Step 6 Return to the starting plane
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the sixth step
					}
				}
				else if (fishm2.g81 == 84)//Right-hand tapping cycle
				{
					fishg83zz = fishm1.th3 - fishm1.cy03;
					if (fish_o.th1 != 0.00000012) fishg83x = fish_o.th1;
					if (fish_o.th2 != 0.00000012) fishg83y = fish_o.th2;
					if (fish_o.th3 != 0.00000012) fishg83z = fish_o.th3;
					if (fish_o.th4 != 0.00000012) fishg83a = fish_o.th4;
					if (fish_o.th5 != 0.00000012) fishg83b = fish_o.th5;
					if (fish_o.th6 != 0.00000012) fishg83c = fish_o.th6;
					if (fish_o.th7 != 0.00000012) fishg83d = fish_o.th7;
					if (fish_o.th8 != 0.00000012) fishg83e = fish_o.th8;
					if (fish_o.rr != 0.00000012) fishg83r = fish_o.rr;
					if (fish_o.pp != 0.00000012) fishg83p = fish_o.pp;
					if (fish_o.qq != 0.00000012) fishg83q = fish_o.qq;
					if (fish_o.ll != 0.00000012) fishg83l = fish_o.ll;
					usbcnc_M03(fishm2.ss);
					fish_o.g01 = 0,fish_o.th3 = 0.00000012;//The first step is fast xyabcd positioning
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the first step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 2 Quickly locate to the R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the second step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83z;//The third step is cutting to point Z
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					usbcnc_M05();//the fourth step
					usbcnc_G04(800);
					usbcnc_M04(fishm2.ss);
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83r;//Step 5 Return to R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the fifth step
					usbcnc_M03(fishm2.ss);
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					if (fishm2.g98 == 98)
					{
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zz;//Step 6 quickly return to the R plane
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the sixth step
					}
				}
				else if (fishm2.g81 == 85)//Reaming cycle
				{
					fishg83zz = fishm1.th3 - fishm1.cy03;
					if (fish_o.th1 != 0.00000012) fishg83x = fish_o.th1;
					if (fish_o.th2 != 0.00000012) fishg83y = fish_o.th2;
					if (fish_o.th3 != 0.00000012) fishg83z = fish_o.th3;
					if (fish_o.th4 != 0.00000012) fishg83a = fish_o.th4;
					if (fish_o.th5 != 0.00000012) fishg83b = fish_o.th5;
					if (fish_o.th6 != 0.00000012) fishg83c = fish_o.th6;
					if (fish_o.th7 != 0.00000012) fishg83d = fish_o.th7;
					if (fish_o.th8 != 0.00000012) fishg83e = fish_o.th8;
					if (fish_o.rr != 0.00000012) fishg83r = fish_o.rr;
					if (fish_o.pp != 0.00000012) fishg83p = fish_o.pp;
					if (fish_o.qq != 0.00000012) fishg83q = fish_o.qq;
					if (fish_o.ll != 0.00000012) fishg83l = fish_o.ll;
					fish_o.g01 = 0,fish_o.th3 = 0.00000012;//The first step is fast xyabcd positioning
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the first step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 2 Quickly locate to the R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the second step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83z;//The third step is cutting to point Z
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					usbcnc_G04(100);
					//No fourth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83r;//Step 5 Return to R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the fifth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					if (fishm2.g98 == 98)
					{
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zz;//Step 6 quickly return to the R plane
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the sixth step
					}
				}
				else if (fishm2.g81 == 73)//High-speed deep hole drilling cycle
				{
					fishg83zz = fishm1.th3 - fishm1.cy03;
					if (fish_o.th1 != 0.00000012) fishg83x = fish_o.th1;
					if (fish_o.th2 != 0.00000012) fishg83y = fish_o.th2;
					if (fish_o.th3 != 0.00000012) fishg83z = fish_o.th3;
					if (fish_o.th4 != 0.00000012) fishg83a = fish_o.th4;
					if (fish_o.th5 != 0.00000012) fishg83b = fish_o.th5;
					if (fish_o.th6 != 0.00000012) fishg83c = fish_o.th6;
					if (fish_o.th7 != 0.00000012) fishg83d = fish_o.th7;
					if (fish_o.th8 != 0.00000012) fishg83e = fish_o.th8;
					if (fish_o.rr != 0.00000012) fishg83r = fish_o.rr;
					if (fish_o.pp != 0.00000012) fishg83p = fish_o.pp;
					if (fish_o.qq != 0.00000012) fishg83q = fish_o.qq;
					if (fish_o.ll != 0.00000012) fishg83l = fish_o.ll;
					fish_o.g01 = 0,fish_o.th3 = 0.00000012;//The first step is fast xyabcd positioning
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the first step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 2 Quickly locate to the R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the second step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					double fishg83zzz = fishg83r - fishg83q;
					while (fishg83zzz > fishg83z)
					{
						fishm1 = fishm2;
						fish_o.g01 = 1,fish_o.th3 = fishg83zzz;//third step  
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the third step
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zzz + 1.0;//third step 
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the third step
						fishg83zzz = fishg83zzz - fishg83q;
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83z;//third step 
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return 9999;//Move the third step
					usbcnc_G04(100);
					//No fourth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 5 Return to R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the fifth step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					if (fishm2.g98 == 98)
					{
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zz;//Step 6 Return to the starting plane
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the sixth step
					}
				}
				else if (fishm2.g81 == 74)//Left-hand tapping cycle
				{
					fishg83zz = fishm1.th3 - fishm1.cy03;
					if (fish_o.th1 != 0.00000012) fishg83x = fish_o.th1;
					if (fish_o.th2 != 0.00000012) fishg83y = fish_o.th2;
					if (fish_o.th3 != 0.00000012) fishg83z = fish_o.th3;
					if (fish_o.th4 != 0.00000012) fishg83a = fish_o.th4;
					if (fish_o.th5 != 0.00000012) fishg83b = fish_o.th5;
					if (fish_o.th6 != 0.00000012) fishg83c = fish_o.th6;
					if (fish_o.th7 != 0.00000012) fishg83d = fish_o.th7;
					if (fish_o.th8 != 0.00000012) fishg83e = fish_o.th8;
					if (fish_o.rr != 0.00000012) fishg83r = fish_o.rr;
					if (fish_o.pp != 0.00000012) fishg83p = fish_o.pp;
					if (fish_o.qq != 0.00000012) fishg83q = fish_o.qq;
					if (fish_o.ll != 0.00000012) fishg83l = fish_o.ll;
					usbcnc_M04(fishm2.ss);
					fish_o.g01 = 0,fish_o.th3 = 0.00000012;//The first step is fast xyabcd positioning
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the first step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 2 Quickly locate to the R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return 9999;//Move the second step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83z;//The third step is cutting to point Z
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					usbcnc_M05();//the fourth step
					usbcnc_G04(800);
					usbcnc_M03(fishm2.ss);
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83r;//Step 5 Return to R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the fifth step
					usbcnc_M04(fishm2.ss);
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					if (fishm2.g98 == 98)
					{
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zz;//Step 6 quickly return to the R plane
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the sixth step
					}
				}
				else if (fishm2.g81 == 76)//Boring cycle
				{
					fishg83zz = fishm1.th3 - fishm1.cy03;
					if (fish_o.th1 != 0.00000012) fishg83x = fish_o.th1;
					if (fish_o.th2 != 0.00000012) fishg83y = fish_o.th2;
					if (fish_o.th3 != 0.00000012) fishg83z = fish_o.th3;
					if (fish_o.th4 != 0.00000012) fishg83a = fish_o.th4;
					if (fish_o.th5 != 0.00000012) fishg83b = fish_o.th5;
					if (fish_o.th6 != 0.00000012) fishg83c = fish_o.th6;
					if (fish_o.th7 != 0.00000012) fishg83d = fish_o.th7;
					if (fish_o.th8 != 0.00000012) fishg83e = fish_o.th8;
					if (fish_o.rr != 0.00000012) fishg83r = fish_o.rr;
					if (fish_o.pp != 0.00000012) fishg83p = fish_o.pp;
					if (fish_o.qq != 0.00000012) fishg83q = fish_o.qq;
					if (fish_o.ll != 0.00000012) fishg83l = fish_o.ll;
					fish_o.g01 = 0,fish_o.th3 = 0.00000012;//The first step is fast xyabcd positioning
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the first step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 2 Quickly locate to the R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the second step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th3 = fishg83z;//The third step is cutting to point Z
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					usbcnc_M05();//the fourth step
					usbcnc_G04(800);
					usbcnc_M77();//Spindle orientation
					usbcnc_G04(800);
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.th1 = fishg83x + fishg83q;//Step 4 give the knife
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th3 = fishg83r;//Step 5 Return to R plane
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the fifth step
					fishm1 = fishm2;
					fish_o.g01 = 0,fish_o.th1 = fishg83x;//Step 4 give the knife
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move the third step
					usbcnc_M87();//Cancel spindle orientation
					usbcnc_M03(fishm2.ss);
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					if (fishm2.g98 == 98)
					{
						fishm1 = fishm2;
						fish_o.g01 = 0,fish_o.th3 = fishg83zz;//Step 6 quickly return to the R plane
						fishm2 = usbcncLA(fishm1, fish_o);
						fish_goto = fishm2.l1;
						if (usbcncTOTO() != 0) return fish_errer;//Move the sixth step
					}
				}
				else
				{
					fish_goto = fishm2.l1;
					if (fish_jsd && fish_ii + 1 < fish_kk)//Turn on G64 pre-reading acceleration, the next segment of vector is required
					{
						fishm3 = usbcncLA(usbcncGOGO(fishm2), fishg[fish_ii + 1]);//Calculate length, vector
						if (fishm3.a1 < fishq[0].q16 && !fish1058 && fishm2.g04 != 4 && fishm2.mm != 0 && (!fish1057 && fishm2.mm != 1))//Angle satisfies and non-single-segment single-segment processing non-G04 non-M00 non-M01+selective stop
						{
							fish_goto = fish_goto + fishm3.l1;//Add the next length
							if (fishm3.a1 < fishq[0].q17)
								fishq[0].q18 = fishm3.ff * fish_jgbl;//Full speed
							else
								fishq[0].q18 = fishm3.ff * fish_jgbl * (fishq[0].q16 - fishm3.a1) / (fishq[0].q16 - fishq[0].q17);//Next speed optimization
							fishm4 = usbcncGOGO(fishm3);
							unsigned int gss = fish_ii + 2;
							if (gss < fish_kk)//Make sure the program is not over
							{
								do
								{
									fishm5 = usbcncLA(fishm4, fishg[gss]);//Calculate length, vector

									fish_goto = fish_goto + fishm4.l1;
									fishm4 = usbcncGOGO(fishm5);
									gss++;
								} while (fish_goto - fishm2.l1 < 120.0 && fishm5.a1 < fishq[0].q16 && gss < fish_kk && fishm4.g04 != 4 && fishm4.mm != 0 && (!fish1057 && fishm4.mm != 1));
							}
						}
						else fishq[0].q18 = 1.0;
					}
					if (usbcncTOTO() != 0) return fish_errer;//Execute processing, error return
				}
				if (fishm2.mm == 5) usbcnc_M05();
				else if (fishm2.mm == 7) usbcnc_M07();
				else if (fishm2.mm == 8) usbcnc_M08();
				else if (fishm2.mm == 9) usbcnc_M09();
				else if (fishm2.mm == 75) usbcnc_M75();
				else if (fishm2.mm == 76) usbcnc_M76();
				else if (fishm2.mm == 77) usbcnc_M77();
				else if (fishm2.mm == 78) usbcnc_M78();
				else if (fishm2.mm == 85) usbcnc_M85();
				else if (fishm2.mm == 86) usbcnc_M86();
				else if (fishm2.mm == 87) usbcnc_M87();
				else if (fishm2.mm == 88) usbcnc_M88();
				else if (fishm2.mm == 129) usbcnc_M129();
				else if (fishm2.mm == 61) usbcnc_M61();
				else if (fishm2.mm == 6 && fish_tt != fishm2.tt)//Automatic tool change
				{
					usbcnc_M05();//Spindle stop
					usbcnc_G04(500);
					usbcnc_M77();//Spindle orientation
					usbcnc_G04(1000);
					fishm1 = fishm2;
					fish_o.g01 = 0;
					if (tool_xC[fish_tt] == 0.00000012) fish_o.th1 = 0.00000012;
					else fish_o.th1 = tool_xC[fish_tt] - fishm2.cy01;
					if (tool_yC[fish_tt] == 0.00000012) fish_o.th2 = 0.00000012;
					else fish_o.th2 = tool_yC[fish_tt] - fishm2.cy02;
					if (tool_zC[fish_tt] == 0.00000012) fish_o.th3 = 0.00000012;
					else fish_o.th3 = tool_zC[fish_tt] - fishm2.cy03;
					if (tool_aC[fish_tt] == 0.00000012) fish_o.th4 = 0.00000012;
					else fish_o.th4 = tool_aC[fish_tt] - fishm2.cy04;
					if (tool_bC[fish_tt] == 0.00000012) fish_o.th5 = 0.00000012;
					else fish_o.th5 = tool_bC[fish_tt] - fishm2.cy05;
					if (tool_cC[fish_tt] == 0.00000012) fish_o.th6 = 0.00000012;
					else fish_o.th6 = tool_cC[fish_tt] - fishm2.cy06;
					if (tool_uC[fish_tt] == 0.00000012) fish_o.th7 = 0.00000012;
					else fish_o.th7 = tool_uC[fish_tt] - fishm2.cy07;
					if (tool_vC[fish_tt] == 0.00000012) fish_o.th8 = 0.00000012;
					else fish_o.th8 = tool_vC[fish_tt] - fishm2.cy08;
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move to the point of entry and exit
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.ff = 1000.0;
					if (tool_xB[fish_tt] == 0.00000012) fish_o.th1 = 0.00000012;
					else fish_o.th1 = tool_xB[fish_tt] - fishm2.cy01;
					if (tool_yB[fish_tt] == 0.00000012) fish_o.th2 = 0.00000012;
					else fish_o.th2 = tool_yB[fish_tt] - fishm2.cy02;
					if (tool_zB[fish_tt] == 0.00000012) fish_o.th3 = 0.00000012;
					else fish_o.th3 = tool_zB[fish_tt] - fishm2.cy03;
					if (tool_aB[fish_tt] == 0.00000012) fish_o.th4 = 0.00000012;
					else fish_o.th4 = tool_aB[fish_tt] - fishm2.cy04;
					if (tool_bB[fish_tt] == 0.00000012) fish_o.th5 = 0.00000012;
					else fish_o.th5 = tool_bB[fish_tt] - fishm2.cy05;
					if (tool_cB[fish_tt] == 0.00000012) fish_o.th6 = 0.00000012;
					else fish_o.th6 = tool_cB[fish_tt] - fishm2.cy06;
					if (tool_uB[fish_tt] == 0.00000012) fish_o.th7 = 0.00000012;
					else fish_o.th7 = tool_uB[fish_tt] - fishm2.cy07;
					if (tool_vB[fish_tt] == 0.00000012) fish_o.th8 = 0.00000012;
					else fish_o.th8 = tool_vB[fish_tt] - fishm2.cy08;

					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move to the point where the knife is placed
					usbcnc_M78();//ËÉµ¶
					usbcnc_G04(1000);
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.ff = 1000.0;
					if (tool_xA[fish_tt] == 0.00000012) fish_o.th1 = 0.00000012;
					else fish_o.th1 = tool_xA[fish_tt] - fishm2.cy01;
					if (tool_yA[fish_tt] == 0.00000012) fish_o.th2 = 0.00000012;
					else fish_o.th2 = tool_yA[fish_tt] - fishm2.cy02;
					if (tool_zA[fish_tt] == 0.00000012) fish_o.th3 = 0.00000012;
					else fish_o.th3 = tool_zA[fish_tt] - fishm2.cy03;
					if (tool_aA[fish_tt] == 0.00000012) fish_o.th4 = 0.00000012;
					else fish_o.th4 = tool_aA[fish_tt] - fishm2.cy04;
					if (tool_bA[fish_tt] == 0.00000012) fish_o.th5 = 0.00000012;
					else fish_o.th5 = tool_bA[fish_tt] - fishm2.cy05;
					if (tool_cA[fish_tt] == 0.00000012) fish_o.th6 = 0.00000012;
					else fish_o.th6 = tool_cA[fish_tt] - fishm2.cy06;
					if (tool_uA[fish_tt] == 0.00000012) fish_o.th7 = 0.00000012;
					else fish_o.th7 = tool_uA[fish_tt] - fishm2.cy07;
					if (tool_vA[fish_tt] == 0.00000012) fish_o.th8 = 0.00000012;
					else fish_o.th8 = tool_vA[fish_tt] - fishm2.cy08;
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move to the position of the feed point
					fish_tt = fishm2.tt;
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 0;
					if (tool_xA[fish_tt] == 0.00000012) fish_o.th1 = 0.00000012;
					else fish_o.th1 = tool_xA[fish_tt] - fishm2.cy01;
					if (tool_yA[fish_tt] == 0.00000012) fish_o.th2 = 0.00000012;
					else fish_o.th2 = tool_yA[fish_tt] - fishm2.cy02;
					if (tool_zA[fish_tt] == 0.00000012) fish_o.th3 = 0.00000012;
					else fish_o.th3 = tool_zA[fish_tt] - fishm2.cy03;
					if (tool_aA[fish_tt] == 0.00000012) fish_o.th4 = 0.00000012;
					else fish_o.th4 = tool_aA[fish_tt] - fishm2.cy04;
					if (tool_bA[fish_tt] == 0.00000012) fish_o.th5 = 0.00000012;
					else fish_o.th5 = tool_bA[fish_tt] - fishm2.cy05;
					if (tool_cA[fish_tt] == 0.00000012) fish_o.th6 = 0.00000012;
					else fish_o.th6 = tool_cA[fish_tt] - fishm2.cy06;
					if (tool_uA[fish_tt] == 0.00000012) fish_o.th7 = 0.00000012;
					else fish_o.th7 = tool_uA[fish_tt] - fishm2.cy07;
					if (tool_vA[fish_tt] == 0.00000012) fish_o.th8 = 0.00000012;
					else fish_o.th8 = tool_vA[fish_tt] - fishm2.cy08;
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move to the position of the feed point
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.ff = 1000.0;
					if (tool_xB[fish_tt] == 0.00000012) fish_o.th1 = 0.00000012;
					else fish_o.th1 = tool_xB[fish_tt] - fishm2.cy01;
					if (tool_yB[fish_tt] == 0.00000012) fish_o.th2 = 0.00000012;
					else fish_o.th2 = tool_yB[fish_tt] - fishm2.cy02;
					if (tool_zB[fish_tt] == 0.00000012) fish_o.th3 = 0.00000012;
					else fish_o.th3 = tool_zB[fish_tt] - fishm2.cy03;
					if (tool_aB[fish_tt] == 0.00000012) fish_o.th4 = 0.00000012;
					else fish_o.th4 = tool_aB[fish_tt] - fishm2.cy04;
					if (tool_bB[fish_tt] == 0.00000012) fish_o.th5 = 0.00000012;
					else fish_o.th5 = tool_bB[fish_tt] - fishm2.cy05;
					if (tool_cB[fish_tt] == 0.00000012) fish_o.th6 = 0.00000012;
					else fish_o.th6 = tool_cB[fish_tt] - fishm2.cy06;
					if (tool_uB[fish_tt] == 0.00000012) fish_o.th7 = 0.00000012;
					else fish_o.th7 = tool_uB[fish_tt] - fishm2.cy07;
					if (tool_vB[fish_tt] == 0.00000012) fish_o.th8 = 0.00000012;
					else fish_o.th8 = tool_vB[fish_tt] - fishm2.cy08;
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move to the tool change point
					usbcnc_M88();//Clamp the tool
					if (fish1058)//Single stage execution
					{
						fish1053 = FALSE;//Program pause
						while (!fish1053 && fish1050 == 0)
						{
							if (fish1054) return 9999;
							usbcnc_G04(100);
						}
					}
					usbcnc_G04(1000);
					fishm1 = fishm2;
					fish_o.g01 = 1,fish_o.ff = 1000.0;
					if (tool_xC[fish_tt] == 0.00000012) fish_o.th1 = 0.00000012;
					else fish_o.th1 = tool_xC[fish_tt] - fishm2.cy01;
					if (tool_yC[fish_tt] == 0.00000012) fish_o.th2 = 0.00000012;
					else fish_o.th2 = tool_yC[fish_tt] - fishm2.cy02;
					if (tool_zC[fish_tt] == 0.00000012) fish_o.th3 = 0.00000012;
					else fish_o.th3 = tool_zC[fish_tt] - fishm2.cy03;
					if (tool_aC[fish_tt] == 0.00000012) fish_o.th4 = 0.00000012;
					else fish_o.th4 = tool_aC[fish_tt] - fishm2.cy04;
					if (tool_bC[fish_tt] == 0.00000012) fish_o.th5 = 0.00000012;
					else fish_o.th5 = tool_bC[fish_tt] - fishm2.cy05;
					if (tool_cC[fish_tt] == 0.00000012) fish_o.th6 = 0.00000012;
					else fish_o.th6 = tool_cC[fish_tt] - fishm2.cy06;
					if (tool_uC[fish_tt] == 0.00000012) fish_o.th7 = 0.00000012;
					else fish_o.th7 = tool_uC[fish_tt] - fishm2.cy07;
					if (tool_vC[fish_tt] == 0.00000012) fish_o.th8 = 0.00000012;
					else fish_o.th8 = tool_vC[fish_tt] - fishm2.cy08;
					fishm2 = usbcncLA(fishm1, fish_o);
					fish_goto = fishm2.l1;
					if (usbcncTOTO() != 0) return fish_errer;//Move to the exit point
					usbcnc_M87();//Untargeted
				}
				if (fishm2.g04 == 4) usbcnc_G04(fishm2.pp);
				if (fishm2.mm == 00) usbcnc_M00();
				else if (fishm2.mm == 30)
				{
					if (fish_o1 > 0) fish_o1--;
					fish1053 = FALSE;
					fish1052 = FALSE;
					fish_ii = 0;
					fishm1 = fishm2;
					EnableWindow(GetDlgItem(hWnd, 1000), TRUE);
					EnableWindow(GetDlgItem(hWnd, 1001), TRUE);
					EnableWindow(GetDlgItem(hWnd, 1002), TRUE);
					EnableWindow(GetDlgItem(hWnd, 1003), TRUE);
					EnableWindow(GetDlgItem(hWnd, 1004), TRUE);
					EnableWindow(GetDlgItem(hWnd, 1005), TRUE);
					EnableWindow(GetDlgItem(hWnd, 1006), TRUE);
					return 9999;
				}
			}
			return 0;
		}

	}
}

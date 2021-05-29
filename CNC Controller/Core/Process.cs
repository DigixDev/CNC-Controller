using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNC_Controller.Models;
using static CNC_Controller.Core.Global;
namespace CNC_Controller.Core
{
    public class Process
    {
		static USB4 usbcncRTCP(USB3 fishm7)//Calculate RTCP coordinates
		{
			double pti01, pti02, pti03, pti04, pti05, pti06, pti07, pti08, pti09, pti10, pti11, pti12, pti13, pti14, pti15, pti16, pti17, pti18;
			USB4 fishm8=new USB4();
			if (fishm7.TCPM && (fishq[0].q10 == 7546 || fishq[0].q10 == 7556 || fishq[0].q10 == 7545 || fishq[0].q10 == 7554))//Double turntable
			{
				pti04 = Math.Cos(fishm7.th5 *  Math.PI / 180.0);
				pti05 = Math.Sin(fishm7.th5 *  Math.PI / 180.0);
				pti06 = (fishq[5].q7 * fishm7.th1 + fishq[5].q8 * fishm7.th2 + fishq[5].q9 * fishm7.th3) * (1.0 - Math.Cos(fishm7.th5 *  Math.PI / 180.0));
				pti01 = fishm7.th1 * pti04 + (fishq[5].q9 * fishm7.th2 - fishq[5].q8 * fishm7.th3) * pti05 + fishq[5].q7 * pti06;
				pti02 = fishm7.th2 * pti04 + (fishq[5].q7 * fishm7.th3 - fishq[5].q9 * fishm7.th1) * pti05 + fishq[5].q8 * pti06;
				pti03 = fishm7.th3 * pti04 + (fishq[5].q8 * fishm7.th1 - fishq[5].q7 * fishm7.th2) * pti05 + fishq[5].q9 * pti06;
				pti07 = Math.Cos(fishm7.th4 *  Math.PI / 180.0);
				pti08 = Math.Sin(fishm7.th4 *  Math.PI / 180.0);
				pti09 = (fishq[4].q7 * (pti01 + fishq[4].q4) + fishq[4].q8 * (pti02 + fishq[4].q5) + fishq[4].q9 * (pti03 + fishq[4].q6)) * (1.0 - Math.Cos(fishm7.th4 *  Math.PI / 180.0));
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
				pti04 = Math.Cos(-fishm7.th5 *  Math.PI / 180.0);
				pti05 = Math.Sin(-fishm7.th5 *  Math.PI / 180.0);
				pti06 = (fishq[5].q7 * fishq[5].q4 + fishq[5].q8 * fishq[5].q5 + fishq[5].q9 * (fishq[5].q6 - fishm7.h0)) * (1.0 - Math.Cos(-fishm7.th5 *  Math.PI / 180.0));
				pti01 = fishq[5].q4 * pti04 + (fishq[5].q9 * fishq[5].q5 - fishq[5].q8 * (fishq[5].q6 - fishm7.h0)) * pti05 + fishq[5].q7 * pti06;
				pti02 = fishq[5].q5 * pti04 + (fishq[5].q7 * (fishq[5].q6 - fishm7.h0) - fishq[5].q9 * fishq[5].q4) * pti05 + fishq[5].q8 * pti06;
				pti03 = (fishq[5].q6 - fishm7.h0) * pti04 + (fishq[5].q8 * fishq[5].q4 - fishq[5].q7 * fishq[5].q5) * pti05 + fishq[5].q9 * pti06;
				pti07 = Math.Cos(-fishm7.th4 *  Math.PI / 180.0);
				pti08 = Math.Sin(-fishm7.th4 *  Math.PI / 180.0);
				pti09 = (fishq[4].q7 * (fishq[4].q4 + pti01) + fishq[4].q8 * (fishq[4].q5 + pti02) + fishq[4].q9 * (fishq[4].q6 + pti03)) * (1 - Math.Cos(-fishm7.th4 *  Math.PI / 180.0));
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
				pti04 = Math.Cos(-fishm7.th4 *  Math.PI / 180.0);
				pti05 = Math.Sin(-fishm7.th4 *  Math.PI / 180.0);
				pti06 = (fishq[4].q7 * fishq[4].q4 + fishq[4].q8 * fishq[4].q5 + fishq[4].q9 * (fishq[4].q6 - fishm7.h0)) * (1.0 - Math.Cos(-fishm7.th4 *  Math.PI / 180.0));
				pti01 = fishq[4].q4 * pti04 + (fishq[4].q9 * fishq[4].q5 - fishq[4].q8 * (fishq[4].q6 - fishm7.h0)) * pti05 + fishq[4].q7 * pti06;
				pti02 = fishq[4].q5 * pti04 + (fishq[4].q7 * (fishq[4].q6 - fishm7.h0) - fishq[4].q9 * fishq[4].q4) * pti05 + fishq[4].q8 * pti06;
				pti03 = (fishq[4].q6 - fishm7.h0) * pti04 + (fishq[4].q8 * fishq[4].q4 - fishq[4].q7 * fishq[4].q5) * pti05 + fishq[4].q9 * pti06;
				pti07 = Math.Cos(fishm7.th5 *  Math.PI / 180.0);
				pti08 = Math.Sin(fishm7.th5 *  Math.PI / 180.0);
				pti09 = (fishq[5].q7 * fishm7.th1 + fishq[5].q8 * fishm7.th2 + fishq[5].q9 * fishm7.th3) * (1.0 - Math.Cos(fishm7.th5 *  Math.PI / 180.0));
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
						pti02 = 90.0 + Math.Asin(fishm7.th2 / pti01) * 180.0 /  Math.PI;
					else if (fishm7.th1 < 0)
						pti02 = -90.0 - Math.Asin(fishm7.th2 / pti01) * 180.0 /  Math.PI;
					else if (fishm7.th1 == 0 && fishm7.th2 > 0)
						pti02 = 180.0;
					else pti02 = 0;
					pti03 = Math.Acos((pti01 * pti01 + fishq[2].q5 * fishq[2].q5 - fishq[1].q5 * fishq[1].q5) / (2.0 * pti01 * fishq[2].q5)) * 180.0 /  Math.PI;
					fishm8.th1 = pti02 + pti03;
					fishm8.th2 = 180.0 - Math.Acos((fishq[1].q5 * fishq[1].q5 + fishq[2].q5 * fishq[2].q5 - pti01 * pti01) / (2.0 * fishq[1].q5 * fishq[2].q5)) * 180.0 /  Math.PI;
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
					pti01 = fishq[5].q6 * Math.Sin(fishm7.th5 *  Math.PI / 180.0) + fishm7.th1;
					pti02 = fishm7.th2;
					pti03 = fishq[5].q6 * Math.Cos(fishm7.th5 *  Math.PI / 180.0) + fishm7.th3;
				}
				else if (fishm7.th5 == 0.0)//A axis rotation
				{
					pti01 = fishm7.th1;
					pti02 = -fishq[5].q6 * Math.Sin(fishm7.th4 *  Math.PI / 180.0) + fishm7.th2;
					pti03 = fishq[5].q6 * Math.Cos(fishm7.th4 *  Math.PI / 180.0) + fishm7.th3;
				}
				else
				{
					pti01 = fishq[5].q6 * Math.Sin(Math.Asin(Math.Cos(Math.Atan(Math.Cos(fishm7.th5 *  Math.PI / 180.0) * Math.Tan(fishm7.th4 *  Math.PI / 180.0))) * Math.Sin(fishm7.th5 *  Math.PI / 180.0))) + fishm7.th1;//The X coordinate at the B axis rotates around the B axis first
					pti02 = -fishq[5].q6 * Math.Sin(Math.Atan(Math.Cos(fishm7.th5 *  Math.PI / 180.0) * Math.Tan(fishm7.th4 *  Math.PI / 180.0))) + fishm7.th2;//The y coordinate on the B axis rotates around the B axis first
					pti03 = fishq[5].q6 * Math.Cos(Math.Atan(Math.Cos(fishm7.th5 *  Math.PI / 180.0) * Math.Tan(fishm7.th4 *  Math.PI / 180.0))) * Math.Cos(fishm7.th5 *  Math.PI / 180.0) + fishm7.th3;//The z coordinate at the B axis rotates around the B axis first
				}
				if (Math.Sqrt((Math.Sqrt(pti01 * pti01 + pti02 * pti02) - fishq[1].q5) * (Math.Sqrt(pti01 * pti01 + pti02 * pti02) - fishq[1].q5) + (pti03 - fishq[1].q6) * (pti03 - fishq[1].q6)) < Math.Sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5) + fishq[2].q6 - 2)//Anti-overtravel, 2mm distance
				{
					if (pti01 == 0 && pti02 > 0)//Y Axis
						fishm8.th1 = 0;
					else if (pti01 > 0 && pti02 > 0)//Quadrant 1
						fishm8.th1 = Math.Atan(pti01 / pti02) * 180.0 /  Math.PI;
					else if (pti01 > 0 && pti02 == 0)//X Axis
						fishm8.th1 = 90.0;
					else if (pti01 > 0 && pti02 < 0)//Quadrant 4
						fishm8.th1 = 90.0 - Math.Atan(pti02 / pti01) * 180.0 /  Math.PI;
					else if (pti01 < 0 && pti02 > 0)//Quadrant 2
						fishm8.th1 = Math.Atan(pti01 / pti02) * 180.0 /  Math.PI;
					else if (pti01 < 0 && pti02 == 0)//-X Axis
						fishm8.th1 = -90.0;
					else if (pti01 < 0 && pti02 < 0)//Quadrant 3
						fishm8.th1 = -90.0 - Math.Atan(pti02 / pti01) * 180.0 /  Math.PI;
					else if (pti01 == 0 && pti02 < 0)//-Y Axis
						fishm8.th1 = 180.0;

					fishm8.th6 = fishm7.th6 - fishm8.th1;//TCPM C axis
					pti07 = Math.Sqrt(pti01 * pti01 + pti02 * pti02);//Y-axis coordinate after X-axis rotation (polar coordinate of end point)
					pti08 = Math.Sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5);//Length of right-angle member
					pti09 = 90 - Math.Asin(fishq[3].q6 / pti08) * 180.0 /  Math.PI;//Angle 3
					pti10 = Math.Sqrt((pti07 - fishq[1].q5) * (pti07 - fishq[1].q5) + (pti03 - fishq[1].q6) * (pti03 - fishq[1].q6));//Length of connecting rod
					pti11 = Math.Asin((pti03 - fishq[1].q6) / pti10) * 180.0 /  Math.PI;//1 angle
					pti12 = Math.Acos((fishq[2].q6 * fishq[2].q6 + pti10 * pti10 - pti08 * pti08) / (2 * fishq[2].q6 * pti10)) * 180.0 /  Math.PI;//2 angle
					fishm8.th2 = 90.0 - pti11 - pti12;//y-axis angle
					fishm8.th3 = Math.Acos((fishq[2].q6 * fishq[2].q6 + pti08 * pti08 - pti10 * pti10) / (2 * fishq[2].q6 * pti08)) * 180.0 /  Math.PI - 180.0 + pti09;//Z axis angle
					pti04 = (fishq[1].q5 + fishq[2].q6 * Math.Sin(fishm8.th2 *  Math.PI / 180.0) + fishq[3].q6 * Math.Sin((-fishm8.th3 + fishm8.th2) *  Math.PI / 180.0)) * Math.Sin(fishm8.th1 *  Math.PI / 180.0);//X coordinate at right angle of A axis
					pti05 = (fishq[1].q5 + fishq[2].q6 * Math.Sin(fishm8.th2 *  Math.PI / 180.0) + fishq[3].q6 * Math.Sin((-fishm8.th3 + fishm8.th2) *  Math.PI / 180.0)) * Math.Cos(fishm8.th1 *  Math.PI / 180.0);//The y coordinate at right angles to the A axis
					pti06 = fishq[1].q6 + fishq[2].q6 * Math.Cos(fishm8.th2 *  Math.PI / 180.0) + fishq[3].q6 * Math.Cos((-fishm8.th3 + fishm8.th2) *  Math.PI / 180.0);//Z coordinate at right angles to the A axis
					pti13 = Math.Sqrt((pti04 - fishm7.th1) * (pti04 - fishm7.th1) + (pti05 - fishm7.th2) * (pti05 - fishm7.th2) + (pti06 - fishm7.th3) * (pti06 - fishm7.th3));//Calculate the distance from the tip of the tool at a right angle to the A axis
					if (fishm7.th4 <= 90.0 + fishm8.th3 - fishm8.th2)
						fishm8.th5 = Math.Acos((fishq[5].q6 * fishq[5].q6 + fishq[3].q5 * fishq[3].q5 - pti13 * pti13) / (2 * fishq[3].q5 * fishq[5].q6)) * 180.0 /  Math.PI - 90.0;
					else
						fishm8.th5 = 270.0 - Math.Acos((fishq[5].q6 * fishq[5].q6 + fishq[3].q5 * fishq[3].q5 - pti13 * pti13) / (2 * fishq[3].q5 * fishq[5].q6)) * 180.0 /  Math.PI;
					pti15 = fishm8.th2 - fishm8.th3 - fishm8.th5;
					pti16 = pti01 - fishq[5].q6 * Math.Sin(pti15 *  Math.PI / 180.0) * Math.Sin(fishm8.th1 *  Math.PI / 180.0);//X coordinate of virtual point
					pti17 = pti02 - fishq[5].q6 * Math.Sin(pti15 *  Math.PI / 180.0) * Math.Cos(fishm8.th1 *  Math.PI / 180.0);//Y coordinate of virtual point
					pti18 = pti03 - fishq[5].q6 * Math.Cos(pti15 *  Math.PI / 180.0);//Z coordinate at virtual point
					pti14 = Math.Sqrt((pti16 - fishm7.th1) * (pti16 - fishm7.th1) + (pti17 - fishm7.th2) * (pti17 - fishm7.th2) + (pti18 - fishm7.th3) * (pti18 - fishm7.th3));
					if (90.0 - Math.Atan(fishm7.th1 / fishm7.th2) * 180.0 /  Math.PI >= 90.0 - Math.Atan(pti01 / pti02) * 180.0 /  Math.PI)
						fishm8.th4 = 2.0 * Math.Asin(pti14 / 2.0 / fishq[5].q6 / Math.Cos(fishm8.th5 *  Math.PI / 180.0)) * 180.0 /  Math.PI;
					else
						fishm8.th4 = -2.0 * Math.Asin(pti14 / 2.0 / fishq[5].q6 / Math.Cos(fishm8.th5 *  Math.PI / 180.0)) * 180.0 /  Math.PI;
				}
				else fish_errer = 117;
				fishm8.th7 = fishm7.th7;
				fishm8.th8 = fishm7.th8;
			}
			else if (fishm7.TCPM && fishq[0].q10 == 7778)
			{
				pti07 = fishq[6].q4 * Math.Cos(-fishm7.th6 *  Math.PI / 180.0) + fishq[6].q5 * Math.Sin(-fishm7.th6 *  Math.PI / 180.0);
				pti08 = fishq[6].q5 * Math.Cos(-fishm7.th6 *  Math.PI / 180.0) - fishq[6].q4 * Math.Sin(-fishm7.th6 *  Math.PI / 180.0);
				pti09 = fishq[6].q6 - fishm7.h0;
				pti13 = pti07 * Math.Cos(-fishm7.th5 *  Math.PI / 180.0) - pti09 * Math.Sin(-fishm7.th5 *  Math.PI / 180.0);
				pti14 = pti08;
				pti15 = pti09 * Math.Cos(-fishm7.th5 *  Math.PI / 180.0) + pti07 * Math.Sin(-fishm7.th5 *  Math.PI / 180.0);
				pti01 = fishm7.th1 - pti13;
				pti02 = fishm7.th2 - (pti14 * Math.Cos(-fishm7.th4 *  Math.PI / 180.0) + pti15 * Math.Sin(-fishm7.th4 *  Math.PI / 180.0));
				pti03 = fishm7.th3 - (pti15 * Math.Cos(-fishm7.th4 *  Math.PI / 180.0) - pti14 * Math.Sin(-fishm7.th4 *  Math.PI / 180.0));//Calculate the coordinates of the AB axis intersection point

				if (Math.Sqrt((Math.Sqrt(pti01 * pti01 + pti02 * pti02) - fishq[1].q5) * (Math.Sqrt(pti01 * pti01 + pti02 * pti02) - fishq[1].q5) + (pti03 - fishq[1].q6) * (pti03 - fishq[1].q6)) < Math.Sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5) + fishq[2].q6 - 2)//防超程，2mm距离
				{
					if (pti01 == 0 && pti02 > 0)//Y Axis
						fishm8.th1 = 0;
					else if (pti01 > 0 && pti02 > 0)//Quadrant 1
						fishm8.th1 = Math.Atan(pti01 / pti02) * 180.0 /  Math.PI;
					else if (pti01 > 0 && pti02 == 0)//X Axis
						fishm8.th1 = 90.0;
					else if (pti01 > 0 && pti02 < 0)//Quadrant 4
						fishm8.th1 = 90.0 - Math.Atan(pti02 / pti01) * 180.0 /  Math.PI;
					else if (pti01 < 0 && pti02 > 0)//Quadrant 2
						fishm8.th1 = Math.Atan(pti01 / pti02) * 180.0 /  Math.PI;
					else if (pti01 < 0 && pti02 == 0)//-X Axis
						fishm8.th1 = -90.0;
					else if (pti01 < 0 && pti02 < 0)//Quadrant 3
						fishm8.th1 = -90.0 - Math.Atan(pti02 / pti01) * 180.0 /  Math.PI;
					else if (pti01 == 0 && pti02 < 0)//-Y Axis
						fishm8.th1 = 180.0;

					pti07 = Math.Sqrt(pti01 * pti01 + pti02 * pti02);//Y-axis coordinate after X-axis rotation (polar coordinate of end point)
					pti08 = Math.Sqrt(fishq[3].q6 * fishq[3].q6 + fishq[3].q5 * fishq[3].q5);//Right angle member length
					pti09 = 90 - Math.Asin(fishq[3].q6 / pti08) * 180.0 /  Math.PI;//Angle 3
					pti10 = Math.Sqrt((pti07 - fishq[1].q5) * (pti07 - fishq[1].q5) + (pti03 - fishq[1].q6) * (pti03 - fishq[1].q6));//Length of connecting rod
					pti11 = Math.Asin((pti03 - fishq[1].q6) / pti10) * 180.0 /  Math.PI;//1 angle
					pti12 = Math.Acos((fishq[2].q6 * fishq[2].q6 + pti10 * pti10 - pti08 * pti08) / (2 * fishq[2].q6 * pti10)) * 180.0 /  Math.PI;//2 angle
					fishm8.th2 = 90.0 - pti11 - pti12;//y-axis angle
					fishm8.th3 = Math.Acos((fishq[2].q6 * fishq[2].q6 + pti08 * pti08 - pti10 * pti10) / (2 * fishq[2].q6 * pti08)) * 180.0 /  Math.PI - 180.0 + pti09;//Z axis angle
					pti04 = (fishq[1].q5 + fishq[2].q6 * Math.Sin(fishm8.th2 *  Math.PI / 180.0) + fishq[3].q6 * Math.Sin((-fishm8.th3 + fishm8.th2) *  Math.PI / 180.0)) * Math.Sin(fishm8.th1 *  Math.PI / 180.0);//X coordinate at right angle of A axis
					pti05 = (fishq[1].q5 + fishq[2].q6 * Math.Sin(fishm8.th2 *  Math.PI / 180.0) + fishq[3].q6 * Math.Sin((-fishm8.th3 + fishm8.th2) *  Math.PI / 180.0)) * Math.Cos(fishm8.th1 *  Math.PI / 180.0);//The y coordinate at right angles to the A axis
					pti06 = fishq[1].q6 + fishq[2].q6 * Math.Cos(fishm8.th2 *  Math.PI / 180.0) + fishq[3].q6 * Math.Cos((-fishm8.th3 + fishm8.th2) *  Math.PI / 180.0);//Z coordinate at right angles to the A axis
					pti10 = fishq[6].q4 * Math.Cos(-fishm7.th6 *  Math.PI / 180.0) + fishq[6].q5 * Math.Sin(-fishm7.th6 *  Math.PI / 180.0);
					pti11 = fishq[6].q5 * Math.Cos(-fishm7.th6 *  Math.PI / 180.0) - fishq[6].q4 * Math.Sin(-fishm7.th6 *  Math.PI / 180.0);
					pti12 = 0;
					pti13 = pti10 * Math.Cos(-fishm7.th5 *  Math.PI / 180.0) - pti12 * Math.Sin(-fishm7.th5 *  Math.PI / 180.0);
					pti14 = pti11;
					pti15 = pti12 * Math.Cos(-fishm7.th5 *  Math.PI / 180.0) + pti10 * Math.Sin(-fishm7.th5 *  Math.PI / 180.0);
					pti07 = fishm7.th1 - pti13;//Calculate the position of Z0 point
					pti08 = fishm7.th2 - (pti14 * Math.Cos(-fishm7.th4 *  Math.PI / 180.0) + pti15 * Math.Sin(-fishm7.th4 *  Math.PI / 180.0));//Calculate the position of Z0 point
					pti09 = fishm7.th3 - (pti15 * Math.Cos(-fishm7.th4 *  Math.PI / 180.0) - pti14 * Math.Sin(-fishm7.th4 *  Math.PI / 180.0));//Calculate the position of Z0 point
					pti13 = Math.Sqrt((pti04 - pti07) * (pti04 - pti07) + (pti05 - pti08) * (pti05 - pti08) + (pti06 - pti09) * (pti06 - pti09));//Calculate the distance between the right angle of the A axis and the tip of the tool
					if (fishm7.th4 <= 90.0 + fishm8.th3 - fishm8.th2)//Calculate fifth axis coordinates
						fishm8.th5 = Math.Acos(((fishm7.h0 - fishq[6].q6) * (fishm7.h0 - fishq[6].q6) + fishq[3].q5 * fishq[3].q5 - pti13 * pti13) / (2.0 * fishq[3].q5 * (fishm7.h0 - fishq[6].q6))) * 180.0 /  Math.PI - 90.0;
					else
						fishm8.th5 = 270.0 - Math.Acos(((fishm7.h0 - fishq[6].q6) * (fishm7.h0 - fishq[6].q6) + fishq[3].q5 * fishq[3].q5 - pti13 * pti13) / (2.0 * fishq[3].q5 * (fishm7.h0 - fishq[6].q6))) * 180.0 /  Math.PI;

					pti15 = fishm8.th2 - fishm8.th3 - fishm8.th5;//Virtual axis angle 4
					pti16 = pti01 - (fishm7.h0 - fishq[6].q6) * Math.Sin(pti15 *  Math.PI / 180.0) * Math.Sin(fishm8.th1 *  Math.PI / 180.0);//X coordinate of virtual point
					pti17 = pti02 - (fishm7.h0 - fishq[6].q6) * Math.Sin(pti15 *  Math.PI / 180.0) * Math.Cos(fishm8.th1 *  Math.PI / 180.0);//Y coordinate of virtual point
					pti18 = pti03 - (fishm7.h0 - fishq[6].q6) * Math.Cos(pti15 *  Math.PI / 180.0);//Z coordinate at virtual point
					pti14 = Math.Sqrt((pti16 - pti07) * (pti16 - pti07) + (pti17 - pti08) * (pti17 - pti08) + (pti18 - pti09) * (pti18 - pti09));//Distance between virtual point and Z0 point
					if (90.0 - Math.Atan(pti07 / pti08) * 180.0 /  Math.PI >= 90.0 - Math.Atan(pti01 / pti02) * 180.0 /  Math.PI)//Calculate the fourth axis coordinates
						fishm8.th4 = 2.0 * Math.Asin(pti14 / 2.0 / (fishm7.h0 - fishq[6].q6) / Math.Cos(fishm8.th5 *  Math.PI / 180.0)) * 180.0 /  Math.PI;
					else
						fishm8.th4 = -2.0 * Math.Asin(pti14 / 2.0 / (fishm7.h0 - fishq[6].q6) / Math.Cos(fishm8.th5 *  Math.PI / 180.0)) * 180.0 /  Math.PI;
					if (fishq[6].q4 * fishq[6].q4 + fishq[6].q5 * fishq[6].q5 > 0)//If the clamping position is offset, calculate the C axis coordinate
					{
						pti01 = fishq[6].q4;//√
						pti02 = (fishq[6].q5 * Math.Cos(-fishm8.th5 *  Math.PI / 180.0) + (fishq[6].q6 - fishm7.h0) * Math.Sin(-fishm8.th5 *  Math.PI / 180.0));//√
						pti03 = ((fishq[6].q6 - fishm7.h0) * Math.Cos(-fishm8.th5 *  Math.PI / 180.0) - fishq[6].q5 * Math.Sin(-fishm8.th5 *  Math.PI / 180.0));//√
						pti04 = pti01 * Math.Cos(-fishm8.th4 *  Math.PI / 180.0) - pti03 * Math.Sin(-fishm8.th4 *  Math.PI / 180.0);//√
						pti05 = pti02;//√
						pti06 = pti03 * Math.Cos(-fishm8.th4 *  Math.PI / 180.0) + pti01 * Math.Sin(-fishm8.th4 *  Math.PI / 180.0);//√
						pti10 = ((pti05 + fishq[3].q5) * Math.Cos(-fishm8.th3 *  Math.PI / 180.0) + (pti06 + fishq[3].q6) * Math.Sin(-fishm8.th3 *  Math.PI / 180.0));//√
						pti11 = ((pti06 + fishq[3].q6) * Math.Cos(-fishm8.th3 *  Math.PI / 180.0) - (pti05 + fishq[3].q5) * Math.Sin(-fishm8.th3 *  Math.PI / 180.0));//√
						pti12 = (pti10 * Math.Cos(fishm8.th2 *  Math.PI / 180.0) + (pti11 + fishq[2].q6) * Math.Sin(fishm8.th2 *  Math.PI / 180.0));//√
						pti13 = ((pti11 + fishq[2].q6) * Math.Cos(fishm8.th2 *  Math.PI / 180.0) - pti10 * Math.Sin(fishm8.th2 *  Math.PI / 180.0));//√
						pti14 = pti04 * Math.Cos(fishm8.th1 *  Math.PI / 180.0) + (pti12 + fishq[1].q5) * Math.Sin(fishm8.th1 *  Math.PI / 180.0);//√
						pti15 = (pti12 + fishq[1].q5) * Math.Cos(fishm8.th1 *  Math.PI / 180.0) - pti04 * Math.Sin(fishm8.th1 *  Math.PI / 180.0);//√
						pti16 = pti13 + fishq[1].q6;//√
						pti17 = Math.Sqrt((fishm7.th1 - pti14) * (fishm7.th1 - pti14) + (fishm7.th2 - pti15) * (fishm7.th2 - pti15) + (fishm7.th3 - pti16) * (fishm7.th3 - pti16));
						pti18 = Math.Sqrt(fishq[6].q4 * fishq[6].q4 + fishq[6].q5 * fishq[6].q5);
						//Need a positive and negative judgment method
						fishm8.th6 = 2.0 * Math.Asin(pti17 / 2.0 / pti18) * 180.0 /  Math.PI;
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

		public static void usbcncpath()
        {
            USB4 pth0 = usbcncRTCP(fishm2);//Calculate the coordinates after RTCP

			fish_mz = 0;//Initialization pulse signal
			if (pth0.th1 - fishq[1].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[1].q3) 
                    fish_fx = ActionAnd( fish_fx , ~((byte)fishq[1].q10));
				else 
                    fish_fx = ActionOR(fish_fx , fishq[1].q10);
				if (pth0.th1 - fishq[1].q50 >= fishq[1].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[1].q10);
					fishq[1].q50 = fishq[1].q50 + fishq[1].q11;//x-axis actual
				}
			}
			else if (pth0.th1 - fishq[1].q50 < 0)
			{
				if (fishq[1].q3) fish_fx = ActionOR(fish_fx , fishq[1].q10);
				else fish_fx = ActionAnd(fish_fx , ~fishq[1].q10);
				if (pth0.th1 - fishq[1].q50 <= -fishq[1].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[1].q10);
					fishq[1].q50 = fishq[1].q50 - fishq[1].q11;//x-axis actual
				}
			}
			if (pth0.th2 - fishq[2].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[2].q3) fish_fx = ActionAnd(fish_fx , ~fishq[2].q10);
				else fish_fx = ActionOR(fish_fx , fishq[2].q10);
				if (pth0.th2 - fishq[2].q50 >= fishq[2].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[2].q10);
					fishq[2].q50 = fishq[2].q50 + fishq[2].q11;//Y axis actual
				}
			}
			else if (pth0.th2 - fishq[2].q50 < 0)
			{
				if (fishq[2].q3) fish_fx = ActionOR(fish_fx , fishq[2].q10);
				else fish_fx = ActionAnd(fish_fx , ~fishq[2].q10);
				if (pth0.th2 - fishq[2].q50 <= -fishq[2].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[2].q10);
					fishq[2].q50 = fishq[2].q50 - fishq[2].q11;
				}
			}
			if (pth0.th3 - fishq[3].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[3].q3) fish_fx = ActionAnd(fish_fx , ~fishq[3].q10);
				else fish_fx = ActionOR(fish_fx , fishq[3].q10);
				if (pth0.th3 - fishq[3].q50 >= fishq[3].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[3].q10);
					fishq[3].q50 = fishq[3].q50 + fishq[3].q11;//Z axis actual
				}
			}
			else if (pth0.th3 - fishq[3].q50 < 0)
			{
				if (fishq[3].q3) fish_fx = ActionOR(fish_fx , fishq[3].q10);
				else fish_fx = ActionAnd(fish_fx , ~fishq[3].q10);
				if (pth0.th3 - fishq[3].q50 <= -fishq[3].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[3].q10);
					fishq[3].q50 = fishq[3].q50 - fishq[3].q11;
				}
			}
			if (pth0.th4 - fishq[4].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[4].q3) fish_fx = ActionAnd(fish_fx , ~fishq[4].q10);
				else fish_fx = ActionOR(fish_fx , fishq[4].q10);
				if (pth0.th4 - fishq[4].q50 >= fishq[4].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[4].q10);
					fishq[4].q50 = fishq[4].q50 + fishq[4].q11;//A-axis actual
				}
			}
			else if (pth0.th4 - fishq[4].q50 < 0)
			{
				if (fishq[4].q3) fish_fx = ActionOR(fish_fx , fishq[4].q10);
				else fish_fx = ActionAnd(fish_fx , ~fishq[4].q10);
				if (pth0.th4 - fishq[4].q50 <= -fishq[4].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[4].q10);
					fishq[4].q50 = fishq[4].q50 - fishq[4].q11;
				}
			}
			if (pth0.th5 - fishq[5].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[5].q3) fish_fx = ActionAnd(fish_fx , ~fishq[5].q10);
				else fish_fx = ActionOR(fish_fx , fishq[5].q10);
				if (pth0.th5 - fishq[5].q50 >= fishq[5].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[5].q10);
					fishq[5].q50 = fishq[5].q50 + fishq[5].q11;//B axis actual
				}
			}
			else if (pth0.th5 - fishq[5].q50 < 0)
			{
				if (fishq[5].q3) fish_fx = ActionOR(fish_fx , fishq[5].q10);
				else fish_fx = ActionAnd(fish_fx , ~fishq[5].q10);
				if (pth0.th5 - fishq[5].q50 <= -fishq[5].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[5].q10);
					fishq[5].q50 = fishq[5].q50 - fishq[5].q11;
				}
			}
			if (pth0.th6 - fishq[6].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[6].q3) fish_fx = ActionAnd(fish_fx , ~fishq[6].q10);
				else fish_fx = ActionOR(fish_fx , fishq[6].q10);
				if (pth0.th6 - fishq[6].q50 >= fishq[6].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[6].q10);
					fishq[6].q50 = fishq[6].q50 + fishq[6].q11;//C axis actual
				}
			}
			else if (pth0.th6 - fishq[6].q50 < 0)
			{
				if (fishq[6].q3) fish_fx =ActionOR(fish_fx , fishq[6].q10);
				else fish_fx = ActionAnd(fish_fx , ~fishq[6].q10);
				if (pth0.th6 - fishq[6].q50 <= -fishq[6].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[6].q10);
					fishq[6].q50 = fishq[6].q50 - fishq[6].q11;
				}
			}
			if (pth0.th7 - fishq[7].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[7].q3) fish_fx = ActionAnd(fish_fx , ~fishq[7].q10);
				else fish_fx = ActionOR(fish_fx , fishq[7].q10);
				if (pth0.th7 - fishq[7].q50 >= fishq[7].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[7].q10);
					fishq[7].q50 = fishq[7].q50 + fishq[7].q11;//D axis actual
				}
			}
			else if (pth0.th7 - fishq[7].q50 < 0)
			{
				if (fishq[7].q3) 
                    fish_fx = ActionOR(fish_fx , fishq[7].q10);
				else 
                    fish_fx = ActionAnd(fish_fx , ~fishq[7].q10);
				if (pth0.th7 - fishq[7].q50 <= -fishq[7].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[7].q10);
					fishq[7].q50 = fishq[7].q50 - fishq[7].q11;
				}
			}
			if (pth0.th8 - fishq[8].q50 > 0)//Calculate whether you really need to send a pulse
			{
				if (fishq[8].q3) 
                    fish_fx = ActionAnd(fish_fx , ~fishq[8].q10);
				else 
                    fish_fx = ActionOR(fish_fx , fishq[8].q10);
				if (pth0.th8 - fishq[8].q50 >= fishq[8].q11)
				{
					fish_mz = ActionOR(fish_mz , fishq[8].q10);
					fishq[8].q50 = fishq[8].q50 + fishq[8].q11;//E axis actual
				}
			}
			else if (pth0.th8 - fishq[8].q50 < 0)
			{
				if (fishq[8].q3) 
                    fish_fx = ActionOR(fish_fx , fishq[8].q10);
				else 
                    fish_fx = ActionAnd(fish_fx , ~fishq[8].q10);
				if (pth0.th8 - fishq[8].q50 <= -fishq[8].q11)
				{
					fish_mz = ActionOR(fish_mz , ((byte)fishq[8].q10));
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
		}

        public static void Handwheel()
        {
            fishq[0].q1 = (char) ActionAnd(fishq[0].q1, 31 | 32);
			while (fish1050 == 2 && fish_errer <= 999)//Key not released
			{
				if (fish_feed > fishq[0].q12)
					fish_feed = fishq[0].q12;
				else if (fish_feed < 0)
					fish_feed = 0.0;
				else if (Math.Abs(fish_sl) < fish_feed * fish_feed * fishq[0].q11 / fishq[0].q15 / 20000.0)
					fish_feed = fish_feed - fishq[0].q15 * fish_jgbl;
				else if (Math.Abs(fish_sl) > fish_feed * fish_feed * fishq[0].q11 / fishq[0].q15 / 20000.0)
					fish_feed = fish_feed + fishq[0].q15 * fish_jgbl;
				if (fish_wparam2 == 1 || fish_wparam2 == -1)//When pressing a or d key
				{
					if (fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14 > 0 && fish_errer != 101)
					{
						fish_sl = fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th1 = fishm2.th1 + fishq[0].q11 * fish_feed / fishq[0].q14;
						fish_x07 = fishm2.th1;
					}
					else if (fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14 < 0 && fish_errer != 100)
					{
						fish_sl = fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th1 = fishm2.th1 - fishq[0].q11 * fish_feed / fishq[0].q14;
						fish_x07 = fishm2.th1;
					}
					else fish_sl = 0;//When overtravel, the handwheel signal is cleared
				}
				else if (fish_wparam2 == 2 || fish_wparam2 == -2)//When the w or s key is pressed
				{
					if (fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14 > 0 && fish_errer != 103)
					{
						fish_sl = fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th2 = fishm2.th2 + fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else if (fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14 < 0 && fish_errer != 102)
					{
						fish_sl = fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th2 = fishm2.th2 - fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else fish_sl = 0;//When overtravel, the handwheel signal is cleared
				}
				else if (fish_wparam2 == 3 || fish_wparam2 == -3)//When pressing the q or z key
				{
					if (fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14 > 0 && fish_errer != 105)
					{
						fish_sl = fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th3 = fishm2.th3 + fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else if (fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14 < 0 && fish_errer != 104)
					{
						fish_sl = fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th3 = fishm2.th3 - fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else fish_sl = 0;//When overtravel, the handwheel signal is cleared
				}
				else if (fish_wparam2 == 4 || fish_wparam2 == -4)//When the e or c key is pressed
				{
					if (fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14 > 0 && fish_errer != 107)
					{
						fish_sl = fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th4 = fishm2.th4 + fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else if (fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14 < 0 && fish_errer != 106)
					{
						fish_sl = fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th4 = fishm2.th4 - fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else fish_sl = 0;//When overtravel, the handwheel signal is cleared
				}
				else if (fish_wparam2 == 5 || fish_wparam2 == -5)//When pressing the f or g key
				{
					if (fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14 > 0 && fish_errer != 109)
					{
						fish_sl = fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th5 = fishm2.th5 + fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else if (fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14 < 0 && fish_errer != 108)
					{
						fish_sl = fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th5 = fishm2.th5 - fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else fish_sl = 0;//When overtravel, the handwheel signal is cleared
				}
				else if (fish_wparam2 == 6 || fish_wparam2 == -6)//When the j or l key is pressed
				{
					if (fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14 > 0 && fish_errer != 111)
					{
						fish_sl = fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th6 = fishm2.th6 + fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else if (fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14 < 0 && fish_errer != 110)
					{
						fish_sl = fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th6 = fishm2.th6 - fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else fish_sl = 0;//When overtravel, the handwheel signal is cleared
				}
				else if (fish_wparam2 == 7 || fish_wparam2 == -7)//When pressing the i or k key
				{
					if (fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14 > 0 && fish_errer != 113)
					{
						fish_sl = fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th7 = fishm2.th7 + fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else if (fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14 < 0 && fish_errer != 112)
					{
						fish_sl = fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th7 = fishm2.th7 - fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else fish_sl = 0;//When overtravel, the handwheel signal is cleared
				}
				else if (fish_wparam2 == 8 || fish_wparam2 == -8)//When u or m key is pressed
				{
					if (fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14 > 0 && fish_errer != 115)
					{
						fish_sl = fish_sl - fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th8 = fishm2.th8 + fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else if (fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14 < 0 && fish_errer != 114)
					{
						fish_sl = fish_sl + fishq[0].q11 * fish_feed / fishq[0].q14;
						fishm2.th8 = fishm2.th8 - fishq[0].q11 * fish_feed / fishq[0].q14;
					}
					else fish_sl = 0;//When overtravel, the handwheel signal is cleared
				}
				usbcncpath();
			}
		}


		#region private

		private static byte ActionOR(object a, object b) => (byte) (Convert.ToByte(a) | Convert.ToByte(b));
        private static byte ActionAnd(object a, object b) => (byte)(Convert.ToByte(a) & Convert.ToByte(b));

        #endregion

	}
}

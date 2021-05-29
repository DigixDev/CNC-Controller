using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CNC_Controller.Models
{
    public class USB7
    {
        public char q1; //Tag number ('X','Y'...)
        public int q10; //Output IO point                        //Machine type
        public int q19; //Home direction                        //Pulse rate
        public bool q2; //Axis type (0: linear axis 1: rotary axis 0-360)
        public bool q3; //Coordinate axis direction control (1: forward 0: reverse)
        public double q4, q5, q6; //The position of the coordinate axis relative to the previous axis
        public double q7, q8, q9; //Sitting axis vector
        public double q11; //Resolution                       //System resolution
        public double q12; //Maximum moving speed                 //System movement speed
        public double q13; //Acceleration                       //System acceleration
        public double q14; //Starting speed                     //System start speed
        public double q15; //Minimum position                     //Handwheel acceleration
        public double q16; //Maximum position                     //Acceleration angle limit
        public double q17; //Retreat speed                     //Minimum arc acceleration
        public double q18; //Zero speed                     //Connection speed after calculating angle
        public double q20; //Backlash                     //Measuring distance
        public double q21; //Feedback resolution
        public double q22; //Feedback value						//Measuring position
        public double q23; //Tracking error
        public double q50; //Breakpoint location
        public double q51; //Machine coordinate system position (first reference point G28, zero return point)
        public double q52; //(Second reference point G30, tool change point)
    };
}

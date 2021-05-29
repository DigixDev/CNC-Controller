using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CNC_Controller.Core
{
    public class cszyUSB
    {
        [DllImport("zyUSBDev.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int zyUSB_WriteData(int siPipeNum, [MarshalAs(UnmanagedType.LPStr)] string pucRcvBuf, int siReadLen, int siWaitTime);

        [DllImport("zyUSBDev.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int zyUSB_ReadData(int siPipeNum, [MarshalAs(UnmanagedType.LPStr)] out string pucRcvBuf, int siReadLen, int siWaitTime);
    }
}

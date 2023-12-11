using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    internal class LockScreen
    {
        [DllImport("user32")]
        public static extern void LockWorkStation();
    }
}

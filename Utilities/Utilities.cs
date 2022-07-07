using System.Collections;
using System.Management;

namespace Utilities
{
    public class Utilities
    {
        public static string GetHDUniqueIdentity()
        {
            string identity = string.Empty;

            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            List<HardDrive> hardDriveDetails = new List<HardDrive>();

            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
                HardDrive hd = new HardDrive();  // User Defined Class
                hd.Model = wmi_HD["Model"].ToString();  //Model Number
                hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                hd.SerialNo = wmi_HD["SerialNumber"].ToString(); //Serial Number
                hardDriveDetails.Add(hd);
            }

            if (hardDriveDetails.Count > 0)
            {
                identity = string.Format("{0}-{1}-{2}", hardDriveDetails[0].Model, hardDriveDetails[0].Type, hardDriveDetails[0].SerialNo); ;
            }

            return identity;
        }

    }
}
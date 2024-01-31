using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ManagerFile
{
    public class Common
    {
        public List<string> LoadVungUsb()
        {
            List<string> lstVung = new List<string>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
                foreach (ManagementObject usbDrive in searcher.Get())
                {
                    // Lấy các phân vùng của ổ đĩa USB
                    ManagementObjectSearcher partitionSearcher = new ManagementObjectSearcher($"ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{usbDrive["DeviceID"]}'}} WHERE AssocClass = Win32_DiskDriveToDiskPartition");
                    foreach (ManagementObject partition in partitionSearcher.Get())
                    {
                        // Lấy thông tin về phân vùng
                        ManagementObjectSearcher logicalDriveSearcher = new ManagementObjectSearcher($"ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{partition["DeviceID"]}'}} WHERE AssocClass = Win32_LogicalDiskToPartition");

                        var abc = logicalDriveSearcher.Get();

                        foreach (ManagementObject logicalDrive in logicalDriveSearcher.Get())
                        {
                            string Disk = logicalDrive["DeviceID"].ToString() + @"\";

                            lstVung.Add(Disk);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                lstVung.Add(ex.Message);
            }

            return lstVung;

        }
    }
}

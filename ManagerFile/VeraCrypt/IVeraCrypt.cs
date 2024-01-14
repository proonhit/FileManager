using System.Collections.Generic;
using ManagerFile.Enums;
using CliSharp.Core;


namespace ManagerFile
{
    public interface IVeraCrypt
    {
        void Mount(string filePath, string password, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool isSilent = true, MountOption mountOption = MountOption.NoAttach);
        void MountSecure(string filePath, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool useSecureDesktop = false);
        void Dismount(string driveLetter = "V", bool isSilent = true);
        void DismountAll();
        void Execute(IEnumerable<CommandLineSwitch> switches);
    }
}

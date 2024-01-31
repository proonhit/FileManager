using CliSharp.Core;
using CliSharp.Extensions;
using System.Collections.Generic;
using System.IO;
using ManagerFile.Enums;
using System.Text;
using System.Windows.Forms;
using System;

namespace ManagerFile.VeraCrypt
{
    public class VeraCrypt : IVeraCrypt
    {
        private readonly string executablePath;
        private string LogFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\log.txt";
        public VeraCrypt(string executablePath)
        {
            if (!File.Exists(executablePath))
                throw new FileNotFoundException("Executable of VeraCrypt not found at given file path", executablePath);

            this.executablePath = executablePath;

            //LogMessage("executablePath: " + executablePath);

        }

        public void Mount(string volumePath, string password, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool isSilent = false, MountOption mountOption = MountOption.NoAttach)
        {
            try
            {
                Cli
                .SetProgram(executablePath)
                .AddSwitch(VeraCryptSwitches.Volume, volumePath)
                .AddSwitch(VeraCryptSwitches.DriveLetter, driveLetter)
                .AddSwitch(VeraCryptSwitches.Password, password)
                .AddSwitch(VeraCryptSwitches.QuitAfterActions)
                .AddConditionalSwitch(VeraCryptSwitches.MountOption, mountOption, mountOption != MountOption.Auto)
                .AddConditionalSwitch(VeraCryptSwitches.HashAlgorithm, hashAlgorithm, hashAlgorithm != HashAlgorithm.Auto)
                .AddConditionalSwitch(VeraCryptSwitches.QuietMode, isSilent)
                .Execute();

            }
            catch (System.Exception ex)
            {
                //LogMessage(ex.Message);

            }

        }

        public void MountLetter(string volumePath, string password, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool isSilent = false)
        {
            try
            {
                Cli
                .SetProgram(executablePath)
                .AddSwitch(VeraCryptSwitches.Volume, volumePath)
                .AddSwitch(VeraCryptSwitches.DriveLetter, driveLetter)
                .AddSwitch(VeraCryptSwitches.Password, password)
                .AddSwitch(VeraCryptSwitches.QuitAfterActions)
                .AddConditionalSwitch(VeraCryptSwitches.HashAlgorithm, hashAlgorithm, hashAlgorithm != HashAlgorithm.Auto)
                .AddConditionalSwitch(VeraCryptSwitches.QuietMode, isSilent)
                .Execute();

            }
            catch (System.Exception ex)
            {
                //LogMessage(ex.Message);

            }

        }


        public void MountSecure(string volumePath, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool useSecureDesktop = false)
        {
            Cli
                .SetProgram(executablePath)
                .AddSwitch(VeraCryptSwitches.Volume, volumePath)
                .AddSwitch(VeraCryptSwitches.DriveLetter, driveLetter)
                .AddSwitch(VeraCryptSwitches.SecureDesktop, useSecureDesktop ? Answer.Yes : Answer.No)
                .AddSwitch(VeraCryptSwitches.QuitAfterActions)
                .AddConditionalSwitch(VeraCryptSwitches.HashAlgorithm, hashAlgorithm, hashAlgorithm != HashAlgorithm.Auto)
                .Execute();
        }
        public void Dismount(string driveLetter, bool isSilent = false)
        {
            Cli
                .SetProgram(executablePath)
                .AddSwitch(VeraCryptSwitches.DismountDriveLetter, driveLetter)
                .AddSwitch(VeraCryptSwitches.QuitAfterActions)
                .AddConditionalSwitch(VeraCryptSwitches.QuietMode, isSilent)
                .Execute();
        }
        public void DismountAll()
        {
            Cli
                .SetProgram(executablePath)
                .AddSwitch(VeraCryptSwitches.DismountAll)
                .AddSwitch(VeraCryptSwitches.QuitAfterActions)
                .Execute();
        }

        public void Execute(IEnumerable<CommandLineSwitch> switches)
        {
            var command = Cli.SetProgram(executablePath);

            foreach (var _switch in switches)
            {
                command.AddSwitch(_switch);
            }

            command.Execute();
        }

        //public void LogMessage(string message)
        //{
        //    if (!File.Exists(LogFilePath))
        //    {
        //        StreamWriter writer = File.CreateText(LogFilePath);
        //    }

        //    // Ghi log vào tệp tin
        //    using (StreamWriter writer = new StreamWriter(LogFilePath, true))
        //    {
        //        writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        //    }
        //}
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace ManagerFile.Helper
{
    public enum ScanResult
    {
        /// <summary>
        /// No threat was found
        /// </summary>
        [Description("No threat found")]
        NoThreatFound,

        /// <summary>
        /// A threat was found
        /// </summary>
        [Description("Threat found")]
        ThreatFound,

        /// <summary>
        /// File not found
        /// </summary>
        [Description("The file could not be found")]
        FileNotFound,

        /// <summary>
        /// The scan timed out
        /// </summary>
        [Description("Timeout")]
        Timeout,

        /// <summary>
        /// An error occured while scanning
        /// </summary>
        [Description("Error")]
        Error

    }
}

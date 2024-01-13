using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerFile.Helper
{
    public struct PostStatus
    {
        public static readonly Int16 CREATING = 0;
        public static readonly Int16 SENDING = 1;
        public static readonly Int16 SENDED = 2;
        public static readonly Int16 DRAFF = 3;
        public static readonly Int16 ERROR = 4;
        public static readonly Int16 SAVED = 5;
    }
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

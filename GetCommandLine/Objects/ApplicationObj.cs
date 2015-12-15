using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCommandLine.Objects
{
    public class ApplicationObj
    {
        public string FileName { get; set; }
        public bool IsMSIPackage { get; set; }
        public string GUID { get; set; }
        public string WorkingDirectory { get; set; }
        public bool NeedReboot { get; set; }
        public bool IsEnable { get; set; }
        public string Parameter { get; set; }
    }
}

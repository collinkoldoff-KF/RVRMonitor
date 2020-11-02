using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVRMonitor
{
    public class Airport
    {
        public string code;
        public string[] runways;
        public Airport(string code, string[] runways)
        {
            this.code = code;
            this.runways = runways;
        }
        public string getCode()
        {
            return code;
        }
        public string[] getRunways()
        {
            return runways;
        }
    }
}

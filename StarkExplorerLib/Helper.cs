using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarkExplorerLib
{
    public class Helper
    {
        public static string GetEnvVar(string envvarName)
        {
            return Environment.GetEnvironmentVariable(envvarName);
        }
    }
}

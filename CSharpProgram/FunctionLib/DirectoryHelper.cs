using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLib
{
    public class DirectoryHelper
    {
        public static string GetCurrentModuleDirectory()
        {
            string fullPath = AppDomain.CurrentDomain.BaseDirectory;
            return fullPath;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MinervaPlugin
{
    class ResourceHelper
    {
        public static string GetEmbeddedResourceContent(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream? stream = asm.GetManifestResourceStream(resourceName);

            if (stream == null)
            {
                throw new FileNotFoundException(resourceName);
            }

            StreamReader source = new StreamReader(stream);
            string fileContent = source.ReadToEnd();
            source.Dispose();
            stream.Dispose();
            return fileContent;
        }

        public static string[] GetAllResourcesNames()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            return asm.GetManifestResourceNames();
        }
    }
}

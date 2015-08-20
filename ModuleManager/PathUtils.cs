using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ModuleManager
{
    class StringUtils
    {
        /// <summary>
        /// Return a relative path of a file in relation to a folder
        /// </summary>
        /// <param name="folderRel">The absolute path of the folder to find the relative path of</param>
        /// <param name="folderRoot">The absolute path of the root folder to be relative to</param>
        /// <returns></returns>
        public static string GetRelativePath(string folderRel, string folderRoot)
        {
            //Ensure folder names end with a /
            if (!folderRel.EndsWith(Path.DirectorySeparatorChar.ToString()))
                folderRel += Path.DirectorySeparatorChar;
            if (!folderRoot.EndsWith(Path.DirectorySeparatorChar.ToString()))
                folderRoot += Path.DirectorySeparatorChar;


            Uri fileURI     = new Uri(folderRel, UriKind.Absolute);
            Uri relFolder   = new Uri(folderRoot, UriKind.Absolute);

            return relFolder.MakeRelativeUri(fileURI).ToString();
        }
    }
}

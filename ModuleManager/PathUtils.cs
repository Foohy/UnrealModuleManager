using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ModuleManager
{
    class PathUtils
    {
        //Return a relative path of a file in relation to a folder
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

using System;
using System.IO;
using Microsoft.Extensions.Options;
using KiriBrand.Static.Models.Configuration;
using KiriBrand.Static.Models.Configuration.Core;

namespace KiriBrand.Static.Services
{
    //Decorator class which groups all the configuration data related to the
    //website structure paths, and provides helper convert to MD files to html content
    public class StaticAssetsPathResolver
    {
        public StaticAssetsPathResolver()
        {
        }

        //Calculate relative path of a file based on another folder
        public string GetRelativePath(string filePath, string rootFolderPath)
        {
            try
            {
                filePath = filePath.StartsWith("/") ? filePath.Insert(0, "/") : filePath;
                rootFolderPath = rootFolderPath.StartsWith("/") ? rootFolderPath.Insert(0, "/") : rootFolderPath;
                Uri pathUri = new Uri(filePath);
                // Folders must end in a slash
                if (!rootFolderPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    rootFolderPath += Path.DirectorySeparatorChar;
                }
                Uri folderUri = new Uri(rootFolderPath);
                string result = Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString());
                return result;
            }
            catch (System.Exception e)
            {
                throw new Exception(string.Format("filePath: {0}, rootFolderPath: {1}", filePath, rootFolderPath), e);
            }

        }

    }
}
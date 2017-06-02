using System;
using System.IO;
using Markdig;
using Microsoft.Extensions.Options;
using PersoBrandStaticGenerator.Models.Configuration;

namespace PersoBrandStaticGenerator.Models.Services.Parser
{
    //Decorator class which groups all the configuration data related to the
    //website structure paths, and provides helper convert to MD files to html content
    public class WebMdContentParserDecorator
    {
        private readonly Culture culture;
        private readonly MdContentParserService mdContentConverterService;
        private readonly Global globalSettings;

        public WebMdContentParserDecorator(
            Global globalSettings,
            Culture culture,
            MdContentParserService mdContentConverterService)
        {
            this.culture = culture;
            this.mdContentConverterService = mdContentConverterService;
            this.globalSettings = globalSettings;
        }

        //Convert config md file Path to html content
        public string ConvertMdContent(string configMdFilePath)
        {
            if (!string.IsNullOrWhiteSpace(configMdFilePath))
            {
                string path = Path.Combine(this.culture.SourceFolderPath, configMdFilePath);
                return this.mdContentConverterService.ConvertMdContent(path);
            }
            return "";
        }

        //Convert config md file Path to html content
        public string GetRelativePath(string uri)
        {
            //if we are dealing with the default culture
            if (this.culture.Key == this.globalSettings.DefaultCulture)
                return uri;

            string outputAbsolutePath = new DirectoryInfo(this.globalSettings.OutputFolderPath).FullName;
            Uri pathUri = new Uri(Path.Combine(outputAbsolutePath, uri));
            // Folders must end in a slash
            string rootFolder = Path.Combine(outputAbsolutePath, culture.Key);
            if (!rootFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                rootFolder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(rootFolder);
            string result = Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString());
            return result;
        }

    }
}
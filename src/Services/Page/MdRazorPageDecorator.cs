using System;
using System.IO;
using Markdig;
using Microsoft.Extensions.Options;
using KiriBrand.Static.Models.Configuration;
using KiriBrand.Static.Models.Configuration.Core;

namespace KiriBrand.Static.Services.Page
{
    //Decorator class which groups all the configuration data related to the
    //website structure paths, and provides helper convert to MD files to html content
    public class MdRazorPageDecorator
    {
        private readonly Global globalSettings;
        private readonly Culture culture;
        private readonly MdContentParser mdContentConverterService;
        private readonly StaticAssetsPathResolver staticAssetsPathResolver;


        public MdRazorPageDecorator(
            Global globalSettings,
            Culture culture,
            MdContentParser mdContentConverterService,
            StaticAssetsPathResolver staticAssetsPathResolver)
        {
            this.globalSettings = globalSettings;
            this.culture = culture;
            this.mdContentConverterService = mdContentConverterService;
            this.staticAssetsPathResolver = staticAssetsPathResolver;
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
            uri = uri.Trim();
            //if we are dealing with the default culture
            if (this.culture.Key == this.globalSettings.DefaultCulture)
                return uri;

            string outputAbsolutePath = new DirectoryInfo(this.globalSettings.OutputFolderPath).FullName;
            string filePath = Path.Combine(outputAbsolutePath, uri);
            string rootFolder = Path.Combine(outputAbsolutePath, culture.Key);
            string result = this.staticAssetsPathResolver.GetRelativePath(filePath, rootFolder);
            return result;
        }

    }
}
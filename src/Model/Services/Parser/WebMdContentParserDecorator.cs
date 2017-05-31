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
        private readonly WebContentPaths contentPaths;
        private readonly MdContentParserService mdContentConverterService;

        public WebMdContentParserDecorator(
            WebContentPaths contentOptionsAccessor,
            MdContentParserService mdContentConverterService)
        {
            this.contentPaths = contentOptionsAccessor;
            this.mdContentConverterService = mdContentConverterService;

        }

        //Convert config md file Path to html content
        public string ConvertMdContent(string configMdFilePath)
        {
            if (!string.IsNullOrWhiteSpace(configMdFilePath))
            {
                string path = Path.Combine(this.contentPaths.SourceFolderPath, configMdFilePath);
                return this.mdContentConverterService.ConvertMdContent(path);
            }
            return "";
        }

    }
}
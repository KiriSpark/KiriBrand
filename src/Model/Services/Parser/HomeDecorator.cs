using Microsoft.Extensions.Options;
using PersoBrandStaticGenerator.Models.Configuration;

namespace PersoBrandStaticGenerator.Models.Services.Parser
{
    //Decorator class which load and convert Home object content into html content
    public class HomeDecorator
    {
        private readonly WebMdContentParserDecorator webContentParser;
        public readonly Home Home;

        public HomeDecorator(
            WebMdContentParserDecorator webContentParser,
            WebContentStructure contentStructureAccessor)
        {
            this.webContentParser = webContentParser;
            this.Home = contentStructureAccessor.Home;
        }

        public string ConvertMdContent(string mdFilePath)
        {
            return this.webContentParser.ConvertMdContent(mdFilePath);
        }
    }
}
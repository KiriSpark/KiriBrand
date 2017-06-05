using System.Dynamic;
using System.IO;
using Microsoft.Extensions.Options;
using PersoBrandStaticGenerator.Models.Configuration;

namespace PersoBrandStaticGenerator.Models.Services.Parser
{
    //Decorator class which load and convert Home object content into html content
    public class HomeDecorator : IPageDecorator
    {
        private readonly WebMdContentParserDecorator webContentParser;
        public readonly Home Home;

        //IPageDecorator implementation
        public string PageTemplatePath
        {
            get
            {
                return this.Home.HomeTemplate;
            }
        }

        private ExpandoObject expandoPageData;
        public ExpandoObject ExpandoPageData
        {
            get
            {
                if (this.expandoPageData == null)
                {
                    var expandoBase = new ExpandoObject();
                    ((dynamic)expandoBase).Page = this.Home;
                    this.expandoPageData = expandoBase;
                }
                return this.expandoPageData;
            }
        }

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

        public string GetRelativePath(string uri)
        {
            return this.webContentParser.GetRelativePath(uri);
        }
    }
}
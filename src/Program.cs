using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using PersoBrandStaticGenerator.Models.Configuration;
using PersoBrandStaticGenerator.Models.Services;
using PersoBrandStaticGenerator.Models.Services.Parser;
using RazorLight;
using RazorLight.Extensions;
namespace PersoBrandStaticGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 load configuration 
            var builder = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json", false, true)
                       .AddJsonFile("contentsettings.json", false, true)
                       .AddEnvironmentVariables();
            var configuration = builder.Build();

            var webContentPaths = new WebContentPaths();
            configuration.GetSection("WebContent").Bind(webContentPaths);
            var webContentStructure = new WebContentStructure();
            configuration.GetSection("WebContentStructure").Bind(webContentStructure);

            //2 set base directory of template folder
            var fileInfo = new FileInfo(webContentPaths.Global.DefaultRazorTemplateFolderPath);
            var engine = EngineFactory.CreatePhysical(fileInfo.FullName);

            //3 generate html files, for each culture:
            var mdParserService = new MdContentParserService();
            foreach (Culture culture in webContentPaths.Cultures)
            {
                //3.1 load model
                var mdParserDecorator = new WebMdContentParserDecorator(webContentPaths.Global, culture, mdParserService);
                var homeParser = new HomeDecorator(mdParserDecorator, webContentStructure);

                //4 generate html string based on template file and model
                string indexHtml = engine.Parse("index.cshtml", homeParser);

                //5 save to output folder
                string outputFolder = webContentPaths.Global.OutputFolderPath;
                if (culture.Key != webContentPaths.Global.DefaultCulture)
                {
                    outputFolder = Path.Combine(outputFolder, culture.Key);
                }
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);
                File.WriteAllText(Path.Combine(outputFolder, "index.html"), indexHtml);
            }



        }
    }
}

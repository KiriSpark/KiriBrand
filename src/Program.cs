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
            var fileInfo = new FileInfo("../content/template");
            var engine = EngineFactory.CreatePhysical(fileInfo.FullName);

            //3 load model
            var mdParserService = new MdContentParserService();
            var mdParserDecorator = new WebMdContentParserDecorator(webContentPaths, mdParserService);
            var homeParser = new HomeDecorator(mdParserDecorator, webContentStructure);

            //4 generate html string based on template file and model
            string indexHtml = engine.Parse("index.cshtml", homeParser);

            //5 save to output folder
            string outputFolder = Path.Combine(AppContext.BaseDirectory, "dist");
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            File.WriteAllText(Path.Combine(outputFolder, "index.html"), indexHtml);

        }
    }
}

﻿using System;
using System.Dynamic;
using System.IO;
using Microsoft.Extensions.Configuration;
using PersoBrandStaticGenerator.Models.Configuration;
using PersoBrandStaticGenerator.Models.Services;
using PersoBrandStaticGenerator.Models.Services.Parser;
using RazorLight;
using RazorLight.Extensions;
using System.Collections.Generic;

namespace PersoBrandStaticGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 load configuration from src folder 
            var builder = new ConfigurationBuilder()
                       .AddJsonFile(new FileInfo("appsettings.json").FullName, false, true)
                       .AddEnvironmentVariables();
            var configuration = builder.Build();

            var webContentPaths = new WebContentPaths();
            configuration.GetSection("WebContent").Bind(webContentPaths);

            //2 set base directory of template folder
            var fileInfo = new FileInfo(webContentPaths.Global.DefaultRazorTemplateFolderPath);
            var engine = EngineFactory.CreatePhysical(fileInfo.FullName);

            //3 generate html files, for each culture:
            var mdParserService = new MdContentParserService();
            foreach (Culture culture in webContentPaths.Cultures)
            {
                //3.1 load model for culture

                //3.1.1 load configuration file for this culture
                var mdParserDecorator = new WebMdContentParserDecorator(webContentPaths.Global, culture, mdParserService);
                var confPath = new FileInfo(culture.ConfigurationFilePath).FullName;
                var cultureConfigBuilder = new ConfigurationBuilder()
                       .AddJsonFile(confPath, false, true)
                       .Build();
                var cultureStructure = new WebContentStructure();
                configuration.GetSection("WebContentStructure").Bind(cultureStructure);

                var pagesModel = new List<IPageDecorator>();

                //3.1.2 add home information if available
                if (cultureStructure.Home != null)
                {
                    var homeParser = new HomeDecorator(mdParserDecorator, cultureStructure);
                    pagesModel.Add(homeParser);
                }

                //3.2 loading pages based on culture configuration
                foreach (var model in pagesModel)
                {
                    ((dynamic)model.ExpandoPageData).Base = mdParserDecorator;
                    //3.2.1 generate html string based on template file and model
                    string indexHtml = engine.Parse(model.PageTemplatePath, model, model.ExpandoPageData);

                    //3.2.2 save to output folder
                    string outputFolder = webContentPaths.Global.OutputFolderPath;
                    if (culture.Key != webContentPaths.Global.DefaultCulture)
                    {
                        outputFolder = Path.Combine(outputFolder, culture.Key);
                    }

                    if (!Directory.Exists(outputFolder))
                        Directory.CreateDirectory(outputFolder);
                    File.WriteAllText(Path.Combine(outputFolder, model.PageTemplatePath.Replace(".cshtml", ".html")), indexHtml);
                }

            }
        }
    }
}

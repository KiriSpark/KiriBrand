using System;
using System.IO;
using RazorLight;
using RazorLight.Extensions;
namespace PersoBrandStaticGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 set base directory of template folder
            var fileInfo = new FileInfo("../content/template");
            var engine = EngineFactory.CreatePhysical(fileInfo.FullName);

            //2 generate html string based on template file and model
            string indexHtml = engine.Parse("index.cshtml", "");

            //3 save to output folder
            string outputFolder = Path.Combine(AppContext.BaseDirectory, "dist");
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            File.WriteAllText(Path.Combine(outputFolder, "index.html"), indexHtml);

        }
    }
}

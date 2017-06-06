using System.IO;
using Markdig;

namespace PersoBrandStaticGenerator.Models.Services
{
    //service to parse an md file to html content
    public class MdContentParser
    {
        private readonly MarkdownPipeline pipeline;
        public MdContentParser()
        {
            // Configure the pipeline with all advanced extensions active
            //except (except Emoji, SoftLine as HarLine and SmartyPants)
            this.pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        }
        public string ConvertMdContent(string mdFilePath)
        {
            string value = File.ReadAllText(mdFilePath);
            return Markdown.ToHtml(value, this.pipeline);
        }
    }
}
using System.Dynamic;
using Microsoft.Extensions.Options;
using PersoBrandStaticGenerator.Models.Configuration;

namespace PersoBrandStaticGenerator.Models.Services.Parser
{
    //Interface for page decorator common properties
    public interface IPageDecorator
    {
        string PageTemplatePath { get; }

        ExpandoObject ExpandoPageData { get; }
    }
}
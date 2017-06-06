using System.Dynamic;
using Microsoft.Extensions.Options;
using PersoBrandStaticGenerator.Models.Configuration;

namespace PersoBrandStaticGenerator.Models.Services.Page
{
    //Interface for page decorator common properties
    public interface IRazorPage
    {
        string PageTemplatePath { get; }

        ExpandoObject ExpandoPageData { get; }
    }
}
using System.Dynamic;
using Microsoft.Extensions.Options;
using KiriBrand.Static.Models.Configuration;

namespace KiriBrand.Static.Services.Page
{
    //Interface for page decorator common properties
    public interface IRazorPage
    {
        string PageTemplatePath { get; }

        ExpandoObject ExpandoPageData { get; }
    }
}
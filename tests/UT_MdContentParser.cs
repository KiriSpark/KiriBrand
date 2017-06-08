using System;
using System.IO;
using KiriBrand.Static.Services;
using Xunit;

namespace tests
{
    public class UT_MdContentParser
    {
        [Fact]
        public void UT_MdContentParser_ConvertMdContent()
        {
            //arrange
            string path = Path.Combine(AppContext.BaseDirectory, @"source\test.md");
            var service = new MdContentParser();

            //act
            string result = service.ConvertMdContent(path);

            //assert
            Assert.NotNull(result);
            Assert.Equal("<p><em>hello world</em></p>\n", result);
        }
    }
}

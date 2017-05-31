namespace PersoBrandStaticGenerator.Models.Configuration
{
    //Home page content information
    //Each property points to the resource location
    //of each specific home sections
    public class BodySection
    {
        public string Id { get; set; }
        public string MdPath { get; set; }
        public string ColorKey { get; set; }
        public string CustomCss { get; set; }
    }
}
namespace KiriBrand.Static.Models.Configuration.Content
{
    //Home page content information
    //Each property points to the resource location
    //of each specific home sections
    public class MdItem
    {
        public string Id { get; set; }
        public string MdPath { get; set; }
        public string CustomCss { get; set; }
    }
}
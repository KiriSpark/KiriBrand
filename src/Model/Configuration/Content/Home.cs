namespace KiriBrand.Static.Models.Configuration.Content
{
    //Home page content information
    //Each property points to the resource location
    //of each specific home sections
    public class Home
    {
        public string HomeTemplate { get; set; }
        public string GlobalBackgroundPicture { get; set; }
        public string GlobalLoaderPicture { get; set; }
        public string Title { get; set; }
        public string TitleDescription { get; set; }
        public MdItem[] TitleMenus { get; set; }
        public string TitlePicture { get; set; }
        public MdItem[] BodySections { get; set; }
    }
}
namespace PersoBrandStaticGenerator.Models.Configuration
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
        public TitleMenu[] TitleMenus { get; set; }
        public string TitlePicture { get; set; }
        public BodySection[] BodySections { get; set; }
    }
}
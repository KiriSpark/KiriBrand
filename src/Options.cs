namespace KiriBrand
{
    public enum Environment
    {
        Dev = 0,
        Prod

    }
    public class Options
    {
        public Environment Environment { get; set; }
    }
}
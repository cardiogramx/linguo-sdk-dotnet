namespace Linguo
{
    public class TranslateV1
    {
        public string Text { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }

    public class TranslateV2
    {
        public string[] Texts { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }
}

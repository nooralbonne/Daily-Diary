namespace DiaryManager
{
    public class Entry
    {
        public string Date { get; set; }
        public string Content { get; set; }

        public Entry(string date, string content)
        {
            Date = date;
            Content = content;
        }

        public override string ToString()
        {
            return $"{Date}\n{Content}";
        }
    }
}

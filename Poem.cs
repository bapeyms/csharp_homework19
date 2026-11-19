namespace csharp_homework19;

public class Poem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string Text { get; set; }
    public string Theme { get; set; }

    public int Length
    {
        get
        {
            return Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
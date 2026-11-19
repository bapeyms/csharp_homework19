using System.Text;

namespace csharp_homework19;

class Program
{
    static List<Poem> poems = new List<Poem>();
    
    static void Main(string[] args)
    {
        poems.Add(new Poem
        {
            Title = "Silent Heart", Author = "Emily Carter", Year = 2018, Theme = "Love",
            Text = "I wrote your name upon the sand\nThe tide came in, I understand\nSome words are meant to disappear\nBut love remains, it's always here\nSo I will wait, and I will stay"
        });
        poems.Add(new Poem 
        { Title = "Autumn Rain", Author = "John Miller", Year = 1998,
            Theme = "Nature",
            Text = "The rain falls soft on the empty street\nThe leaves are gold beneath my feet\nThe wind is calling, the sky is grey\nAnother summer fades away" 
        });

        while (true)
        {
            Console.WriteLine("\n --- REPORTS ---");
            Console.WriteLine("1) - by title");
            Console.WriteLine("2 - by author");
            Console.WriteLine("3 - by theme");
            Console.WriteLine("4 - by word in the text");
            Console.WriteLine("5 - by year of writing");
            Console.WriteLine("6 - by length (number of lines)");
            Console.WriteLine("0 - exit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine() ?? string.Empty;

            List<Poem> found = null;
            string header = "";

            switch (choice)
            {
                case "1":
                    Console.Write("Title: ");
                    string title = Console.ReadLine() ?? string.Empty;
                    found = poems.Where(p => p.Title.ToLower().Contains(title.ToLower())).ToList();
                    header = "Report by title: " + title;
                    break;
                case "2":
                    Console.Write("Title: ");
                    string author = Console.ReadLine() ?? string.Empty;
                    found = poems.Where(p => p.Author.ToLower().Contains(author.ToLower())).ToList();
                    header = "Report by author: " + author;
                    break;
                case "3":
                    Console.Write("Theme: ");
                    string theme = Console.ReadLine() ?? string.Empty;
                    found = poems.Where(p => p.Theme.ToLower().Contains(theme.ToLower())).ToList();
                    header = "Report by theme: " + theme;
                    break;
                case "4":
                    Console.Write("Word: ");
                    string word = Console.ReadLine() ?? string.Empty;
                    found = poems.Where(p => p.Text.ToLower().Contains(word.ToLower())).ToList();
                    header = "Report by word: " + word;
                    break;
                case "5":
                    Console.Write("Year: ");
                    int year = int.Parse(Console.ReadLine() ?? string.Empty);
                    found = poems.Where(p => p.Year == year).ToList();
                    header = "Report by year: " + year;
                    break;
                case "6":
                    Console.Write("Minimum lines: ");
                    int min = int.Parse(Console.ReadLine() ?? string.Empty);
                    Console.Write("Maximum lines: ");
                    int max = int.Parse(Console.ReadLine()  ?? string.Empty);
                    found = poems.Where(p => p.Length >= min && p.Length <= max).ToList();
                    header = "Report by length: from " + min + " to " + max + " lines";
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    continue;
            }
            string report = BuildReport(header, found);
            Output(report);
        }

        static string BuildReport(string header, List<Poem> found)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);
            sb.AppendLine("- Poems found: " + found.Count + " -");
            foreach (Poem p in found)
            {
                sb.AppendLine("Title: " + p.Title);
                sb.AppendLine("Author: " + p.Author);
                sb.AppendLine("Year: " + p.Year);
                sb.AppendLine("Theme: " + p.Theme);
                sb.AppendLine("Length: " + p.Length + " lines");
                sb.AppendLine("Text:");
                sb.AppendLine(p.Text + "\n");
            }
            return sb.ToString();
        }

        static void Output(string report)
        {
            Console.Write("Where to output the report? 1) - screen, 2) - file? -> ");
            string where = Console.ReadLine() ?? string.Empty;
            if (where == "2")
            {
                Console.Write("File name (for example report.txt): ");
                string fileName = Console.ReadLine() ?? string.Empty;
                File.WriteAllText(fileName, report, Encoding.UTF8);
                Console.WriteLine("Report written to: " + fileName);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine(report);
            }
        }
    }
}

using System.Text;
using System.Text.RegularExpressions;

 laba8 lab = new laba8();
        string[] fileText = File.ReadAllLines("/Users/dinax/kpypLaby/ConsoleApp3/text");
        lab.FindAdapter(fileText);
        lab.SecondEx();

class laba8
{
    public static void CreateHtmlDoc(string TextInBody)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<html >");
        sb.Append("<head >");
        string meta = @"<meta charset=""UTF-8"">";
        sb.Append(meta);
        sb.Append("<title >");
        sb.Append("</title >");
        sb.Append("</head >");
        sb.Append("<body >");
        sb.Append(TextInBody);
        sb.Append("</body >");
        sb.Append("</html >");
        using (StreamWriter sw = new StreamWriter("MyHtml.html"))
        {
            sw.Write(sb.ToString());
            sw.Close();
            Console.WriteLine("Файл создан успешно!");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "MyHtml.html",
                UseShellExecute = true
            });
        }
    }

    public void FindAdapter(string[] fileText)
    {
        Regex reg = new Regex(@"[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}");

        foreach (string str in fileText)
        {
            MatchCollection matches = reg.Matches(str);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }

    public void SecondEx()
    {
        string text = File.ReadAllText("/Users/dinax/kpypLaby/ConsoleApp3/text");
        string pattern = @"p";
        Regex reg = new Regex(pattern);
        bool flag = true;
        while (reg.IsMatch(text))
    {
        text = flag ? reg.Replace(text, @"<PRE>", 1) : reg.Replace(text, @"</PRE>", 1);
        flag = !flag;
        
    }
        string[] mas = text.Split('\n');
        pattern = @"Fs(\d)";
        reg = new Regex(pattern);
        for (int i = 0; i < mas.Length; i++)
        {
            if (reg.IsMatch(mas[i]))
            {
                string size = reg.Match(mas[i]).Groups[1].Value;
                mas[i] = reg.Replace(mas[i], $@"<font size=""{size}"">");
                mas[i] = mas[i] + "</font>";
            }
        }
        text = string.Join("<Br>", mas, 0, mas.Length);
        CreateHtmlDoc(text);
    }
}
//(?<!<PRE>)P(?!<\/PRE>)

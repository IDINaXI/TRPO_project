using System.Diagnostics;
using System.Text;

Start start = new Start();
start.starter();

class Start
{
    public void starter()
    {
        Laba7 laba = new Laba7("c++ dgfdg builder presents");
        Poem poem = new Poem();
        laba.FirstEx();
        laba.SecondEx();
        poem.ReplaceChars();
        poem.WordsCount();
        poem.ConsAndVowels();
        poem.SlowAndFastTest();
    }
}
class Laba7
{
    private string userStr;

    public Laba7(string userStr) { this.userStr = userStr; }

    public void FirstEx()
    {
        StringBuilder str = new StringBuilder(userStr);
        for (int i = 0; i <= str.Length; i += 3)
        {
            Console.WriteLine(str[i]);
        }
    }
    public void SecondEx()
    {
        string[] words = userStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var sortedWords = words.OrderByDescending(w => w.Length).ToList();

        string[] top3Words = new string[Math.Min(sortedWords.Count, 3)];

        for (int i = 0; i < top3Words.Length; i++)
        {
            Console.WriteLine(sortedWords[i]);
        }


    }
}
class Poem
{
    public static string text = "У лукоморья дуб зелёный;\n" +
"Златая цепь на дубе том:\n" +
"И днём и ночью кот учёный\n" +
"Всё ходит по цепи кругом;\n" +
"Идёт направо — песнь заводит,\n" +
"Налево — сказку говорит.\n" +
"Там чудеса: там леший бродит,\n" +
"Русалка на ветвях сидит;\n" +
"Там на неведомых дорожках\n" +
"Следы невиданных зверей;\n" +
"Избушка там на курьих ножках\n" +
"Стоит без окон, без дверей;\n" +
"Там лес и дол видений полны;\n" +
"Там о заре прихлынут волны\n" +
"На брег песчаный и пустой,\n" +
"И тридцать витязей прекрасных\n" +
"Чредой из вод выходят ясных,\n" +
"И с ними дядька их морской;\n" +
"Там королевич мимоходом\n" +
"Пленяет грозного царя;\n" +
"Там в облаках перед народом\n" +
"Через леса, через моря\n" +
"Колдун несёт богатыря;\n" +
"В темнице там царевна тужит,\n" +
"А бурый волк ей верно служит;\n" +
"Там ступа с Бабою Ягой\n" +
"Идёт, бредёт сама собой,\n" +
"Там царь Кащей над златом чахнет;\n" +
"Там русский дух ... там Русью пахнет!\n" +
"И там я был, и мёд я пил;\n" +
"У моря видел дуб зелёный;\n" +
"Под ним сидел, и кот учёный\n" +
"Свои мне сказки говорил.";

    public void ReplaceChars()
    {
        var words = text.Split(new[] { ' ', '\n', ';', ',',':' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length >= 7)
            {
                words[i] = words[i].Remove(6, 1).Insert(6, "#");
            }
            if (words[i].Length >= 4)
            {
                words[i] = words[i].Remove(3, 1).Insert(3, "#");
            }
        }
        string str = string.Join(" ", words);
        Console.WriteLine(str);
    }


    public void WordsCount()
    {
        string[] words = text.Split(' ', '\n');
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        foreach (string word in words)
        {
            string lowerCase = word.ToLower();
            if (wordsCount.ContainsKey(lowerCase)) wordsCount[lowerCase]++;
            else wordsCount.Add(lowerCase, 1);
        }

        foreach (var entry in wordsCount) Console.WriteLine($"{entry.Key} = {entry.Value}");
    }
    public void ConsAndVowels()
    {
        string[] words = text.Split(' ', '\n');

        foreach (string word in words)
        {
            if (IsConsonantAndVowel(word)) Console.WriteLine(word);
        }
    }

    public void SlowAndFastTest()
    {
        Stopwatch sw = Stopwatch.StartNew();
        string slow = Slow(text);
        sw.Stop();
        Console.WriteLine($"Медленная выполнила свою работу за {sw.ElapsedMilliseconds} милисек");

        Stopwatch sw2 = Stopwatch.StartNew();
        string fast = Fast(text);
        sw.Stop();
        Console.WriteLine($"Быстрая выполнила свою работу за  {sw2.ElapsedMilliseconds} милисек");
    }

    private string Slow(string text)
    {
        string[] words = text.Split(' ', '\n');
        Random rnd = new Random();

        string result = "";
        for (int i = 0; i < 100000; i++)
        {
            int randIndex = rnd.Next(words.Length);
            result += words[randIndex] + " ";
        }
        return result;
    }

    private string Fast(string text)
    {
        string[] words = text.Split(' ', '\n');
        Random rnd = new Random();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < 100000; i++)
        {
            int randIndex = rnd.Next(words.Length);
            sb.Append(words[randIndex]);
            sb.Append(' ');
        }
        return sb.ToString();
    }

    private bool IsConsonantAndVowel(string word)
    {
        string lowerCase = word.ToLower();

        char firstChar = lowerCase[0];
        if (!IsConsonant(firstChar)) return false;

        char lastChar = lowerCase[lowerCase.Length - 1];
        if (!IsVowel(lastChar)) return false;

        return true;
    }


    private bool IsConsonant(char c)
    {
        char[] consonants = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        return Array.IndexOf(consonants, c) != -1;
    }

    private bool IsVowel(char c)
    {
        char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        return Array.IndexOf(vowels, c) != -1;
    }

}
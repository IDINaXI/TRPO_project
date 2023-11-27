UserIdentification us = new UserIdentification();
Console.WriteLine("Введите имя пользователя:");
string username = Console.ReadLine();

Console.WriteLine("Введите пароль:");
string password = Console.ReadLine();

if (us.AuthenticateUser(username, password))
{
    Console.WriteLine("Пользователь аутентифицирован.");
}
else
{
    Console.WriteLine("Ошибка аутентификации. Неверное имя пользователя или пароль.");
}

Console.WriteLine("Введите текст на русском:");
string input = Console.ReadLine();
var Transliteration = new Transliteration();
string transliterated = Transliteration.Transliterate(input);
Console.WriteLine("Транслитерированный текст: " + transliterated);
class Transliteration
{
    static Dictionary<char, string> translitTable = new Dictionary<char, string>
    {
        {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"},
        {'е', "e"}, {'ё', "yo"}, {'ж', "zh"}, {'з', "z"}, {'и', "i"},
        {'й', "y"}, {'к', "k"}, {'л', "l"}, {'м', "m"}, {'н', "n"},
        {'о', "o"}, {'п', "p"}, {'р', "r"}, {'с', "s"}, {'т', "t"},
        {'у', "u"}, {'ф', "f"}, {'х', "kh"}, {'ц', "ts"}, {'ч', "ch"},
        {'ш', "sh"}, {'щ', "sch"}, {'ъ', ""}, {'ы', "y"}, {'ь', ""},
        {'э', "e"}, {'ю', "yu"}, {'я', "ya"}
    };

    public static string Transliterate(string input)
    {
        var result = "";
        foreach (var c in input.ToLower())
        {
            if (translitTable.TryGetValue(c, out var translit))
                result += translit;
            else
                result += c;
        }
        return result;
    }
}

class UserIdentification
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    static readonly User[] users = new User[]
    {
        new User { Username = "user1", Password = "1234" }, 
        new User { Username = "DINaX", Password = "12341234" }
      
    };

    public bool AuthenticateUser(string username, string password)
    {
        for(int i =0; i<users.Length;i++)
        {
            if(username == users[i].Username)
            {
                if(users[i].Password == password)
                {
                    return true;
                }

            }
        }
        return false;
    }

}

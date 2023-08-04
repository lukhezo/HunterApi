using HunterApi.Hunter;

ConsoleKeyInfo keyInfo;
string? email;

do
{
    Console.Write("Please enter an email address: ");    
    email = Console.ReadLine();

    if (email!= null && RegexUtilities.IsValidEmail(email))
    {
        var api = new HunterClient();
        var response = await api.IsWebmail(email);
        Console.WriteLine(response);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter a valid email address");
        Console.ResetColor();
    }

    Console.Write("Please enter to continue or \"E\" to exit");
    keyInfo = Console.ReadKey();
    Console.WriteLine();

} while (keyInfo.Key != ConsoleKey.E);


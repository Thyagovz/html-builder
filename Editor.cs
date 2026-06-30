using System.Text;

namespace HtmlBuilder;

public static class Editor
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("MODO EDITOR");
        Console.WriteLine("-----------");
        Start();
    }

    public static void Start()
    {
        var file = new StringBuilder();

        while (true)
        {
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                file.Append(Environment.NewLine);
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (file.Length > 0)
                {
                    file.Remove(file.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            else
            {
                Console.Write(keyInfo.KeyChar);
                file.Append(keyInfo.KeyChar);
            }
        }

        Console.WriteLine("\n-----------");
        Console.WriteLine("Deseja salvar o arquivo? (S/N)");

        var opcao = Console.ReadKey(true).Key;

        if (opcao == ConsoleKey.S)
        {
            Salvar(file.ToString());
        }

        Viewer.Show(file.ToString());
    }

    public static void Salvar(string text)
    {
        Console.Clear();
        Console.WriteLine("Qual o caminho e nome para salvar o arquivo?");
        var path = Console.ReadLine();

        try
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write(text);
            }
            Console.WriteLine("\nArquivo salvo com sucesso!");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro ao salvar: {ex.Message}");
            Console.ReadKey();
        }
    }
}
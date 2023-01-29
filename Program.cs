using System;
using System.IO;

namespace TextEditor
{
   internal class Program 
   {
    static void Main (string[] args)
    {
        Menu();        
    }
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1 - Open File");
        Console.WriteLine("2 - Create new file");
        Console.WriteLine("0 - Exit");
        short option = short.Parse(Console.ReadLine());

        switch(option)
        {
            case 0: System.Environment.Exit(0); break;
            case 1: Open(); break;
            case 2: Edit(); break;
            default: Menu(); break;

        }

    }
    static void Open()
    {
        Console.Clear();
        Console.WriteLine("Insert the file path.");
        string path = Console.ReadLine();

        using (var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();
            Console.WriteLine(text);

        }
        Console.WriteLine("");
        Console.ReadLine();
        Menu();

    }
    static void Edit()
    {
        Console.Clear();
        Console.WriteLine("Type your text below (ESC to exit)");
        Console.WriteLine(" --------------------------- ");
        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        }

        while (Console.ReadKey().Key != ConsoleKey.Escape);

        Save(text);    
           
    }
    static void Save(string text)
    {
        Console.Clear();
        Console.WriteLine("Where you want to save?");
        var path = Console.ReadLine();

        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        } 

        Console.WriteLine($"Successfully Saved! {path} "); 
        Console.ReadLine();
        Menu();


    }
   } 
}

// Estutura de repetição While que executa uma condição enquanto ela for verdadeira.
// Para buscar uma tecla especifica para estopar a programação é usada a função ReadKey().Key onde l é uma tecla especifíca e função ConsoleKey.Escape para sair. 
// Para abrir um arquivo podemos usar StreamReader para abrir um arquivo para escrita é o StreamWriter. Tanto um como o outro é necessário fechar.
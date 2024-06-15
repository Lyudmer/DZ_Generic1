
using DZ_Generic;
internal class Program
{
    private static void Main()
    {
        GetMaxList();
        
        FindFileFromDir();

        
    }
    private static void GetMaxList()
    {
        List<Book> books = new List<Book>()
        {
            new Book { Name = "Гамлет", CreateYear = 1930 },
            new Book { Name = "История древнего мира", CreateYear = 1945 },
            new Book { Name = "Математика 10 кл", CreateYear = 1975 }
        };
        Book oldestBook = books.GetMax(p => p.CreateYear);

        Console.WriteLine($"Самая новая книга : {oldestBook.Name}, год издания: {oldestBook.CreateYear}.");
    }
    private static void FindFileFromDir()
    {
        Console.Write("Укажите папку для поиска файлов: ");
        string? DirPath = Console.ReadLine();

        FileListEvents fileSelect = new();

        fileSelect.FileListSelected += (sender, fileF) =>
        {
             Console.WriteLine($"Файл найден: {fileF.FilePath}");

         };
         fileSelect.Search(DirPath);
         Console.ReadKey();
    }


}



using LibraryManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        var libraryManager = new LibraryManager();
        var book = new Book(1, "C# in Depth", "Jon Skeet", 2021);
        libraryManager.AddItem(book);

        foreach (var item in libraryManager.GetAllItems())
        {
            Console.WriteLine(item.GetDisplayInfo());
        }
    }
    //Островський Р. ПД-23
}

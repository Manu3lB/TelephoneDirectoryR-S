namespace TelephoneDirectory;
public class Program
{
    public static void Main(string[] args)
    {
        Contact contact = new Contact();
        Menu menu = new Menu();
        menu.DirectoryMenu();
    }
}
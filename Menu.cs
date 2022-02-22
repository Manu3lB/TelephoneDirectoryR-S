
namespace TelephoneDirectory
{
    public class Menu
    {
        DirectoryAll directoryAll = new DirectoryAll();
        public List<Contact> listContacts = new List<Contact>();

        enum menuDirectory
        {
            addContact = 1,
            listContact,
            searchContact,
            existContact,
            deleteContact,
            directoryWhitspace,
            directoryFull,
            exit,
        }

        public void DirectoryMenu()
        {
            int size = 10;
            directoryAll.SizeDirectory(size);

            bool access = false;
            do
            {
                MenuDirectory();
                try
                {
                    Console.WriteLine("Ingrese la opción que desea ");
                    menuDirectory selecOption = (menuDirectory)Enum.Parse(typeof(menuDirectory), Console.ReadLine());

                    switch (selecOption)
                    {
                        case menuDirectory.addContact:
                            Console.WriteLine("\t\t1. Adicionar Contacto\n");
                            ValidateDirectory();
                            BackToMenu();
                            break;
                        case menuDirectory.listContact:
                            Console.WriteLine("\t\t2. Listar Contactos\n");
                            directoryAll.ListContacts();
                            BackToMenu();
                            break;
                        case menuDirectory.searchContact:
                            Console.WriteLine("\t\t3. Buscar Contacto\n");
                            Contact contact = directoryAll.SearchContact((SearchForName()));
                            ValidateSearchContact(contact);
                            BackToMenu();
                            break;
                        case menuDirectory.existContact:
                            Console.WriteLine("\t\t4. Existe Contacto\n");
                            ValidateExistContact();
                            break;
                        case menuDirectory.deleteContact:
                            Console.WriteLine("\t\t5. Eliminar Contacto\n");
                            directoryAll.DeleteContact(AskForName());
                            BackToMenu();
                            break;
                        case menuDirectory.directoryWhitspace:
                            Console.WriteLine("\t\t6. Contactos disponibles\n");
                            Console.WriteLine("\n========  Hay " + directoryAll.DirectoryWhitspace() + " espacios para guardar contactos  =========");
                            BackToMenu();
                            break;
                        case menuDirectory.directoryFull:
                            Console.WriteLine("\t\t7. Agenda Llena\n");
                            ValidateDirectoryFull();
                            break;
                        case menuDirectory.exit:
                            Console.WriteLine("\t\t8. Salir\n");
                            access = ExitDirectory();
                            break;
                        default:
                            DefaultOption();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("======== VALOR INVALIDO INGRESE UN NUMERO DEL 1 AL 8 =====");
                    BackToMenu();
                }
            } while (access != true);

        }

        public void MenuDirectory()
        {
            Console.WriteLine("\n");
            Console.WriteLine("====================================================");
            Console.WriteLine("=============  MENU DIRECTORIO TELEFONICO  =========");
            Console.WriteLine("====================================================");
            Console.WriteLine("==             1. ADICIONAR CONTACTO              ==");
            Console.WriteLine("==             2. LISTAR CONTACTOS                ==");
            Console.WriteLine("==             3. BUSCAR CONTACTOS                ==");
            Console.WriteLine("==             4. EXISTE CONTACTO                 ==");
            Console.WriteLine("==             5. ELIMINAR CONTACTO               ==");
            Console.WriteLine("==             6. CONTACTOS DISPONIBLES           ==");
            Console.WriteLine("==             7. AGENDA LLENA                    ==");
            Console.WriteLine("==             8. SALIR                           ==");
            Console.WriteLine("====================================================");
            Console.WriteLine("\n");
        }

        public Contact AskForInformation()
        {
            Contact contacts = new Contact();
            string name = "";
            do
            {
                Console.WriteLine("Es obligatorio ingresar el nombre del contacto en este campo");
                Console.WriteLine("\nEscriba el nombre del contacto :");
                contacts.name = Console.ReadLine();
                name = contacts.name;
            } while (name == "" || name == null);
            Console.WriteLine("Escriba el telefono del contacto :");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Escriba el celular del contacto :");
            string cellPhone = Console.ReadLine();
            return new Contact(name.ToUpper(), phoneNumber, cellPhone);
        }

        public Contact AskForName()
        {
            List<Contact> contacts = new List<Contact>();
            Console.WriteLine("Escriba el nombre del contacto :");
            string nameAsk = Console.ReadLine();
            var contact = new Contact(nameAsk.ToUpper());
            return contact;
        }

        public string SearchForName()
        {
            Console.WriteLine("Escriba el nombre del contacto :");
            string nameSearch = Console.ReadLine();
            return nameSearch.ToUpper();
        }

        public void ValidateDirectory()
        {
            if (directoryAll.DirectoryFull() == true)
            {
                Console.WriteLine("====================================================");
                Console.WriteLine("==    El directorio no se encuentra con espacio   ==");
                Console.WriteLine("====================================================");
            }
            else
            {
                directoryAll.AddContact(AskForInformation());
            }
        }

        public void ValidateSearchContact(Contact contact)
        {
            if (contact != null)
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("=========       Se encontro contacto:   ==================");
                Console.WriteLine(contact.ToString());
            }
            else
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("==     No se encontro este contacto. Intete de nuevo   ===");
                Console.WriteLine("==========================================================");
            }
        }

        public void ValidateExistContact()
        {


            if (directoryAll.ExistContact(AskForName()))
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("==     El contacto se encuentra en el directorio       ===");
                Console.WriteLine("==========================================================");
            }
            else
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("==     No existe este contacto en el directorio       ====");
                Console.WriteLine("==========================================================");
            }
            BackToMenu();
        }

        public void ValidateDirectoryFull()
        {
            if (directoryAll.DirectoryFull())
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("==           No hay espacio en la agenda                ==");
                Console.WriteLine("==========================================================");
            }
            else
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("= La agenda aún conserva espacio para agregar contactos. =");
                Console.WriteLine("==========================================================");
            }
            BackToMenu();
        }

        public void BackToMenu()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("========== Oprima una tecla para volver al menú  =========");
            Console.WriteLine("==========================================================");
            Console.ReadKey();
        }

        public bool ExitDirectory()
        {
            bool exit = true;
            Console.WriteLine("==========================================================");
            Console.WriteLine("== ¡Gracias por usar nuestro directorio, vuelva pronto! ==");
            Console.WriteLine("==========================================================");
            return exit;
        }

        public void DefaultOption()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("=========== Número no valido intente nuevamente  =========");
            Console.WriteLine("==========================================================");
            BackToMenu();
        }
    }
}
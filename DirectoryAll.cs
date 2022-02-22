namespace TelephoneDirectory
{
    public class DirectoryAll
    {

        int size = 10;
        public List<Contact> listContacts = new List<Contact>(10);

        public int SizeDirectory(int sizeLocal)
        {
            bool validateSize = false;

            Console.WriteLine("\n=======================================================================================");
            Console.WriteLine("==     Por favor Indique el número de contactos que desea adicionar, entre 1 y 10.   ==");
            Console.WriteLine("=======================================================================================\n");
            do
            {
                try
                {
                    sizeLocal = Int32.Parse(Console.ReadLine());

                    if (sizeLocal > 10)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("===============================      VALOR INVALIDO           ============================");
                        Console.WriteLine("== Por favor Indique el número de contactos que desea adicionar, que este entre 1 y 10. ==");
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n");
                    }
                    else if (sizeLocal < 1)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("=======================      VALOR INVALIDO           ====================================");
                        Console.WriteLine("== Por favor Indique el número de contactos que desea adicionar, que este entre 1 y 10. ==");
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        listContacts = new List<Contact>(sizeLocal);
                        validateSize = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("===========================================================================================");
                    Console.WriteLine("=======================      VALOR INVALIDO           =====================================");
                    Console.WriteLine("==  Por favor Indique el número de contactos que desea adicionar, que este entre 1 y 10. ==");
                    Console.WriteLine("===========================================================================================");
                    Console.WriteLine("\n");

                }
            } while (validateSize == false);

            size = sizeLocal;
            return size;
        }

        public void AddContact(Contact contacts)
        {
            try
            {
                if (listContacts.Count() < (size))
                {
                    if (!ExistContact(contacts))
                    {
                        listContacts.Add(contacts);
                        Console.WriteLine("====================================================");
                        Console.WriteLine("==        Se agrego correctamente el contacto     ==");
                        Console.WriteLine("====================================================");
                    }
                    else
                    {
                        Console.WriteLine("====================================================");
                        Console.WriteLine("==      El contacto ya se encuentra en la lista   ==");
                        Console.WriteLine("====================================================");
                    }
                }
                else
                {
                    Console.WriteLine("====================================================");
                    Console.WriteLine("==    El directorio no se encuentra con espacio   ==");
                    Console.WriteLine("====================================================");
                }
            }
            catch { };
        }

        public Boolean ExistContact(Contact contacts)
        {
            bool existContact = false;

            if (listContacts.Count() > 0)
            {
                foreach (var contactAll in listContacts)
                {
                    if (contactAll.name.Equals(contacts.name))
                    {
                        Console.WriteLine(contactAll.name);
                        existContact = true;
                        return existContact;
                    }
                }
            }
            return existContact;
        }

        public void ListContacts()
        {
            try
            {
                if (listContacts.Count() > 0)
                {
                    foreach (Contact contactList in listContacts)
                    {
                        if (contactList != null)
                        {
                            Console.WriteLine(contactList.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("====================================================");
                    Console.WriteLine("==          No hay contactos en la lista          ==");
                    Console.WriteLine("====================================================");
                }
            }
            catch { }
        }


        public Contact SearchContact(string nameSearch)
        {
            try
            {
                if (listContacts.Count() >= 0)
                {
                    for (int i = 0; i < listContacts.Capacity; i++)
                    {
                        if (nameSearch != null)
                        {
                            try
                            {
                                if (listContacts.ElementAt(i).name.Equals(nameSearch))
                                {
                                    return listContacts.ElementAt(i);
                                }
                            }
                            catch (Exception ex) { }
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        public bool DeleteContact(Contact contacts)
        {
            bool delete = false;
            if (SearchContact(contacts.name) != null)
            {
                listContacts.RemoveAt(listContacts.IndexOf(SearchContact(contacts.name)));
                Console.WriteLine("========================================================");
                Console.WriteLine("======   Fue eliminado " + contacts.name + " de la agenda.");
                Console.WriteLine("========================================================");
                delete = true;
                return delete;
            }
            else
            {
                Console.WriteLine("====================================================");
                Console.WriteLine("=     No se encontro el contacto que a eliminar   ==");
                Console.WriteLine("====================================================");
                return delete;
            }
        }

        public Boolean DirectoryFull()
        {
            bool directoryFull = false;
            directoryFull = listContacts.Count() == size ? true : false;
            return directoryFull;
        }


        public int DirectoryWhitspace()
        {
            int directoryWhitspace = 0;
            directoryWhitspace = listContacts.Count() >= 0 ? listContacts.Capacity - listContacts.Count() : listContacts.Capacity;
            return directoryWhitspace;
        }
    }
}

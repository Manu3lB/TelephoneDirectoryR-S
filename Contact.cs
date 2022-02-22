namespace TelephoneDirectory
{
    public class Contact
    {
        public string name {get; set;}
        public string phoneNumber {get; set;}
        public string cellPhone {get; set;}

        public Contact()
        {
            this.name = "";
            this.phoneNumber = "";
            this.cellPhone = "";
        }

        public Contact(string _name)
        {
            this.name = _name;
        }

        public Contact(string _name, string _phoneNumber, string _cellPhone)
        {
            this.name = _name;
            this.phoneNumber = _phoneNumber;
            this.cellPhone = _cellPhone;
        }

        public override string ToString()
        {
            return "\n========= Directorio Telefonico =========== \nNombre Contacto : " + name.ToString() + "\nTelefono fijo   : " + phoneNumber.ToString() + "\nCelular         : " + cellPhone.ToString() + "\n============================================\n";
        }

    }
}
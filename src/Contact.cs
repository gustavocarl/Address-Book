namespace Address_Book
{
    internal class Contact
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public Telephone? Telephone { get; set; }

        public Contact()
        { }

        public Contact
            (
                string firstName,
                string lastName,
                string email,
                Telephone telephone
            )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
        }

        public Contact
            (
                int id,
                string firstName,
                string lastName,
                string email,
                Telephone telephone
            )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"Dados do Contato: \n" +
                $"Id: {Id}\n" +
                $"Primeiro Nome: {FirstName}\n" +
                $"Último Nome: {LastName}\n" +
                $"Email: {Email}\n" +
                $"{Telephone}\n";
        }
    }
}
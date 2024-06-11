namespace Address_Book
{
    internal class Telephone
    {
        public int Id { get; set; }

        public string? Type { get; set; }

        public string? Ddd { get; set; }

        public string? TelephoneNumber { get; set; }

        public Telephone()
        { }

        public Telephone
            (
                string type,
                string ddd,
                string telephoneNumber
            )
        {
            Type = type;
            Ddd = ddd;
            TelephoneNumber = telephoneNumber;
        }

        public Telephone
            (
                int id,
                string type,
                string ddd,
                string telephoneNumber
            )
        {
            Id = id;
            Type = type;
            Ddd = ddd;
            TelephoneNumber = telephoneNumber;
        }

        public override string ToString()
        {
            return $"Dados do Telefone:\n" +
                $"Id: {Id}\n" +
                $"Tipo: {Type}\n" +
                $"DDD: {Ddd}\n" +
                $"Número de Telefone: {TelephoneNumber}\n" +
                $"";
        }
    }
}
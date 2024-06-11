using Address_Book;
using Microsoft.Data.SqlClient;

string connectionString = "Server = localhost; Database = ADDRESS_BOOK; User Id=sa;Password = 123456; TrustServerCertificate = true";

var telephone = new Telephone();
var contact = new Contact();

Console.WriteLine("Insira o primeiro nome: ");
contact.FirstName = Console.ReadLine();

Console.WriteLine("Insira o último nome: ");
contact.LastName = Console.ReadLine();

Console.WriteLine("Insira o email: ");
contact.Email = Console.ReadLine();

Console.WriteLine("Insira o tipo de contato: ");
telephone.Type = Console.ReadLine();

Console.WriteLine("Insira o DDD: ");
telephone.Ddd = Console.ReadLine();

Console.WriteLine("Insira o número de telefone: ");
telephone.TelephoneNumber = Console.ReadLine();

contact.Telephone = telephone;

Console.WriteLine(contact.ToString());

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();

    SqlTransaction transaction = connection.BeginTransaction();

    try
    {
        string insertTelephoneQuery = @"INSERT INTO TELEPHONE
                                   (
                                    TYPE,
                                    DDD,
                                    TELEPHONENUMBER
                                   ) VALUES (
                                    @TYPE,
                                    @DDD,
                                    @TELEPHONENUMBER
                                   );
                                   SELECT SCOPE_IDENTITY();";

        int telephoneId;
        using (SqlCommand command = new SqlCommand(insertTelephoneQuery, connection, transaction))
        {
            command.Parameters.AddWithValue("@TYPE", contact.Telephone.Type);
            command.Parameters.AddWithValue("@DDD", contact.Telephone.Ddd);
            command.Parameters.AddWithValue("@TELEPHONENUMBER", contact.Telephone.TelephoneNumber);

            telephoneId = Convert.ToInt32(command.ExecuteScalar());
        }

        string InsertQuery = @"INSERT INTO CONTACT
                          (
                           FIRSTNAME,
                           LASTNAME,
                           EMAIL,
                           TELEPHONEID
                          ) VALUES (
                           @FIRSTNAME,
                           @LASTNAME,
                           @EMAIL,
                           @TELEPHONEID
                          )";

        using (SqlCommand command = new(InsertQuery, connection, transaction))
        {
            command.Parameters.AddWithValue("@FIRSTNAME", contact.FirstName);
            command.Parameters.AddWithValue("@LASTNAME", contact.LastName);
            command.Parameters.AddWithValue("@EMAIL", contact.Email);
            command.Parameters.AddWithValue("@TELEPHONEID", telephoneId);

            command.ExecuteNonQuery();
        }

        transaction.Commit();

        Console.Clear();

        string selectQuery = "SELECT * FROM CONTACT";

        using (SqlCommand command = new(selectQuery, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}");
                    Console.WriteLine($"Primeiro Nome: {reader["FIRSTNAME"]}");
                    Console.WriteLine($"Último Nome: {reader["LASTNAME"]}");
                    Console.WriteLine($"Email: {reader["EMAIL"]}");
                    Console.WriteLine($"TelephoneId: {reader["TELEPHONEID"]}");
                    Console.WriteLine();
                }
            }
        }
    }
    catch (Exception ex)
    {
        transaction.Rollback();
        Console.WriteLine($"Erro ao inserir dados: {ex.Message}");
    }
}
using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecieveFromDB
{
    internal class Program
    {

        static DBConnectionManager db = new();

        static void Main(string[] args)
        {

            var cs = "Host=129.151.221.119;Username=599146;Password=Ha1FinDagIDag!;Database=599146";

            using var con = new NpgsqlConnection(cs);
            {
                con.Open();

                string kortIdToCheck = "2222";
                UserDataClass? info = db.GetNameFromCardID(con, kortIdToCheck);

                if (info != null)
                {
                    Console.WriteLine($"Kortid {kortIdToCheck} godkjent. \nNavn: {info.FirstName}, Email: {info.Email}, Cardpin: {info.CardPin}");
                }
                else
                {

                    Console.WriteLine("Not found");


                }

                con.Close();

            }

        }
    }
}

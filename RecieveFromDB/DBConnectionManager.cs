using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;



namespace RecieveFromDB
{



    internal class DBConnectionManager
    {

        public DBConnectionManager()
    {
     }

        public UserDataClass? GetNameFromCardID(NpgsqlConnection con, string kortid)
        {


            string query = "SELECT kortid, fornavn, etternavn, email, pinkode FROM userdata WHERE kortid = :kortid";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
            {

                cmd.Parameters.AddWithValue(":kortid", kortid);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {

                        return new UserDataClass()
                        {
                            FirstName = reader["fornavn"]?.ToString(),
                            LastName = reader["etternavn"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            CardID = reader["kortid"]?.ToString(),
                            CardPin = reader["pinkode"].ToString()
                        };
                    }
                }

            }

            UserDataClass result = new UserDataClass();

            return null;
        }







    }
}

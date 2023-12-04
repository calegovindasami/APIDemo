using APIDemo.Models;
using System.Data;
using System.Data.SqlClient;

namespace APIDemo.Services
{
    public class DbRecipientService : IRecipientService
    {
        public static string connectionString = "Data Source=CALE-PC\\SQLEXPRESS;Initial Catalog=ApiDemo;Integrated Security=True;Encrypt=False";
        SqlConnection connection = new SqlConnection(connectionString);
        //Let say this service class connects to a database
        public Recipient Add(Recipient recipient)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("INSERT INTO Recipients VALUES (@first_name, @last_name)", connection);

                cmd.Parameters.AddWithValue("@first_name", recipient.FirstName);
                cmd.Parameters.AddWithValue("@last_name", recipient.LastName);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return recipient;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Recipient> Get()
        {
            List<Recipient> recipients = new List<Recipient>();
            try
            {
                connection.Open();
                SqlCommand cmd = new("SELECT * FROM Recipients", connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recipients.Add(new Recipient()
                        {
                            FirstName = reader.GetString("first_name"),
                            LastName = reader.GetString("last_name"),
                            Id = reader.GetInt32("id")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return recipients;
        }

        public Recipient Update(Recipient recipient)
        {
            throw new NotImplementedException();
        }
    }
}
